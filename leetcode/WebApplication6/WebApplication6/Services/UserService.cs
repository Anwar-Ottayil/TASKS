using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using WebApplication6.Interface;
using WebApplication6.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication6.Services
{

    public class UserService : IuserService
    {
        public readonly IConfiguration _configuration;


        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private readonly List<User> users = new List<User>()
        {
        new User{ id=1,Username="Anwar",Password="1234",Role="User",Email="xyz@gmail.com"},
        new User{ id=2,Username="Ameen",Password="4321",Role="User",Email="abc@gmail.com"}
        };
        public async Task<string> Login(string email, string password)
        {

        var isUser = users.FirstOrDefault(a => a.Email == email && a.Password == password);
        if (isUser==null)
            {
            return "User not found";
            }
            
            string jwtToken = Generate_Token(isUser);
        return jwtToken;
        }

        private string Generate_Token(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claim = new[]
            {
         new Claim(ClaimTypes.NameIdentifier ,user.id.ToString()),
         new Claim(ClaimTypes.Name,user.Username ),
         new Claim(ClaimTypes.Role,user.Role),
         new Claim(ClaimTypes.Email,user.Email)
     };

            var token = new JwtSecurityToken(
                claims: claim,
                signingCredentials: credentails,
                expires: DateTime.UtcNow.AddDays(1)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
