using PizzaRito.Views;

namespace PizzaRito;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
        Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        Shell.SetNavBarIsVisible(this, false);

    }
}

