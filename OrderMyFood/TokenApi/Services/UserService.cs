using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OrderMyFood.TokenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Local = OrderMyFood.TokenApi.Models;

namespace OrderMyFood.TokenApi.Services
{

    public interface IUserService
    {
     Local.SecurityToken Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User {  Username = "speter", Password = "test@123" },
            new User {  Username = "gwoodhouse", Password = "pass@123" },
            new User {  Username = "jsmith", Password = "admin@123" },
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Local.SecurityToken Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.FbAppSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("name", user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new Local.SecurityToken() { auth_token = jwtSecurityToken };
        }
    }
}
