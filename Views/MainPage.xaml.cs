using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp.Models;
using PizzaApp.ViewModels;
using Size = PizzaApp.Models.Size;


namespace PizzaApp.Views;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Size> _allSizes = Size.GetAvailableSizes();
    public ObservableCollection<Topping> _allToppings = Topping.GetAvailableToppings();

    
    


    public MainPage(PizzaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        
	}

    void OnCheckBoxChange(object sender, CheckedChangedEventArgs e)
    {
       
        var btn = (CheckBox)sender;
        //var ChosenTopping = _allToppings.Where((tp) => tp.Name == btn.Content.ToString().Trim());
        Element v = (Element)btn.Parent.FindByName("element_val");
        var ctx = v?.BindingContext;

        if (ctx is Topping)
        {
            Topping topping = (Topping)ctx;
            if (e.Value is true)
            {
                Console.WriteLine($"shoud add toppiung {topping}");
                PizzaViewModel._newPizza.Toppings.Add(topping);
                
                
            }
            else
            {

                if (PizzaViewModel._newPizza.Toppings.Contains(topping))
                    PizzaViewModel._newPizza.Toppings.Remove(topping);
            }
        }
        else
        {
            Console.Error.WriteLine($"{nameof(OnCheckBoxChange)}: Can't retrieve topping context");
        }


        //await DisplayAlert("Alert", $"{e.Value} {ctx}", "OK");



    }

    void OnRadioBtnChange(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        
        RadioButton btn = (RadioButton)sender;
        //var ChosenTopping = _allToppings.Where((tp) => tp.Name == btn.Content.ToString().Trim());
        //Console.WriteLine($"{btn.Content} typeof {btn.BindingContext.GetType()}");

        PizzaViewModel._newPizza.Size = (Size)btn.BindingContext;
        PizzaViewModel._newPizza.Name = "BullCrap";
        Console.WriteLine($"shoud have assigned size {PizzaViewModel._newPizza.Size}");
        //await DisplayAlert("Alert", $"{e.Value} {btn.Content}", "OK");


    }
}


