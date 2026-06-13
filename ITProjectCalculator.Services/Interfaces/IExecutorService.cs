using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface IExecutorService
{
    Task<List<Executor>> GetAllExecutorsAsync();
    Task<Executor?> GetExecutorByIdAsync(int id);
    Task<int> CreateExecutorAsync(Executor executor);
    Task<bool> UpdateExecutorAsync(Executor executor);
    Task<bool> DeleteExecutorAsync(int id);
    Task<decimal> CalculateExecutorServiceCostAsync(int executorServiceId, decimal quantity);
    Task<List<ExecutorService>> GetExecutorServicesAsync(int executorId);
}
