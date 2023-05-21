using ePay.Api.Data;
using ePay.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ePay.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;

    public CustomerRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers
            .ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context
            .Customers
            .AnyAsync(c => c.Id == id);
    }
}
