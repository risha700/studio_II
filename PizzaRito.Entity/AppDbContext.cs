using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PizzaRito.Entity.Models;

namespace PizzaRito.Entity;

public class AppDbContext:DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<CrustSize> CrustSizes{ get; set; }
    public DbSet<Topping> Toppings{ get; set; }
    public DbSet<Order> Orders{ get; set; }

    public string DbPath { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{
        
    }

    public AppDbContext() : base()
    {

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        string dbPath = System.IO.Path.Join(path, "MauiPizza.db");
        DbPath = dbPath;
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        base.OnConfiguring(optionsBuilder);
    }
}

