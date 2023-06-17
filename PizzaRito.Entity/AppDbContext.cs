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
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Pizza>()
        //    .HasOne(p => p.Size!);
        //modelBuilder.Entity<Pizza>()
        //    .HasMany(oi => oi.Orders);
        ////.WithMany("Toppings");
        //modelBuilder.Entity<Order>()
        //    .HasMany(o => o.Items).WithMany("Toppings");

        //modelBuilder.Entity<CrustSize>()
        //             .Property(c => c.Id)
        //             .ValueGeneratedNever();
        modelBuilder.Entity<Order>()
           .HasMany(o => o.Items)
           .WithMany(p => p.Orders)
           .UsingEntity<Dictionary<string, object>>(
               "OrderPizza",
               j => j.HasOne<Pizza>().WithMany().HasForeignKey("ItemsId"),
               j => j.HasOne<Order>().WithMany().HasForeignKey("OrdersId"),
               j =>
               {
                   //j.Property<DateTime>("OrderDate").HasDefaultValueSql("CURRENT_TIMESTAMP");
                   j.HasKey("ItemsId", "OrdersId");
               });

        //modelBuilder.Entity<Pizza>()
        //    .HasOne(p => p.Size).WithMany().HasForeignKey("SizeId").OnDelete(DeleteBehavior.Cascade);
        //    .HasMany(p => p.Toppings)
        //    .WithMany()
        //    .UsingEntity<Dictionary<string, object>>(
        //        "PizzaTopping",
        //        j => j.HasMany<Topping>().WithMany().has("ToppingId"),
        //        j => j.HasOne<Pizza>().WithMany().HasForeignKey("PizzaId"),
        //        j =>
        //        {
        //            j.HasKey("PizzaId", "ToppingId");
        //        });
        base.OnModelCreating(modelBuilder);
    }
}

