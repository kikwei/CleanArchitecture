using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductsCleanArch.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Application.System.Commands.SeedSampleData;
using ProductsCleanArch.Infrastructure.Identity;

namespace ProductsCleanArch.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            // using (var scope = host.Services.CreateScope())
            // {
            //     var services = scope.ServiceProvider;

            //     try
            //     {
            //         var productsCleanArchContext = services.GetRequiredService<ProductsCleanArchDbContext>();
            //         productsCleanArchContext.Database.Migrate();

            //         var identityContext = services.GetRequiredService<ApplicationDbContext>();
            //         identityContext.Database.Migrate();

            //         var mediator = services.GetRequiredService<IMediator>();
            //         await mediator.Send(new SeedSampleDataCommand(), CancellationToken.None);
            //     }
            //     catch (Exception ex)
            //     {
            //         var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //         logger.LogError(ex, "An error occurred while migrating or initializing the database.");
            //     }
            // }

            host.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            var env = hostingContext.HostingEnvironment;

            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true);

            if (env.IsDevelopment())
            {
                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                if (appAssembly != null)
                {
                    config.AddUserSecrets(appAssembly, optional: true);
                }
            }

            config.AddEnvironmentVariables();

            if (args != null)
            {
                config.AddCommandLine(args);
            }
        })
        .UseStartup<Startup>();
    }
}
