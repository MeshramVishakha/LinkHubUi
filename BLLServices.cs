using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterBLLServices(this IServiceCollection services, string connectionString)
        {
            
            // Register DAL services with the provided connection string
            services.RegisterDALServices(connectionString);

            // Register BLL services
            services.AddTransient<ICategoryDb, CategoryDb>();
            services.AddTransient<ILHUrlDb, LHUrlDb>();
            services.AddTransient<IUserDb, UserDb>();
            return services;
        }
    }
}
