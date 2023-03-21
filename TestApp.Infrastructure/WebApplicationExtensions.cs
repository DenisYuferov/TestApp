using Microsoft.AspNetCore.Builder;

using TestApp.Infrastructure.PostgreDb;

namespace TestApp.Infrastructure
{
    public static class WebApplicationExtensions
    {
        public static void UseTestAppInfrastructure(this WebApplication application)
        {
            application.UsePostgreDbInfrastructure();
        }
    }
}