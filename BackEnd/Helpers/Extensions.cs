using System.Security.Claims;
using FrontEnd.Helpers;

namespace BackEnd.Helpers
{
    public static class Extensions
    {

        public static (int UserId, int DepartmentId, int RoleId) ParseToken(this ClaimsPrincipal user)
        {
            try
            {
                return (Convert.ToInt32(user.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value),
                        Convert.ToInt32(user.Claims.FirstOrDefault(claim => claim.Type == "DepartmentId")?.Value),
                        Convert.ToInt32(user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value));
            }
            catch (Exception ex)
            {
                return (-1, -1, -1);
            }
        }
        
        private static Os GetOsType()
        {
            var os = Environment.OSVersion;
            switch (os.Platform)
            {
                case PlatformID.Win32NT:
                    return Os.Windows;
                case PlatformID.Unix:
                    return Os.UnixLinux;
                case PlatformID.MacOSX:
                    return Os.MacOs;
                default:
                    return Os.Undefined;
            }
        }

        public static string GetPathSlashType()
        {
            var platform = GetOsType();
            return platform switch
            {
                Os.Undefined => throw Alert.Create("Platform Error"),
                Os.UnixLinux => "/",
                Os.MacOs => "/",
                Os.Windows => "\\",
                _ => throw Alert.Create("Platform Error")
            };
        }
    }
}
