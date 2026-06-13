using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface IWorkspaceService
{
    Task<List<Workspace>> GetAllWorkspacesAsync();
    Task<Workspace?> GetWorkspaceByIdAsync(int id);
    Task<Workspace?> GetWorkspaceBySubdomainAsync(string subdomain);
    Task<List<Workspace>> GetUserWorkspacesAsync(int userId);
    Task<int> CreateWorkspaceAsync(Workspace workspace);
    Task<bool> UpdateWorkspaceAsync(Workspace workspace);
    Task<bool> DeleteWorkspaceAsync(int id);
    Task<bool> AddProjectToWorkspaceAsync(int workspaceId, int projectId);
}
