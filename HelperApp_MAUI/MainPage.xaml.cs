using HelperApp_MAUI.DataService;
using HelperApp_MAUI.Models;
using HelperApp_MAUI.Pages.Fitness_Pages;
using HelperApp_MAUI.Pages.Plant_Health_Pages;
using HelperApp_MAUI.Pages.Smart_Home_Pages;
using HelperApp_MAUI.Pages.ToDo_Pages;
using System.Diagnostics;

namespace HelperApp_MAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    async void OnToDoSubAppClicked(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Button clicked--");
#endif

        await Shell.Current.GoToAsync(nameof(ToDoMainPage));
    }

    async void OnFitnessSubAppClicked(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Fitness clicked--");
#endif

        await Shell.Current.GoToAsync(nameof(FitnessMainPage));
    }

    async void OnSmartHomeSubAppClicked(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Smart Home clicked--");
#endif

        await Shell.Current.GoToAsync(nameof(SmartHomeMainPage));
    }

    async void OnPlantHealthSubAppClicked(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Plant Health clicked--");
#endif

        await Shell.Current.GoToAsync(nameof(PlantHealthMainPage));
    }
}

