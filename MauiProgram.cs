using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui;

namespace LoadingIndicatorSample;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
            .UseMauiCommunityToolkitMarkup();

        builder.Services.AddSingleton<StatusIndicatorManager>();
        builder.Services.AddTransient<MainPage>();

        return builder.Build();
    }
}