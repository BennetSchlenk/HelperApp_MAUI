using HelperApp_MAUI.DataService;
using HelperApp_MAUI.Pages.Fitness_Pages;
using HelperApp_MAUI.Pages.Plant_Health_Pages;
using HelperApp_MAUI.Pages.Smart_Home_Pages;
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

        builder.Services.AddTransient<ToDoMainPage>();
        builder.Services.AddTransient<ToDoManagementPage>();

        builder.Services.AddTransient<FitnessMainPage>();
        builder.Services.AddTransient<SmartHomeMainPage>();
        builder.Services.AddTransient<PlantHealthMainPage>();



        return builder.Build();
	}
}
