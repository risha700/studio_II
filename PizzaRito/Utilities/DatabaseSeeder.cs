using System;
using Microsoft.EntityFrameworkCore;
using PizzaRito.Entity;
using PizzaRito.Entity.DatabaseSeeders;
using PizzaRito.Entity.Models;

namespace PizzaRito.Utilities;

public static class DatabaseSeeder
{
    public static void SeedDatabase(this MauiApp mauiApp)
    {
        try
        {
            using var scope = mauiApp.Services.CreateScope();
            var context = scope.ServiceProvider.GetService(typeof(AppDbContext)) as AppDbContext;
            if (context == null) return;
            //try

            //{
            //context.Database.EnsureDeleted();
            context.Database.Migrate();
            //    Console.WriteLine($"==>DEBUG: Migrated successfulluy ");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"==>DEBUG: contextdb cant migrate {e.Message}");
            //}

            var crustSizes = StoreDatabaseSeeder.CrustSizeToSeed.Where(a => !context.CrustSizes.Any(b => b.Name == a.Name));
            var toppings = StoreDatabaseSeeder.ToppingToSeed.Where(a => !context.Toppings.Any(b => b.Name == a.Name));
            var pizzas = StoreDatabaseSeeder.PizzaToSeed.Where(a => !context.Pizzas.Any(b => b.Name == a.Name))?.ToList();
            

            context.Toppings.AddRange(toppings);
            context.CrustSizes.AddRange(crustSizes);
            
            context.Pizzas.AddRange(pizzas);
            var t = toppings.FirstOrDefault();
            
            context.SaveChanges();
            


            Console.WriteLine($"Debug==> seeded successfully to: {context.DbPath}");

        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception{e.Message} {e.InnerException}");
        }
       

    }
}

