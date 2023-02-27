using Microsoft.EntityFrameworkCore;
using TestApp.Infrastructure.DbContexts;
using TestApp.Infrastructure.Options;

namespace TestApp.WebApi
{
    public static class WebApplicationExtensions
    {
        public static void UseTestAppInfrastructure(this WebApplication application)
        {
            var databaseOptions = application.Configuration.GetSection(DatabaseOptions.Database).Get<DatabaseOptions>();
            if (databaseOptions?.InMemory != true)
            {
                using (var serviceScope = application.Services.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<PostgreDbContext>();
                    context?.Database.Migrate();
                }
            }
        }
    }
}