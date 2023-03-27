using SharedCore.Infrastructure.Extensions;

using TestApp.Infrastructure;

namespace TestApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var domainAssembly = AppDomain.CurrentDomain.Load("TestApp.Domain");

            builder.AddSharedInfrastructure(domainAssembly);
            builder.AddTestAppInfrastructure(domainAssembly);

            var app = builder.Build();

            app.UseTestAppInfrastructure();
            app.UseSharedInfrastructure();

            app.Run();
        }
    }
}