using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface IResourceService
{
    Task<List<ProjectResource>> GetProjectResourcesAsync(int projectId);
    Task<ProjectResource?> GetResourceByIdAsync(int id);
    Task<int> CreateResourceAsync(ProjectResource resource);
    Task<bool> UpdateResourceAsync(ProjectResource resource);
    Task<bool> DeleteResourceAsync(int id);
    Task<decimal> CalculateResourceCostAsync(int resourceId);
}
