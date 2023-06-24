using Application.Interfaces;
using Inventory.Mvc.Services;
namespace Inventory.Mvc
{
    public static class Startup
    {
        public static IServiceCollection AddStartup(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUserService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
