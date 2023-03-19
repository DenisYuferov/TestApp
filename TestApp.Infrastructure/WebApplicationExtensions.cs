using Microsoft.AspNetCore.Builder;

using TestApp.Infrastructure.Postgre;

namespace TestApp.Infrastructure
{
    public static class WebApplicationExtensions
    {
        public static void UseTestAppInfrastructure(this WebApplication application)
        {
            application.UsePostgreInfrastructure();
        }
    }
}