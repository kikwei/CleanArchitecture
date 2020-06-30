using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Common.Interfaces
{
    public interface IProductsCleanArchDbContext
    {

        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
