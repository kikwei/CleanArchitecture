using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsCleanArch.Application.Common.Interfaces;

namespace ProductsCleanArch.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductsCleanArchDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProductsCleanArchDatabase")));

            // services.AddScoped<IProductsCleanArchDbContext>(provider => provider.GetService<ProductsCleanArchDbContext>());

            services.AddScoped<IProductsCleanArchDbContext, ProductsCleanArchDbContext>();

            return services;
        }
    }
}
