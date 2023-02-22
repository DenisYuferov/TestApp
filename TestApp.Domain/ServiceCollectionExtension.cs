using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestApp.Domain.Mappers;
using TestApp.Domain.Validators;

namespace TestApp.Domain
{
    public static class ServiceCollectionExtension
    {
        public static void AddTestAppDomain(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddAutoMapper(typeof(AuthorMapper));
            services.AddAutoMapper(typeof(BookMapper));

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        }
    }
}