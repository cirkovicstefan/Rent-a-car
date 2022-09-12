

using Core.Entities.Concrate;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
       
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
       

      
        public JwtHelper( IOptions<TokenOptions> appSettings)
        {
           
            _tokenOptions = appSettings.Value;
        
        }
        public AccessToken CreateToken(Korisnik korisnik)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var token = generateJwtToken(korisnik);
            return new AccessToken
            {
                Token = token,
                IdRole = korisnik.IdUloge,
                Expiration = _accessTokenExpiration
            };
        }
      
        private string generateJwtToken(Korisnik user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenOptions.Secret!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Email!) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
