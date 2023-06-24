using Application.Interfaces;
using Domain.Models;
using Infrastructure.DataAcces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{
    public static class DataConfigureServices
    {
        public static IServiceCollection AddDataConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, InventoryDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
            });
            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<InventoryDbContext>()
            .AddDefaultTokenProviders();

              //.AddEntityFrameworkStores<InventoryDbContext>();

            return services;
        }
    }
}