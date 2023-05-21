using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TestApp.Infrastructure.MongoDb.Options;
using TestApp.Infrastructure.MongoDb.Repositories;

namespace TestApp.Infrastructure.PostgreDb
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddMongoDbInfrastructure(this WebApplicationBuilder builder)
        {
            AddDatabaseInfrastructure(builder.Services, builder.Configuration);
        }

        private static void AddDatabaseInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            var databaseSection = configuration.GetSection(DatabaseOptions.SectionName);
            services.Configure<DatabaseOptions>(databaseSection);

            services.AddSingleton<BookRepository>();
        }
    }
}