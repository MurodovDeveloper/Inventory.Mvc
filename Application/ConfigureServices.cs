using Application.Interfaces;
using Application.Sevices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddScoped<IHashStringService, HashStringService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(option =>
            {
                option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());


            });

            return services;
        }
    }
}