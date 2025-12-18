using CommunityToolkit.Maui;
using MAUI_Uppgift.Services;
using MAUI_Uppgift.ViewModels;
using MAUI_Uppgift.Views;
using Microsoft.Extensions.Logging;

namespace MAUI_Uppgift
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<StandingViewModel>();
            builder.Services.AddTransient<StandingService>();
            builder.Services.AddTransient<TeamDetailsPage>();
            builder.Services.AddTransient<TeamViewModel>();
            builder.Services.AddTransient<TeamService>();
            builder.Services.AddTransient<GameViewModel>();
            builder.Services.AddTransient<GameService>();
            builder.Services.AddTransient<GameDetailPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
