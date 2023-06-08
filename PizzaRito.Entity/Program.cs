

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace PizzaRito.Entity;

public static class Program
{
    public static void Main(string[] args)
    {
        //using var db = new AppDbContext();

        // Note: This sample requires the database to be created before running.
        //Console.WriteLine($"Database path: {db}.");
        
    }
}

public class DbContextMigrationFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        string dbPath = System.IO.Path.Join(path, "MauiPizza.db");
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        Console.WriteLine("From context migration:pathg ", dbPath);
        builder.UseSqlite($"Data Source={dbPath}");
        return new AppDbContext(builder.Options);
    }
}
