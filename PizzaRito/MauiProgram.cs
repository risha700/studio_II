using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaRito.Entity;
using PizzaRito.Utilities;
using PizzaRito.ViewModels;
using PizzaRito.Views;
using PizzaRito.Shared;

namespace PizzaRito;

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
        builder.Services.AddDbContext<AppDbContext>(opts=>opts.UseSqlite(ProjectConfig.DatabasePath));

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MenuPage>();
        builder.Services.AddSingleton<OrderViewModel>();
        builder.Services.AddTransient<OrderPage>();
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddTransient<CheckoutPage>();
        var app = builder.Build();

        app.SeedDatabase();

        return app;
        
    }
}

