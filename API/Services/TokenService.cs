using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        //Symmetric - of encryption is one key that is used to encryp and decryp electronic information(WebToken) - This key does not need to leave the server
        //Asymmetric - one public, one pivate is used to encryp and decryp electronic information (https/ssl)
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])); //Using a token key property
        }

        public string CreateToken(AppUser user)
        {
            //Adding Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            //Creating Credentials
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            //Outlining how the token is going to look
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            //Handler
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor); //Create the token
            return tokenHandler.WriteToken(token); //Return the written token
        }
    }
}