namespace Alumni_Portal.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateToken(string userName, string email);
    }
}
