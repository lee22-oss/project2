using ITProjectCalculator.Data.Entities;
using ITProjectCalculator.Services.Interfaces;

namespace ITProjectCalculator.Services;

public class UserService : IUserService
{
    public Task<List<User>> GetAllUsersAsync()
    {
        // TODO: Implement with database context
        return Task.FromResult(new List<User>());
    }

    public Task<User?> GetUserByIdAsync(int id)
    {
        // TODO: Implement with database context
        return Task.FromResult<User?>(null);
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        // TODO: Implement with database context
        return Task.FromResult<User?>(null);
    }

    public Task<int> CreateUserAsync(User user)
    {
        // TODO: Implement with database context
        return Task.FromResult(0);
    }

    public Task<bool> UpdateUserAsync(User user)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }

    public Task<bool> DeleteUserAsync(int id)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }

    public Task<bool> AssignUserToWorkspaceAsync(int userId, int workspaceId, string permission)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }

    public Task<bool> RemoveUserFromWorkspaceAsync(int userId, int workspaceId)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }
}
