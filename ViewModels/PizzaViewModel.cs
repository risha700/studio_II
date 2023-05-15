using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp.Models;


namespace PizzaApp.ViewModels
{

    public partial class PizzaViewModel : BaseViewModel
    {

        public PizzaViewModel()
        {
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
        public static Pizza  newPizza = new() { Img = "placeholder.png", Toppings = new(), Size= new() };
        
        

        

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
        public ObservableCollection<CrustSize> allSizes = CrustSize.GetAvailableSizes();






    }


}

