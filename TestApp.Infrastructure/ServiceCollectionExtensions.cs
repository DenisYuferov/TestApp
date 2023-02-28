using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Infrastructure.DbContexts;
using TestApp.Infrastructure.Options;
using TestApp.Infrastructure.Repositories;
using TestApp.Infrastructure.Repositories.Abstractions;
using TestApp.Infrastructure.UnitOfWorks;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestAppInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseOptions = ConfigureDatabaseOptions(services, configuration);
            if (databaseOptions?.InMemory == true)
            {
                ConfigureInMemoryDatabase(services, databaseOptions);
            }
            else
            {
                services.AddDbContext<PostgreDbContext>(opt => opt.UseNpgsql(databaseOptions?.Connection));
            }

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static DatabaseOptions? ConfigureDatabaseOptions(IServiceCollection services, IConfiguration configuration)
        {
            var databaseSection = configuration.GetSection(DatabaseOptions.Database);
            services.Configure<DatabaseOptions>(databaseSection);

            var databaseOptions = databaseSection.Get<DatabaseOptions>();

            return databaseOptions;
        }

        private static void ConfigureInMemoryDatabase(IServiceCollection services, DatabaseOptions databaseOptions)
        {
            var dbName = databaseOptions?.Connection?
                .Split(";").First(cp => cp.Contains(DatabaseOptions.Database))
                .Split("=").First(dp => !dp.Contains(DatabaseOptions.Database));

            services.AddDbContext<PostgreDbContext>(opt => opt.UseInMemoryDatabase(dbName!));
        }
    }
}