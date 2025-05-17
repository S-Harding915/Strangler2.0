using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Strangler2._0.Context;
using Strangler2._0.Data;
using Strangler2._0.Services;


namespace Strangler2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddMudServices();
            builder.Services.AddScoped<IBudgetService, BudgetService>();
         

            //dbcontext injection
            builder.Services.AddDbContextFactory<BudgetDbContext>(options =>
            {
                options.UseSqlServer("Server=LAPTOP-JTLV7VPG;Database=budget;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Encrypt=True; Integrated Security=true");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
