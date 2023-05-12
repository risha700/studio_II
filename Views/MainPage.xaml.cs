using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaApp.Models;
using PizzaApp.ViewModels;
using Size = PizzaApp.Models.Size;


namespace PizzaApp.Views;

public partial class MainPage : ContentPage
{

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
                PizzaViewModel._newPizza.Img="pizza_placeholder.png";
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

        UpdateViewFields();
        



    }
    void UpdateViewFields()
    {
        PizzaViewModel._newPizza.CalculatePizzaPrice();
        OrderTotalName.Text = $"Order Total: {PizzaViewModel._newPizza.Price.ToString("C2")}";

    }

    void OnRadioBtnChange(object sender, CheckedChangedEventArgs e)
    {
        
        RadioButton btn = (RadioButton)sender;
        //var ChosenTopping = _allToppings.Where((tp) => tp.Name == btn.Content.ToString().Trim());
        //Console.WriteLine($"{btn.Content} typeof {btn.BindingContext.GetType()} = value {e.Value}");
        if (e.Value is true)
        {
            PizzaViewModel._newPizza.Name = "Build Your Own";
            PizzaViewModel._newPizza.Size = (Size)btn.BindingContext;
            // cheap way for updating ui TODO:
            PizzaInfoBoxName.Text = PizzaViewModel._newPizza.Name;
            PizzaInfoBoxSizeName.Text = PizzaViewModel._newPizza.Size.Name.ToString();
            PizzaInfoBoxSizePrice.Text = PizzaViewModel._newPizza.Size.Price.ToString();
            UpdateViewFields();
            
        }
        else
        {
            Console.Error.WriteLine($"{nameof(OnRadioBtnChange)}: Can't retrieve size context");
        }

    }



    [RelayCommand]
    async private void AddPizza(User user)
    {
        // validation
        if(String.IsNullOrEmpty(PizzaViewModel._newPizza.Size.Name))
        {
            await DisplayAlert("Alert", $"Please select pizza size", "OK");
            return;
        }
        else
        {

            PizzaViewModel._currentOrder.Items.Add(PizzaViewModel._newPizza);
            PizzaViewModel._currentOrder.Total += PizzaViewModel._newPizza.Price;
            // success and navigate to checkout
            //PizzaViewModel._newPizza = new() { Img = "placeholder.png", Toppings = new(), Size = new() };

            await Shell.Current.GoToAsync(nameof(CheckoutPage), true,
                new Dictionary<string, object>{
                    { "Order", PizzaViewModel._currentOrder }
                });;
        }

        
        
    }
}


