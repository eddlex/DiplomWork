using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;


namespace FrontEnd.Model;

public class UserSession
{
    [System.Text.Json.Serialization.JsonConstructor]
    public UserSession(int userId, int departmentId, int roleId, string token, string userName)
    {
        this.UserId = userId;
        this.DepartmentId = departmentId;
        this.RoleId = roleId;
        this.Token = token;
        this.UserName = userName;

    }

    public UserSession(string token)
    {
        this.Token = token;
        ParseJwtToken(token);
    }
    
    public int UserId { get; set; }
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }
    public string Token { get; set; }
    public string UserName { get; set; }
    
    
    public void ParseJwtToken(string jwtToken)
    {
        var tokenParts = jwtToken.Split('.');

        if (tokenParts.Length != 3)
        {
            Console.WriteLine("Invalid JWT format.");
            return;
        }
        var base64Payload = tokenParts[1];
        int paddingNeeded = base64Payload.Length % 4;
        if (paddingNeeded > 0)
        {
            base64Payload += new string('=', 4 - paddingNeeded);
        }
        var payloadBytes = Convert.FromBase64String(base64Payload);
        var jsonPayload = System.Text.Encoding.UTF8.GetString(payloadBytes);
        var jwtPayload = JwtPayload.Deserialize(jsonPayload);
        this.UserId = Convert.ToInt32(jwtPayload.Claims.FirstOrDefault(p => p.Type == nameof(UserId))?.Value);
        this.DepartmentId = Convert.ToInt32(jwtPayload.Claims.FirstOrDefault(p => p.Type == nameof(DepartmentId))?.Value);
        this.RoleId = Convert.ToInt32(jwtPayload.Claims.FirstOrDefault(p => p.Type == "role" )?.Value);
        this.UserName = jwtPayload.Claims.FirstOrDefault(p => p.Type == nameof(UserName))?.Value;
    }
}