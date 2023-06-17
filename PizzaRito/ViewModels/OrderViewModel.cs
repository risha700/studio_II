using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzaRito.Entity;
using PizzaRito.Entity.Models;
using PizzaRito.Utilities;
using PizzaRito.Views;

namespace PizzaRito.ViewModels;

public partial class OrderViewModel : BaseViewModel, IQueryAttributable
{
    AppDbContext databaseContext;
    [ObservableProperty]
    public List<Topping> allToppings;

    [ObservableProperty]
    public List<CrustSize> allSizes;


    [ObservableProperty]
    public List<Pizza> allPizzas;

    //[ObservableProperty]
    private Pizza currentPizza;
    public Pizza CurrentPizza
    {
        get => currentPizza;
        set => SetProperty(ref currentPizza, value);
    }


    [ObservableProperty]
    public static Order currentOrder = new Order
    {
        Id = Guid.NewGuid(),
        Items = new(),
    };


    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var PizzaParam = query["CurrentPizza"] as Pizza;
        //databaseContext.Pizzas.OrderBy(p => p.Name).Include(t => t.Toppings).Include(s => s.Size).Load();

        //var pizzaOutCtx =  databaseContext.Pizzas.Local.FirstOrDefault(p => p.Id == PizzaParam.Id);
        //databaseContext.Entry(pizzaOutCtx).State = EntityState.Detached;

        //var sizeOutCtx = databaseContext.CrustSizes.Local.FirstOrDefault(s => pizzaOutCtx.Size.Id == s.Id);
        //databaseContext.Entry(sizeOutCtx).State = EntityState.Detached;

        //var toppingsToUntrack = databaseContext.Toppings.Local.Where(t => pizzaOutCtx.Toppings.ToList().Contains(t));
        //foreach(Topping t in toppingsToUntrack)
        //{
        //    databaseContext.Entry(t).State = EntityState.Detached;

        //}

        CurrentPizza = Helpers.DeepCopy(PizzaParam);
        //OnPropertyChanged(nameof(CurrentPizza));

    }



    public OrderViewModel(AppDbContext dbCtx)

    {
        databaseContext = dbCtx;
        AllToppings = databaseContext.Toppings.AsNoTracking().OrderBy(t => t.Name).ToList();
        AllSizes = databaseContext.CrustSizes.AsNoTracking().OrderBy(t => t.Name).ToList();
        AllPizzas = databaseContext.Pizzas.AsNoTracking().OrderBy(p => p.Name).Include(p => p.Size).Include(p => p.Toppings).ToList();
        CurrentPizza = new Pizza { Size = new(), Toppings = new() };
        
    }

    public void reset()
    {
        CurrentPizza = null;// = new Pizza {Id=Guid.NewGuid(), Size = new(), Toppings = new() };
        OnPropertyChanged(nameof(CurrentPizza));

    }
    

    ~OrderViewModel()
    {
        Console.WriteLine($"DEBUG===> OrderViewModel finalizer dipose");
    }


    //[ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
    //public ObservableCollection<Topping> allToppings = Topping.GetAvailableToppings();


}

