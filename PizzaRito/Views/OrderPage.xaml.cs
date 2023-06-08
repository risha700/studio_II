using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaRito.Entity.Models;
using PizzaRito.ViewModels;



namespace PizzaRito.Views;

public partial class OrderPage : ContentPage
{
   
    public OrderPage(PizzaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Title = "New Order";
       

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
                PizzaViewModel.newPizza.Toppings.Add(topping);
                PizzaViewModel.newPizza.Img = "pizza_placeholder.png";
            }
            else
            {

                if (PizzaViewModel.newPizza.Toppings.Contains(topping))
                    PizzaViewModel.newPizza.Toppings.Remove(topping);
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
        PizzaViewModel.newPizza.CalculatePizzaPrice();
        OrderTotalName.Text = $"Order Total: {PizzaViewModel.newPizza.Price.ToString("C2")}";

    }

    void OnRadioBtnChange(object sender, CheckedChangedEventArgs e)
    {

        RadioButton btn = (RadioButton)sender;
        //var ChosenTopping = _allToppings.Where((tp) => tp.Name == btn.Content.ToString().Trim());
        //Console.WriteLine($"{btn.Content} typeof {btn.BindingContext.GetType()} = value {e.Value}");
        if (e.Value is true)
        {
            PizzaViewModel.newPizza.Name = PizzaViewModel.newPizza.Name ?? "Build Your Own";
            PizzaViewModel.newPizza.Size = (CrustSize)btn.BindingContext;

            // cheap way for updating ui TODO:
            PizzaInfoBoxName.Text = PizzaViewModel.newPizza.Name;
            PizzaInfoBoxSizeName.Text = PizzaViewModel.newPizza.Size.Name.ToString();
            PizzaInfoBoxSizePrice.Text = PizzaViewModel.newPizza.Size.Price.ToString();

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
        if (String.IsNullOrEmpty(PizzaViewModel.newPizza.Size.Name))
        {
            await DisplayAlert("Alert", $"Please select pizza size", "OK");
            return;
        }
        else
        {


            PizzaViewModel.currentOrder.Items.Add(PizzaViewModel.newPizza);
            PizzaViewModel.currentOrder.Total += PizzaViewModel.newPizza.Price;

            //PizzaViewModel._newPizza.Name = "";
            //PizzaViewModel._newPizza.Toppings.Clear();
            //PizzaViewModel._newPizza.Size = new();

            PizzaViewModel.newPizza = new() { Img = "placeholder.png", Toppings = new(), Size = new(), Name = "", Details = "", Price = 0 }; // loses reactivity 

            // success and navigate to checkout

            await Shell.Current.GoToAsync(nameof(CheckoutPage), true,
                new Dictionary<string, object>{
                    { "Order", PizzaViewModel.currentOrder }
                }); ;

            ForceCleanup();
            UpdateViewFields();

            //await DisplayAlert("Alert", $"{activeToppingContainer.ToString()}", "OK");


        }



    }

    void ForceCleanup()
    {
        PizzaInfoBoxName.Text = "";
        PizzaInfoBoxSizeName.Text = "";
        PizzaInfoBoxSizePrice.Text = "";
    }
    async Task NavigateTo(dynamic NewPage, dynamic dict = null)
    {
        // Get current page
        var page = Navigation.NavigationStack.LastOrDefault();

        // Load new page
        await Shell.Current.GoToAsync(nameof(NewPage), true, dict);

        // Remove old page
        Navigation.RemovePage(page);
    }
}


