using Microsoft.Extensions.DependencyInjection.Extensions;
using TestApp.Domain;
using TestApp.Infrastructure;
using TestApp.Infrastructure.Loggers;

namespace TestApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Logging.ClearProviders();
            builder.Logging.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, JsonLoggerProvider>());

            builder.Services.AddTestAppInfrastructure(builder.Configuration);
            builder.Services.AddTestAppDomain();

            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();

            builder.Services.AddHealthChecks();

            var app = builder.Build();

            app.Services.UseTestAppInfrastructure(app.Configuration);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseHealthChecks("/health");

            app.Run();
        }
    }
}