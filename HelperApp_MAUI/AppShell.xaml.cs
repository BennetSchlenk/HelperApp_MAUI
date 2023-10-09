using HelperApp_MAUI.Pages.Fitness_Pages;
using HelperApp_MAUI.Pages.Plant_Health_Pages;
using HelperApp_MAUI.Pages.Smart_Home_Pages;
using HelperApp_MAUI.Pages.ToDo_Pages;

namespace HelperApp_MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ToDoManagementPage), typeof(ToDoManagementPage));
        Routing.RegisterRoute(nameof(ToDoMainPage), typeof(ToDoMainPage));

        Routing.RegisterRoute(nameof(FitnessMainPage), typeof(FitnessMainPage));
        Routing.RegisterRoute(nameof(SmartHomeMainPage), typeof(SmartHomeMainPage));
        Routing.RegisterRoute(nameof(PlantHealthMainPage), typeof(PlantHealthMainPage));
    }
}
