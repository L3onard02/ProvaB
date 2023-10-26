using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApiJWT.Helpers
{
    public class JWTHelper:IJWTHelper
    {/*
        private IConfiguration _config;
        public JWTHelper( IConfiguration config)
        {
            _config=config;
         
        }*/
        public  string GeneraJSONWebToken()
        {/*
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              null,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
            */
            int lunghezzaToken = 32; // Lunghezza del token desiderata
            string caratteri = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Caratteri possibili per il token
            char[] tokenArr = new char[lunghezzaToken];
            Random rand = new Random();

            for (int i = 0; i < lunghezzaToken; i++)
            {
                tokenArr[i] = caratteri[rand.Next(caratteri.Length)];
            }

            string token = new string(tokenArr);
            return token;
        }
    }
}
