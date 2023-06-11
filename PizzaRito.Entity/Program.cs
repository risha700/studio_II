

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PizzaRito.Shared;

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
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlite(ProjectConfig.DatabasePath);
        return new AppDbContext(builder.Options);
    }
}
