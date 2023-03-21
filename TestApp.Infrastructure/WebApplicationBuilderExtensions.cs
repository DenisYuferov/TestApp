using Microsoft.AspNetCore.Builder;

using TestApp.Infrastructure.PostgreDb;

namespace TestApp.Infrastructure
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddTestAppInfrastructure(this WebApplicationBuilder builder)
        {
            builder.AddPostgreDbInfrastructure();
        }
    }
}