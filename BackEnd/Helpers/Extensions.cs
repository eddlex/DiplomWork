using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace BackEnd.Helpers
{
    public static  class Extensions
    {

        public static (string UserId, int UniversityId) ParseToken(this ClaimsPrincipal user)
        {
            try
            {
                return (user.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value,
                        Convert.ToInt32(user.Claims.FirstOrDefault(claim => claim.Type == "UniversityId")?.Value));
            }
            catch (Exception ex)
            {
                return ("", -1);
            }
        }
    }
}
