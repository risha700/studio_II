using PizzaApp.ViewModels;

namespace PizzaApp.Views;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage(CheckoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
