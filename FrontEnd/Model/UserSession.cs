using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;

namespace FrontEnd.Model;

public class UserSession
{
    public UserSession(int userId, int universityId, int permissionId, string token)
    {
        this.UserId = userId;
        this.UniversityId = universityId;
        this.PermissionId = permissionId;
        this.Token = token;
    }

    public UserSession(string token)
    {
        this.Token = token;
        ParseJwtToken(token);
    }
    
    public int UserId { get; set; }
    public int UniversityId { get; set; }
    public int PermissionId { get; set; }
    public string Token { get; set; }
    
    
    
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
        this.UniversityId = Convert.ToInt32(jwtPayload.Claims.FirstOrDefault(p => p.Type == nameof(UniversityId))?.Value);
        this.PermissionId = Convert.ToInt32(jwtPayload.Claims.FirstOrDefault(p => p.Type == nameof(PermissionId))?.Value);
    }
}