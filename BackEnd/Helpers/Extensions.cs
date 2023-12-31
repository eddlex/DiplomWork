﻿using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace BackEnd.Helpers
{
    public static class Extensions
    {

        public static (int UserId, int UniversityId, int PermissionId) ParseToken(this ClaimsPrincipal user)
        {
            try
            {
                return (Convert.ToInt32(user.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value),
                        Convert.ToInt32(user.Claims.FirstOrDefault(claim => claim.Type == "UniversityId")?.Value),
                        Convert.ToInt32(user.Claims.FirstOrDefault(claim => claim.Type == "PermissionId")?.Value));
            }
            catch (Exception ex)
            {
                return (-1, -1, -1);
            }
        }
    }
}
