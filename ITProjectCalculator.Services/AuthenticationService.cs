using ITProjectCalculator.Data.Entities;
using ITProjectCalculator.Services.Interfaces;

namespace ITProjectCalculator.Services;

public class AuthenticationService : IAuthenticationService
{
    // TODO: Implement with actual authentication logic
    private User? _currentUser;

    public Task<User?> LoginAsync(string email, string password)
    {
        // TODO: Implement login logic
        return Task.FromResult<User?>(null);
    }

    public Task<bool> LogoutAsync()
    {
        _currentUser = null;
        return Task.FromResult(true);
    }

    public Task<User?> GetCurrentUserAsync()
    {
        return Task.FromResult(_currentUser);
    }

    public Task<bool> RegisterAsync(User user, string password)
    {
        // TODO: Implement registration logic
        return Task.FromResult(false);
    }

    public Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        // TODO: Implement password change logic
        return Task.FromResult(false);
    }
}
