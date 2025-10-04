using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterDALServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LinkHubDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
