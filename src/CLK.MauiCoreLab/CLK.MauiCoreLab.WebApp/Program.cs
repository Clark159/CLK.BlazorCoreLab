using CLK.MauiCoreLab.WebApp.Components;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CLK.MauiCoreLab.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ApplicationBuilder
            var builder = WebApplication.CreateBuilder(args);
            {
                // Blazor
                builder.Services.AddRazorComponents()
                    .AddInteractiveServerComponents();

                // MVC
                builder.Services
                    .AddControllersWithViews();

                // Auth
                builder.Services
                    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();

                // Service
                builder.Services.AddSingleton<MessageService>();
            }

            // Application
            var app = builder.Build();
            {
                // Development
                if (app.Environment.IsDevelopment() == false)
                {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Static
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Routing
            app.UseRouting();
            {
                // Auth
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseAntiforgery();

                // Route - Razor
                app.MapRazorComponents<App>()
                   .AddInteractiveServerRenderMode()
                   .AddAdditionalAssemblies(typeof(CLK.MauiCoreLab.Pages._Imports).Assembly);

                // Route - MVC
                app.MapDefaultControllerRoute();
            }

            // Run
            app.Run();
        }
    }
}
