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
        CurrentPizza = query["CurrentPizza"] as Pizza;
        //Console.WriteLine($"DEBUG===> OrderViewModel Assigned pizza param {CurrentPizza}-{CurrentPizza.Id}");

        //OnPropertyChanged(nameof(CurrentPizza));

    }



    public OrderViewModel(AppDbContext dbCtx)

    {

        AllToppings = dbCtx.Toppings.OrderBy(t => t.Name).ToList();
        AllSizes = dbCtx.CrustSizes.OrderBy(t => t.Name).ToList();
        AllPizzas = dbCtx.Pizzas.OrderBy(p => p.Name).Include(p => p.Size).Include(p => p.Toppings).ToList();
        CurrentPizza = new Pizza { Size = new(), Toppings = new() };
        
    }

    public void reset()
    {
        CurrentPizza = new Pizza {Id=Guid.NewGuid(), Size = new(), Toppings = new() };
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

