using System.Reflection;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SharedCore.Model.Options;

using TestApp.Infrastructure.PostgreDb;

namespace TestApp.Infrastructure
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddTestAppInfrastructure(this WebApplicationBuilder builder, Assembly? domainAssembly = null)
        {
            builder.AddPostgreDbInfrastructure();
            builder.AddMongoDbInfrastructure();

            AddMassTransit(builder, domainAssembly);
        }

        private static void AddMassTransit(WebApplicationBuilder builder, Assembly? domainAssembly)
        {
            var section = builder.Configuration.GetSection(MassTransitOptions.MassTransit);
            builder.Services.Configure<MassTransitOptions>(section);

            var options = section.Get<MassTransitOptions>();

            builder.Services.AddMassTransit(regConf =>
            {
                regConf.AddConsumers(domainAssembly);

                regConf.UsingRabbitMq((context, factoryConf) =>
                {
                    factoryConf.Host(options?.Host, options?.VirtualHost, h =>
                    {
                        h.Username(options?.Username);
                        h.Password(options?.Password);
                    });

                    factoryConf.ConfigureEndpoints(context);
                });
            });
        }
    }
}