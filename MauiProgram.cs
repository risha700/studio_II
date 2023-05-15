﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PizzaApp.ViewModels;
using PizzaApp.Views;

namespace PizzaApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<MenuPage>();
        builder.Services.AddSingleton<Helpers>();
        builder.Services.AddSingleton<GlobalActivityIndicator>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PizzaViewModel>();
        builder.Services.AddTransient<CheckoutPage>();
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddTransient<OrderPage>();


        return builder.Build();
	}
}

