using ITProjectCalculator.Data.Entities;
using ITProjectCalculator.Services.Interfaces;

namespace ITProjectCalculator.Services;

public class AuthenticationService : IAuthenticationService
{
    private User? _currentUser;

    public Task<User?> LoginAsync(string email, string password)
    {
        // TODO: Implement with actual database context
        // For now, return a test user
        _currentUser = new User
        {
            Id = 1,
            FirstName = "Test",
            LastName = "User",
            Email = email,
            Position = "Administrator",
            Roles = new List<string> { "GlobalAdmin" },
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        return Task.FromResult<User?>(_currentUser);
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
        // TODO: Implement with actual database context
        return Task.FromResult(false);
    }

    public Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        // TODO: Implement with actual database context
        return Task.FromResult(false);
    }
}
