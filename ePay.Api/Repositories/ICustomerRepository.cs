using ePay.Api.Models;

namespace ePay.Api.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task AddAsync(Customer customer);
    Task<bool> ExistsAsync(int id);
}
