using LoginDemoProj.JwtAuthentication;
using LoginDemoProj.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace LoginDemoProj.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginProfileController : Controller
    {
        private readonly IConfiguration configuration;

        
        private readonly IJwtAutheticationManager jwtAutheticationManager;
        //public LoginProfileController(IConfiguration configuration, IJwtAutheticationManager jwtAutheticationManager)
        //{
        //    this.configuration = configuration;
        //}

        public LoginProfileController(IJwtAutheticationManager jwtAutheticationManager)
        {
            this.jwtAutheticationManager = jwtAutheticationManager;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "https://www.facebook.com" };
        }
        [HttpGet ("{id}", Name ="Get")]
        public string Get(int id)
        {
            return "value";
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginProfile loginProfile)
        {
            var token = jwtAutheticationManager.Authenticate(loginProfile.UserName, loginProfile.Password);
            if(token == null)
            {
                return Unauthorized();
            }
            else
            return Ok(token);
        }
    }
}
