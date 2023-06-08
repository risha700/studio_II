using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaRito.Entity;
using PizzaRito.Utilities;

namespace PizzaRito;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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
        var app = builder.Build();

        app.SeedDatabase();

		return app;
        //return builder.Build();
    }
}

