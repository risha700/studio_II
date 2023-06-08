using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaRito.Entity;
using PizzaRito.Utilities;
using PizzaRito.ViewModels;
using PizzaRito.Views;

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
		// todo: as shared lib constant
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        string dbPath = System.IO.Path.Join(path, "MauiPizza.db");
        

        builder.Services.AddDbContext<AppDbContext>(opts=>opts.UseSqlite($"Data Source={dbPath}"));

		builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PizzaViewModel>();
        builder.Services.AddTransient<CheckoutPage>();
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddTransient<OrderPage>();
        builder.Services.AddSingleton<MenuPage>();
        var app = builder.Build();

        app.SeedDatabase();

		return app;
        //return builder.Build();
    }
}

