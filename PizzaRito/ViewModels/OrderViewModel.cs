using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

    JsonSerializerSettings serializerSettings = new JsonSerializerSettings
    {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
         
    };

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var PizzaParam = query["CurrentPizza"] as Pizza;
        CurrentPizza = JsonConvert.DeserializeObject<Pizza>(JsonConvert.SerializeObject(PizzaParam, serializerSettings), serializerSettings);
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

