using LoginDemoProj.JwtAuthentication.Dto;
using LoginDemoProj.Model;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginDemoProj.JwtAuthentication
{
    public class JwtAutheticationManager : IJwtAutheticationManager
    {
        private readonly LoginProfile _userManager;
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        { { "test1", "Password1"}, {"Test2","Password2"}};
        private readonly string key;

        public JwtAutheticationManager(
               LoginProfile LoginProfile  
               )
            : base()
        {
            this._userManager =  LoginProfile;

        }
        public JwtAutheticationManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(string UserName, string PassWord)
        {
            //if(_userManager.UserName != UserName && _userManager.Password != PassWord)
            //{
            //    return "null";
            //}
            if (!users.Any(u => u.Key == UserName && u.Value == PassWord))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            
        }
    }
}
