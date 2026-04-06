using Alumni_Portal.Models.RequestModels;

namespace Alumni_Portal.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateToken(LoginModel loginModel);
    }
}
