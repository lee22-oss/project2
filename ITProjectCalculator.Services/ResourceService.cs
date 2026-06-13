using ITProjectCalculator.Data.Entities;
using ITProjectCalculator.Services.Interfaces;

namespace ITProjectCalculator.Services;

public class ResourceService : IResourceService
{
    public Task<List<ProjectResource>> GetProjectResourcesAsync(int projectId)
    {
        // TODO: Implement with database context
        return Task.FromResult(new List<ProjectResource>());
    }

    public Task<ProjectResource?> GetResourceByIdAsync(int id)
    {
        // TODO: Implement with database context
        return Task.FromResult<ProjectResource?>(null);
    }

    public Task<int> CreateResourceAsync(ProjectResource resource)
    {
        // TODO: Implement with database context
        return Task.FromResult(0);
    }

    public Task<bool> UpdateResourceAsync(ProjectResource resource)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }

    public Task<bool> DeleteResourceAsync(int id)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }

    public Task<decimal> CalculateResourceCostAsync(int resourceId)
    {
        // TODO: Implement calculation logic
        return Task.FromResult(0m);
    }
}
