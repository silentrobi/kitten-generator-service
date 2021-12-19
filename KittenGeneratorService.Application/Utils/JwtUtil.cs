using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KittenGeneratorService.Application.Utils
{
    public class JwtUtil
    {

        private readonly static string Secret = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
  
        /// <summary>
        /// Returns a token string from base claims
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalClaims"></param>
        /// <returns></returns>
        public static string GetJwtTokenString(
            string id,
            Claim[] additionalClaims = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,id)
            };

            if (additionalClaims is object)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(additionalClaims);
                claims = claimList.ToArray();
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
