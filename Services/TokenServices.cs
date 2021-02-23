using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TotallyNotADatingApp.Entities;
using TotallyNotADatingApp.Interfaces;

namespace TotallyNotADatingApp.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly SymmetricSecurityKey _securityKey;

        public TokenServices(IConfiguration config)
        {
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token"]));
        }
        
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            var cred = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}