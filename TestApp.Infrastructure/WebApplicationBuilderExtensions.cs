using Microsoft.AspNetCore.Builder;

using TestApp.Infrastructure.Postgre;

namespace TestApp.Infrastructure
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddTestAppInfrastructure(this WebApplicationBuilder builder)
        {
            builder.AddPostgreInfrastructure();
        }
    }
}