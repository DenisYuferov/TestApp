using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Domain.Model.Options;
using TestApp.Infrastructure.DbContexts;

namespace TestApp.WebApi
{
    public static class ServiceProviderExtensions
    {
        public static void UseTestAppInfrastructure(this IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var databaseOptions = configuration.GetSection(DatabaseOptions.Database).Get<DatabaseOptions>();
                
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PostgreDbContext>();

                if (databaseOptions?.InMemory == true)
                {
                    var seedModel = context?.GetSeedModel();

                    context?.Books.Add(seedModel?.Books?[0]!);
                    context?.Books.Add(seedModel?.Books?[1]!);

                    context?.Authors.Add(seedModel?.Author!);

                    context?.SaveChanges();
                }
                else
                {
                    context?.Database.Migrate();
                }
            }
        }
    }
}