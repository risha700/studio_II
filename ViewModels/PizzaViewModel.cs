using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp.Models;
using Size = PizzaApp.Models.Size;

namespace PizzaApp.ViewModels
{

    public partial class PizzaViewModel : BaseViewModel
    {

        public PizzaViewModel()
        {
        }


        [ObservableProperty]
        public static Order _currentOrder = new()
        {
            Id = Guid.NewGuid(),
            Items = new()
        };

        [ObservableProperty]
        public ObservableCollection<Topping> _allToppings = Topping.GetAvailableToppings();


        [ObservableProperty]
        public static Pizza  _newPizza = new() { Img = "placeholder.png", Toppings = new(), Size= new() };
        
        

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
        //public ObservableCollection<Size> _pizzaSizes = Size.GetAvailableSizes();



        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PizzaViewModel.NewPizza))]
        public ObservableCollection<Size> _allSizes = Size.GetAvailableSizes();






    }


}

