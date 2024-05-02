using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Questor.Domain.Interface;
using Questor.Persistence.Context;
using Questor.Persistence.Repository;

namespace Questor.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services,
                                                   IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("questor");

            services.AddDbContext<AppDbContext>(op => op.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
        }
    }
}
