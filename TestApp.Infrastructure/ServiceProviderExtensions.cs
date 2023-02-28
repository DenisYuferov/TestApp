using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Infrastructure.DbContexts;
using TestApp.Infrastructure.Options;

namespace TestApp.WebApi
{
    public static class ServiceProviderExtensions
    {
        public static void UseTestAppInfrastructure(this IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var databaseOptions = configuration.GetSection(DatabaseOptions.Database).Get<DatabaseOptions>();
            if (databaseOptions?.InMemory != true)
            {
                using (var serviceScope = serviceProvider.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<PostgreDbContext>();
                    context?.Database.Migrate();
                }
            }
        }
    }
}