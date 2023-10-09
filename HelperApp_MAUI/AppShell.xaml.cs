using HelperApp_MAUI.Pages.AppSelection_Pages;
using HelperApp_MAUI.Pages.Fitness_Pages;
using HelperApp_MAUI.Pages.Plant_Health_Pages;
using HelperApp_MAUI.Pages.Register_User_Pages;
using HelperApp_MAUI.Pages.Smart_Home_Pages;
using HelperApp_MAUI.Pages.ToDo_Pages;

namespace HelperApp_MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(RegisterUserMainPage), typeof(RegisterUserMainPage));

        Routing.RegisterRoute(nameof(AppSelectionMainPage), typeof(AppSelectionMainPage));

        Routing.RegisterRoute(nameof(ToDoMainPage), typeof(ToDoMainPage));
        Routing.RegisterRoute(nameof(ToDoManagementPage), typeof(ToDoManagementPage));

        Routing.RegisterRoute(nameof(FitnessMainPage), typeof(FitnessMainPage));
        Routing.RegisterRoute(nameof(SmartHomeMainPage), typeof(SmartHomeMainPage));
        Routing.RegisterRoute(nameof(PlantHealthMainPage), typeof(PlantHealthMainPage));
    }
}
