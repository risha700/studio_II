using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PizzaRito.Entity;
using PizzaRito.Entity.Models;


namespace PizzaRito.ViewModels;




public partial class CheckoutViewModel:BaseViewModel
{
    AppDbContext databaseContext;


    public CheckoutViewModel(AppDbContext dbContext):base()
	{
        databaseContext = dbContext;
    }

    public void PersistOrder(Order order)
    {
        Console.WriteLine($"lets write to db==>{order.Items.Count()}");
        try
        {
            //databaseContext.ChangeTracker.Clear();
            //databaseContext.Orders.Local.
            //databaseContext.Entry(order).State = EntityState.Detached;
            //order.Items.FirstOrDefault().Size = null;
            var pizza_qs = order.Items.ToList();

            //order.Items.Clear();
            databaseContext.Pizzas.AttachRange(order.Items);
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
            databaseContext.ChangeTracker.Clear();

            //var orderFromDb = databaseContext.Orders.FirstOrDefault(o => o.Id == order.Id);
            //foreach (var pz in pizza_qs)
            //{
            //    databaseContext.Pizzas.Attach(pz);

            //    //databaseContext.Toppings.AttachRange(pz.Toppings);

            //    orderFromDb.Items.Add(pz);

            //}
            //databaseContext.Update(orderFromDb);
            //databaseContext.SaveChanges();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception saving==>{ex.Message}\n {ex.InnerException}");

        }
      
    }

    
}

