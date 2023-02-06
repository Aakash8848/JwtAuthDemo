using LoginDemoProj.JwtAuthentication.Dto;

namespace LoginDemoProj.JwtAuthentication
{
    public interface IJwtAutheticationManager
    {
       string Authenticate(string UserName, string PassWord);
    }
}
