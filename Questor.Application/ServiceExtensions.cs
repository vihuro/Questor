using Microsoft.Extensions.DependencyInjection;
using Questor.Application.Interface;
using Questor.Application.Services;
using Questor.Domain.Aux.Interfaces;
using Questor.Domain.Aux.Service;
using System.Reflection;

namespace Questor.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<INotification, NotificationService>();
            services.AddScoped<ITickerService, TickerService>();
        }
    }
}
