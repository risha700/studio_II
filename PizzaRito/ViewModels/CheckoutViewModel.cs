using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    // I am very concenrned about the right way of updating 3 nested relations on order
    // TODO: design needs a revisit.
    public void PersistOrder(Order order)
    {
        Console.WriteLine($"DEBUG ===> writing to db count {order.Items.Count()}");
        try
        {

            foreach (var pz in order.Items)
            {

                //databaseContext.Toppings.UpdateRange(pz.Toppings);
                //databaseContext.Entry(pz.Toppings).State = EntityState.Detached;

                var tp = pz.Toppings;
                var cs = pz.CrustSize; // manually assigning one to many implicit relationship
                pz.IsCatalouge = false; // internal
                pz.CrustSize = null;
                pz.Toppings = null;

                databaseContext.Pizzas.Add(pz);

                databaseContext.SaveChanges(); // :(

                var dbPizza = databaseContext.Pizzas.FirstOrDefault(i => i.Id == pz.Id);
                var dbCrustSize = databaseContext.CrustSizes.FirstOrDefault(c => c.Id == cs.Id);
                var dbToppings = databaseContext.Toppings.Where(t => tp.Contains(t)).ToList();
                //Console.WriteLine($"dbPizza===> {dbPizza} in pizza {pz}\n" +
                //    $"dbCrustSize==> {dbCrustSize} dbToppings ==> {dbToppings.Count()}");

                dbPizza.CrustSize = dbCrustSize;
                dbPizza.Toppings = new(dbToppings);

                databaseContext.SaveChanges(); // :((
            }

            // this suppose to be enoght alone, but!

            databaseContext.Orders.Add(order); 
            databaseContext.SaveChanges();
            databaseContext.ChangeTracker.Clear(); // neccessary to force reset the static tracker

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception saving to db ===> {ex.Message}\n {ex.InnerException}");

        }
      
    }

    
}

