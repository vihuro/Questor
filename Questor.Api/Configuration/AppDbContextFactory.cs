using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Questor.Persistence.Context;

namespace Questor.Api.Configuration
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment
                                    .GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                                    ?? "Development";

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environmentName}.json")
                .Build();

            var assemblyName = typeof(AppDbContext).Namespace;

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(config.GetConnectionString("questor"),
                                                        b => b.MigrationsAssembly("Questor.Persistence")).Options;

            return new AppDbContext(builder);
        }
    }
}
