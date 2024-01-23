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
    
    public int UserId { get; set; }
    public int UniversityId { get; set; }
    public int PermissionId { get; set; }
    public string Token { get; set; }
    
}