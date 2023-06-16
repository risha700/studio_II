﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using PizzaRito.Entity.Models;
using PizzaRito.Utilities;
using PizzaRito.ViewModels;



namespace PizzaRito.Views;

public partial class MainPage : ContentPage
{
    Grid mainLayout = new Grid
    {
        RowDefinitions =
        {
            new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) } ,
            new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) }
        },
        ColumnDefinitions =
        {
            new ColumnDefinition { Width = GridLength.Star },
            
        },
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.Fill


    };

    Frame heroFrame = new Frame
    {
        //HeightRequest = 400,
        BackgroundColor = Colors.Orange,
        CornerRadius = 0,
        VerticalOptions = LayoutOptions.Start,
        HorizontalOptions = LayoutOptions.Fill,
        Padding = 0,
        BorderColor = Colors.Transparent,
        Background = Helpers.CreateGradient(),
        Content = new Image
        {
            Source = ImageSource.FromFile("mainvector.png"),
            Opacity = 0.4,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            Aspect = Aspect.Fill,
        }

    };




    Button guestOrderBtn = new Button
    {
        Text = "Start Order",
        VerticalOptions = LayoutOptions.Center,
        HorizontalOptions = LayoutOptions.Center,
        CornerRadius = 10,
        FontSize = 35,
        MinimumHeightRequest = 160,
        Shadow = new Shadow
        {
            Brush = Colors.Black,
            Offset = new(5, 7),
            Radius = 10,
            Opacity = (float)0.8

        }

    };





    FlexLayout mainOptions = new FlexLayout
    {
        Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
        JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround,
        AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
        AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Center,
        //WidthRequest = 400,
        Padding = 10

    };

    public MainPage()
    {
        Shell.SetNavBarIsVisible(this, false);
        

        Title = "Pizza Rito";

        mainLayout.SetColumnSpan(heroFrame, 2);
        mainLayout.SetColumnSpan(mainOptions, 2);
        
        mainOptions.Children.Add(guestOrderBtn);
        mainLayout.Add(heroFrame);
        mainLayout.Add(mainOptions, 0,1);

        




        guestOrderBtn.Clicked += async (sender, args) => {
            guestOrderBtn.IsEnabled = false;

            await Shell.Current.GoToAsync(nameof(MenuPage), true);
            guestOrderBtn.IsEnabled = true;
        };

        Content = mainLayout;
        BindingContext = this;

    }


}


