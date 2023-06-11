using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PizzaRito.Entity;
using PizzaRito.Entity.Models;


namespace PizzaRito.ViewModels;

public partial class OrderViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
{

    [ObservableProperty]
    public List<Topping> allToppings;

    [ObservableProperty]
    public List<CrustSize> allSizes;


    [ObservableProperty]
    public List<Pizza> allPizzas;

    private Pizza pizzaDetail;
    public Pizza PizzaDetail {
        get => pizzaDetail;
        set { SetProperty(ref pizzaDetail, value); }
        }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        PizzaDetail = query["PizzaDetail"] as Pizza;
        OnPropertyChanged(nameof(PizzaDetail));
        //Console.WriteLine($"ApplyQueryAttributes=> {PizzaDetail} ");
    }

    public OrderViewModel(AppDbContext dbCtx):base()

    {

        AllToppings = dbCtx.Toppings.OrderBy(t => t.Name).ToList();
        AllSizes = dbCtx.CrustSizes.OrderBy(t => t.Name).ToList();
        //AllPizzas = dbCtx.Pizzas.OrderBy(e => e.Name).ToList();
        AllPizzas = dbCtx.Pizzas.OrderBy(p => p.Name).Include(p => p.Toppings).ToList();
    }


    [ObservableProperty]
    public static Order currentOrder = new Order
    {
        Id = Guid.NewGuid(),
        Items = new(),
    };

    

    //[ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
    //public ObservableCollection<Topping> allToppings = Topping.GetAvailableToppings();

    //[ObservableProperty]
    //public static Pizza newPizza = new() { Img = "placeholder.png", Toppings = new(), Size = new() };






    //[ObservableProperty]
    //public static Pizza newPizza = CurrentPizza??new();





    //[ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
    //public ObservableCollection<CrustSize> allSizes = CrustSize.GetAvailableSizes();

}

