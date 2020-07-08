using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Common;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Common;

namespace ProductsCleanArch.Persistence
{
    public class ProductsCleanArchDbContext : DbContext, IProductsCleanArchDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        // public ProductsCleanArchDbContext(DbContextOptions<ProductsCleanArchDbContext> options)
        //     : base(options)
        // {
        // }

        public ProductsCleanArchDbContext(
            DbContextOptions<ProductsCleanArchDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }


        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsCleanArchDbContext).Assembly);
        }
    }
}
