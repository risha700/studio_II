using PizzaRito.ViewModels;

namespace PizzaRito.Views;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage(CheckoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
