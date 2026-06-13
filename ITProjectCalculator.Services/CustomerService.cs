using ITProjectCalculator.Data.Entities;
using ITProjectCalculator.Services.Interfaces;

namespace ITProjectCalculator.Services;

public class CustomerService : ICustomerService
{
    public Task<List<Customer>> GetAllCustomersAsync()
    {
        // TODO: Implement with database context
        return Task.FromResult(new List<Customer>());
    }

    public Task<Customer?> GetCustomerByIdAsync(int id)
    {
        // TODO: Implement with database context
        return Task.FromResult<Customer?>(null);
    }

    public Task<int> CreateCustomerAsync(Customer customer)
    {
        // TODO: Implement with database context
        return Task.FromResult(0);
    }

    public Task<bool> UpdateCustomerAsync(Customer customer)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }

    public Task<bool> DeleteCustomerAsync(int id)
    {
        // TODO: Implement with database context
        return Task.FromResult(false);
    }
}
