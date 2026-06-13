using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface IAuthenticationService
{
    Task<User?> LoginAsync(string email, string password);
    Task<bool> LogoutAsync();
    Task<User?> GetCurrentUserAsync();
    Task<bool> RegisterAsync(User user, string password);
    Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
}
