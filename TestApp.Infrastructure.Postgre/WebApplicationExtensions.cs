using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using TestApp.Infrastructure.Postgre.DbContexts;
using TestApp.Infrastructure.Postgre.Options;

namespace TestApp.Infrastructure.Postgre
{
    public static class WebApplicationExtensions
    {
        public static void UsePostgreInfrastructure(this WebApplication application)
        {
            using (var serviceScope = application.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PostgreDbContext>();

                var databaseOptions = serviceScope.ServiceProvider.GetService<IOptions<DatabaseOptions>>();
                if (databaseOptions?.Value.InMemory == true)
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