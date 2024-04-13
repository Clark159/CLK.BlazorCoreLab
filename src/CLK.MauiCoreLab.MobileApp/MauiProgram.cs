using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CLK.MauiCoreLab.MobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // ApplicationBuilder
            var builder = MauiApp.CreateBuilder();
            {
                // Maui
                builder
                    .UseMauiApp<App>()
                    .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    });

                // Blazor
                builder.Services.AddMauiBlazorWebView();
                builder.Services.AddAuthorizationCore();
                builder.Services.AddScoped<AuthenticationStateProvider, ExternalAuthenticationStateProvider>();
                builder.Services.AddSingleton<SignInManager>();

                // Development
#if DEBUG
                builder.Services.AddBlazorWebViewDeveloperTools();
                builder.Logging.AddDebug();
#endif

                // Service
                builder.Services.AddSingleton<MessageService>();
            }

            // Application
            var app = builder.Build();
            {
                // ClaimsIdentity
                var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Clark"),
                    new Claim(ClaimTypes.Role, "Admin"),
                }
                , "TestAuth");

                // SignIn
                var signInManager = app.Services.GetRequiredService<SignInManager>();
                signInManager.SignInAsync(new ClaimsPrincipal(claimsIdentity));
            }

            // Return
            return app;
        }
    }
}
