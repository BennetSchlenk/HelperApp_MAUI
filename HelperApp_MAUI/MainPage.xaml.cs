﻿using HelperApp_MAUI.DataService;
using HelperApp_MAUI.Models;
using HelperApp_MAUI.Pages.AppSelection_Pages;
using HelperApp_MAUI.Pages.Fitness_Pages;
using HelperApp_MAUI.Pages.Plant_Health_Pages;
using HelperApp_MAUI.Pages.Register_User_Pages;
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
        //TODO Implement Login verfification and Request jwt Token
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

