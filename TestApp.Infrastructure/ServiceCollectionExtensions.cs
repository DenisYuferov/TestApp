using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TestApp.Domain.Abstraction.Repositories;
using TestApp.Domain.Abstraction.UnitOfWorks;
using TestApp.Domain.Model.Options;
using TestApp.Infrastructure.DbContexts;
using TestApp.Infrastructure.Repositories;
using TestApp.Infrastructure.UnitOfWorks;

namespace TestApp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestAppInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseInfrastructure(services, configuration);

            AddAuthentication(services, configuration);

            services.AddAuthorization();
        }
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
                                  "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                                  "Example: \"Bearer 1safsfsdfdfd\""
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme { Reference = new OpenApiReference {  Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                        new string[] {}
                    }
                });
            });
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection(JwtOptions.Jwt);
            services.Configure<JwtOptions>(jwtSection);

            var jwtOptions = jwtSection.Get<JwtOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = jwtOptions?.Audience,
                        ValidIssuer = jwtOptions?.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.SecurityKey!))
                    };
                });
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