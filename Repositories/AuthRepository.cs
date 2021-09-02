using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VidukaFiveNews.Models;
using BC = BCrypt.Net.BCrypt;
using System.Linq;

namespace VidukaFiveNews.Repositories
{
    public class AuthRepository
    {
        private readonly IConfiguration _config;

        public AuthRepository(IConfiguration config)
        {
            _config = config;
        }


        public LoginResponse Login(LoginRequest loginRequest)
        {
            Author author;

            using (var db = new VidukaFiveNewsContext())
            {
                author = db.Authors.SingleOrDefault(x => x.Email == loginRequest.Email);

                if (author != null)
                {
                    bool verified = BC.Verify(loginRequest.Password, author.Password);

                    if (verified == true)
                    {
                        var token = generateJwtToken(author);

                        return new LoginResponse(author, token);
                    }
                }
            }
            return null;

        }


        public void Registration(Author author)
        {
            author.Password = BC.HashPassword(author.Password);

            using (var db = new VidukaFiveNewsContext())
            {
                var newUser = new Author()
                {
                    Name = author.Name,
                    Email = author.Email,
                    Password = author.Password,
                };
                db.Authors.Add(newUser);

                db.SaveChanges();
            }
        }


        private string generateJwtToken(Author author)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", author.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
