using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PizzaRito.Entity.Models;
using PizzaRito.Shared;

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
        DbPath = ProjectConfig.DatabasePath;
    }

    public AppDbContext() : base()
    {
        DbPath = ProjectConfig.DatabasePath;

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ProjectConfig.DatabasePath);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Pizza>()
        //    .HasOne(p => p.Size)
        //    .WithMany("Toppings");
            
        base.OnModelCreating(modelBuilder);
    }
}

