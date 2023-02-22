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
    public static class ServiceCollectionExtension
    {
        public static void AddTestAppInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            var databaseSection = configuration.GetSection(DatabaseOptions.Database);
            services.Configure<DatabaseOptions>(databaseSection);

            var databaseOptions = databaseSection.Get<DatabaseOptions>();
            services.AddDbContext<TestAppInMemoryDbContext>(opt => opt.UseInMemoryDatabase(databaseOptions?.Name!));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}