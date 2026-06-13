using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface IProjectService
{
    Task<List<Project>> GetProjectsByWorkspaceAsync(int workspaceId);
    Task<Project?> GetProjectByIdAsync(int id);
    Task<int> CreateProjectAsync(Project project);
    Task<bool> UpdateProjectAsync(Project project);
    Task<bool> DeleteProjectAsync(int id);
    Task<bool> CalculateProjectCostsAsync(int projectId);
    Task<Project?> GetProjectWithResourcesAsync(int id);
}
