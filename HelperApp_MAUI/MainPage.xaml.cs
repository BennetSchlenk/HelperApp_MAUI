using HelperApp_MAUI.DataService;
using HelperApp_MAUI.Models;
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
        Debug.WriteLine("--Button clicked--");

        await Shell.Current.GoToAsync(nameof(ToDoMainPage));
    }
}

