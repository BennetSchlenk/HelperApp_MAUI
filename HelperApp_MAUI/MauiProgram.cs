using HelperApp_MAUI.DataService;
using HelperApp_MAUI.Pages.ToDo_Pages;
using Microsoft.Extensions.Logging;

namespace HelperApp_MAUI;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IRestDataService, RestDataService>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ToDoManagementPage>();

        return builder.Build();
	}
}
