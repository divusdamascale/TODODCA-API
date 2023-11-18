using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.API.Utils.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Utils
{
    public class JWTUtils : IJWTUtils
    {
        private readonly SettingsOptions _option;

        public JWTUtils(SettingsOptions option)
        {
            _option = option;
        }

        public string CreateToken(User user)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_option.jwt.Secret);
            var symmetricKey = new SymmetricSecurityKey(keyBytes);
            var signingCredentials = new SigningCredentials(
                symmetricKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("sub", user.Username),
                new Claim("email", user.Email),
                new Claim("id", user.UserId.ToString()),

            };

            var token = new JwtSecurityToken(
                issuer: _option.jwt.Issuer, // Adaugă issuer
                audience: _option.jwt.Audience, // Adaugă audience
                claims: claims,
                expires: DateTime.Now.Add(TimeSpan.FromSeconds(_option.jwt.ExpirationSeconds)),
                signingCredentials: signingCredentials
            );

            var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
            return rawToken;
        }

    }
}
