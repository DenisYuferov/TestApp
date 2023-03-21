using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TestApp.Domain.Abstraction.PostgreDb.Repositories;
using TestApp.Domain.Abstraction.PostgreDb.UnitOfWorks;
using TestApp.Infrastructure.PostgreDb.Contexts;
using TestApp.Infrastructure.PostgreDb.Options;
using TestApp.Infrastructure.PostgreDb.Repositories;
using TestApp.Infrastructure.PostgreDb.UnitOfWorks;

namespace TestApp.Infrastructure.PostgreDb
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPostgreDbInfrastructure(this WebApplicationBuilder builder)
        {
            AddDatabaseInfrastructure(builder.Services, builder.Configuration);
        }

        private static void AddDatabaseInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            var databaseOptions = ConfigureDatabaseOptions(services, configuration);
            if (databaseOptions?.InMemory == true)
            {
                ConfigureInMemoryDatabase(services, databaseOptions);
            }
            else
            {
                services.AddDbContext<TestAppDbContext>(opt => opt.UseNpgsql(databaseOptions?.Connection));
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

            services.AddDbContext<TestAppDbContext>(opt => opt.UseInMemoryDatabase(dbName!));
        }
    }
}