using Microsoft.IdentityModel.Tokens;
using PetShop.Core.DomainService.AuthRepo;
using PetShop.Core.Entity.AuthModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetShop.Infrastucture.SQLData.Repositories
{
    public class AuthenticationHelper: IAuthenticationHelper
    {
        private byte[] secretBytes;

        public AuthenticationHelper(Byte[] secret)
        {
            secretBytes = secret;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(secretBytes),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                               null, // audience - not needed (ValidateAudience = false)
                               claims.ToArray(),
                               DateTime.Now,                  // notBefore
                               DateTime.Now.AddMinutes(10))); // expires
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
