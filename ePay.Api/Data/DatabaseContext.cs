using ePay.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ePay.Api.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key to store in the required order
        modelBuilder.Entity<Customer>()
            .HasKey(p => new { p.LastName, p.FirstName, p.Id });
    }
}
