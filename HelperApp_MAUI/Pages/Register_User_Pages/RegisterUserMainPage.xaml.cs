using HelperApp_MAUI.Pages.AppSelection_Pages;
using System.Diagnostics;

namespace HelperApp_MAUI.Pages.Register_User_Pages;

public partial class RegisterUserMainPage : ContentPage
{
	public RegisterUserMainPage()
	{
		InitializeComponent();
	}

    void OnEntryTextChanged(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Entry value changed--");
#endif


    }

    void OnEntryCompleted(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Entered Value--");
#endif

    }

    async void LoginClicked(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Login clicked--");
#endif

        await Shell.Current.GoToAsync(nameof(AppSelectionMainPage));
    }

    async void RegisterClicked(object sender, EventArgs e)
    {
#if DEBUG
        Debug.WriteLine("--Register clicked--");
#endif

        await Shell.Current.GoToAsync(nameof(RegisterUserMainPage));
    }
}