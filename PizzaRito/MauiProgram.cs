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
        // todo: as shared lib constant
        //var folder = Environment.SpecialFolder.LocalApplicationData;
        //var path = Environment.GetFolderPath(folder);
        ////var path = FileSystem.Current.AppDataDirectory;
        //string dbPath = System.IO.Path.Join(path, "MauiPizza.db");
        //builder.Services.AddDbContext<AppDbContext>(opts=>opts.UseSqlite($"Data Source={dbPath}"));
        builder.Services.AddDbContext<AppDbContext>(opts=>opts.UseSqlite(ProjectConfig.DatabasePath));

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MenuPage>();
        builder.Services.AddTransient<OrderViewModel>();
        builder.Services.AddTransient<OrderPage>();
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddTransient<CheckoutPage>();
        var app = builder.Build();

        app.SeedDatabase();

        return app;
        //return builder.Build();
    }
}

