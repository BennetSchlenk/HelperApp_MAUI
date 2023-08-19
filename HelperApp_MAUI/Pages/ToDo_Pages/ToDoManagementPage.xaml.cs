using HelperApp_MAUI.DataService;
using HelperApp_MAUI.Models;
using System.Diagnostics;

namespace HelperApp_MAUI.Pages.ToDo_Pages;

[QueryProperty(nameof(Models.ToDo), "ToDo")]
public partial class ToDoManagementPage : ContentPage
{
    private readonly IRestDataService _dataService;
    ToDo _toDo;
    bool _isNew;

    public ToDo ToDo
    {
        get => _toDo;
        set
        {
            _isNew = _IsNew(value);
            _toDo = value;
            OnPropertyChanged();
        }
    }

    public ToDoManagementPage(IRestDataService dataService)
    {
        InitializeComponent();

        _dataService = dataService;
        BindingContext = this;
    }
    private bool _IsNew(ToDo value)
    {
        if (value.Id == 0)
        {
            return true;
        }
        return false;
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("--Deleted Todo--");

        await _dataService.DeleteToDoAsync(ToDo.Id);

        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("--Canceled Todo Management--");

        if (_isNew) 
        {
            await _dataService.DeleteToDoAsync(ToDo.Id);
        }

        await Shell.Current.GoToAsync("..");
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            Debug.WriteLine("--Added new Todo--");
            await _dataService.AddToDoAsync(ToDo);
        }
        else
        {
            Debug.WriteLine("--Updated Todo--");
            await _dataService.UpdateToDoAsync(ToDo);
        }

        await Shell.Current.GoToAsync("..");
    }

}