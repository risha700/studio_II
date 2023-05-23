using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp.Models;


namespace PizzaApp.ViewModels
{
    //[QueryProperty(nameof(Pizza), "currentPizza")]
    public partial class PizzaViewModel : BaseViewModel
    {

        //[ObservableProperty]
        //Pizza currentPizza;

        //[ObservableProperty]
        //private Pizza currentPizza;

        public PizzaViewModel()
        {
            //if (String.IsNullOrEmpty(CurrentPizza.Name))
            //{
            //    //newPizza = CurrentPizza;
            //}
        }


        [ObservableProperty]
        public static Order currentOrder = new()
        {
            Id = Guid.NewGuid(),
            Items = new()
        };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
        public ObservableCollection<Topping> allToppings = Topping.GetAvailableToppings();


        [ObservableProperty]
        public static Pizza newPizza = new() { Img = "placeholder.png", Toppings = new(), Size = new() };
        //[ObservableProperty]
        //public static Pizza newPizza = CurrentPizza??new();





        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
        public ObservableCollection<CrustSize> allSizes = CrustSize.GetAvailableSizes();
        
    }


}

