using HelperApp_MAUI.Pages.ToDo_Pages;

namespace HelperApp_MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ToDoManagementPage), typeof(ToDoManagementPage));
        Routing.RegisterRoute(nameof(ToDoMainPage), typeof(ToDoMainPage));
    }
}
