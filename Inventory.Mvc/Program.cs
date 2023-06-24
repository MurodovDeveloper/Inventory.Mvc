using Application;
using Infrastructure;
namespace Inventory.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews().AddNewtonsoftJson();
            builder.Services.AddDataConfiguration(builder.Configuration);
            builder.Services.AddStartup();
            builder.Services.AddApplication();
            builder.Services.AddAuthorization();
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}