
using BackEnd.Services.Configuration;
using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackEnd.Helpers;
using BackEnd.Models.Output;
using FrontEnd.Helpers;
using Exception = FrontEnd.Helpers.Exception;
using UserPost = BackEnd.Models.Output.UserPost;

namespace BackEnd.Services.Services
{
    public class UserService : IUserService
    {
        private readonly DbService dbService; 
        private readonly ConfigurationService configurationService;
        private  readonly (int UserId, int UniversityId, int RoleId)? token;
        public UserService(IDbService dbService,
                           IConfigurationService configurationService,
                           IHttpContextAccessor httpContextAccessor)
        {
            this.dbService = (DbService)dbService;
            this.configurationService = (ConfigurationService)configurationService;
            token = httpContextAccessor.HttpContext?.User.ParseToken();
        }

        public async Task<UserPost?> LogIn(Models.Input.UserPost user)
        {
            await using var connection = dbService.CreateConnection();

            return (await connection.QueryAsync<UserPost>("spLogIn", new {user.LogIn, user.Password}, commandType: CommandType.StoredProcedure)).FirstOrDefault();

        }
    
        public async Task<bool> Register(Models.Input.RegistrationPost user)
        {
            var result = (await dbService.QueryAsync<bool>("spRegister", new {user.UserName, user.Email, user.Password, user.UniversityId})).FirstOrDefault();
            return result;
        }
        

        public async Task<string> GenerateToken(Models.Input.UserPost user)
        {
            var userDb = await LogIn(user);
            if (userDb != null)
            {
                var jwt = this.configurationService.GetJwt();
                var issuer = jwt.Issuer;
                var audience = jwt.Audience;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwt.Key);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("UserId", userDb.Id.ToString()),
                        new Claim("UniversityId", userDb.UniversityId.ToString()),
                        new Claim(ClaimTypes.Role, userDb.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),

                    Expires = DateTime.UtcNow.AddHours(1),
                    Audience = audience,
                    Issuer = issuer,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = jwtTokenHandler.WriteToken(token);
                return jwtToken;
            }
            
            throw Exception.Create(Constants.Error.WrongPasswordOrUserName);
        }

        public async Task<List<UserGet?>> GetUsers()
        {
            if (!this.token.HasValue)
                return new();
            
            var param = new BaseParam()
            { 
               UniversityId = this.token.Value.UniversityId,
               RoleId = this.token.Value.RoleId,
            };
            var users = (await dbService.QueryAsync<UserGet>("spGetUsers", param)).ToList();
            return users;
        }

    }
}
