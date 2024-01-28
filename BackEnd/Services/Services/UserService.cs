using BackEnd.Models.Input;
using BackEnd.Models.Output;
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
using Microsoft.AspNetCore.Mvc;
using UserPost = BackEnd.Models.Output.UserPost;

namespace BackEnd.Services.Services
{
    public class UserService : IUserService
    {
        public readonly DbService dbService;
        public readonly ConfigurationService configurationService;

        public UserService(IDbService dbService, IConfigurationService configurationService)
        {
            this.dbService = (DbService)dbService;
            this.configurationService = (ConfigurationService)configurationService;
        }

        public async Task<UserPost?> LogIn(Models.Input.UserPost user)
        {
            await using var connection = dbService.CreateConnection();

            return (await connection.QueryAsync<Models.Output.UserPost>("spLogIn", new {user.LogIn, user.Password}, commandType: CommandType.StoredProcedure)).FirstOrDefault();

        }
    
        public async Task<bool> Register(Models.Input.RegistrationPost user)
        {
            var result = (await dbService.QueryAsync<bool>("spRegister", new {user.LogIn, user.Email, user.Password})).FirstOrDefault();
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

                //return Results.Ok(jwtToken);
                return jwtToken;
            }
            else
            {
                //return Results.Unauthorized();
                return "";
            }
        
        }

    }
}
