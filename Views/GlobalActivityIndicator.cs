namespace PizzaApp.Views;

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.ComponentModel;


public class GlobalActivityIndicator : ContentView
{
    private ActivityIndicator _activityIndicator;

    public ActivityIndicator activityIndicator {get;set;}

    public  GlobalActivityIndicator(dynamic BoundProperty)
    {
        activityIndicator = new ActivityIndicator
        {
            IsRunning = IsLoading,
            IsVisible = IsLoading,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill
        };
        BoundProperty.Add(activityIndicator);

    }

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public static readonly BindableProperty IsLoadingProperty =
        BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(GlobalActivityIndicator), false, propertyChanged: null);

    
}