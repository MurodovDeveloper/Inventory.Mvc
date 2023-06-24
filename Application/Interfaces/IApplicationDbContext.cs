using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Order> Orders { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
