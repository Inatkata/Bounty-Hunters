using BountyHunters.Data;
using Microsoft.EntityFrameworkCore;

namespace BountyHunters.Web
{
    public class Program
    {
        public static async Task Main(string[] args)

        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SQLServer");

            // Add services to the container.
            builder.Services.AddDbContext<BountyHuntersDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using IServiceScope scope = app.Services.CreateScope();
            BountyHuntersDbContext? db = scope.ServiceProvider
                .GetService<BountyHuntersDbContext>();
            await db.Database.MigrateAsync();



            app.Run();
        }
    }
}
