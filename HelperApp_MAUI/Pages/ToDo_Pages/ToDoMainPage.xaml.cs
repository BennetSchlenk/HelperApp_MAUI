using HelperApp_MAUI.DataService;
using HelperApp_MAUI.Models;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace HelperApp_MAUI.Pages.ToDo_Pages;

public partial class ToDoMainPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public ToDoMainPage(IRestDataService dataService)
    {
        InitializeComponent();

        _dataService = dataService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        collectionView.ItemsSource = await _dataService.GetAllToDosAsync();
    }

    async void OnAddToDoClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("--Add Button clicked--");

        var navigationParam = new Dictionary<string, object>()
        {
            {nameof(ToDo), new ToDo() }
        };

        await Shell.Current.GoToAsync(nameof(ToDoManagementPage), navigationParam);
    }

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("--Selected Todo changed--");

        var navigationParam = new Dictionary<string, object>()
        {
            {nameof(ToDo), e.CurrentSelection.FirstOrDefault() as ToDo }
        };

        await Shell.Current.GoToAsync(nameof(ToDoManagementPage), navigationParam);
    }
}