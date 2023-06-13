using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PizzaRito.Entity;
using PizzaRito.Entity.Models;
using PizzaRito.Views;

namespace PizzaRito.ViewModels;

public partial class OrderViewModel : BaseViewModel, IQueryAttributable
{

    [ObservableProperty]
    public List<Topping> allToppings;

    [ObservableProperty]
    public List<CrustSize> allSizes;


    [ObservableProperty]
    public List<Pizza> allPizzas;

    [ObservableProperty]
    public Pizza currentPizza;


    [ObservableProperty]
    public static Order currentOrder = new Order
    {
        Id = Guid.NewGuid(),
        Items = new(),
    };



    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        CurrentPizza = query["CurrentPizza"] as Pizza;
        //OnPropertyChanged(nameof(CurrentPizza));
        
    }



    public OrderViewModel(AppDbContext dbCtx)

    {

        AllToppings = dbCtx.Toppings.OrderBy(t => t.Name).ToList();
        AllSizes = dbCtx.CrustSizes.OrderBy(t => t.Name).ToList();
        //AllPizzas = dbCtx.Pizzas.OrderBy(e => e.Name).ToList();
        AllPizzas = dbCtx.Pizzas.OrderBy(p => p.Name).Include(p => p.Size).Include(p => p.Toppings).ToList();
        //dbCtx.Pizzas.OrderBy(p => p.Name).Include(p => p.Toppings).Include(p => p.Size).Load();
        //AllPizzas = dbCtx.Pizzas.ToList();
        CurrentPizza = new Pizza { Size = new(), Toppings = new() };
    }




    ~OrderViewModel()
    {
        Console.WriteLine($"DEBUG===> OrderViewModel finalizer dipose");
    }


    //[ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
    //public ObservableCollection<Topping> allToppings = Topping.GetAvailableToppings();


}

