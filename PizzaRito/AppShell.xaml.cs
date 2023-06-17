using CommunityToolkit.Mvvm.Input;
using PizzaRito.Views;

namespace PizzaRito;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
        Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        Routing.RegisterRoute(nameof(OrderReviewPage), typeof(OrderReviewPage));

        Shell.SetNavBarIsVisible(this, false);
        
    }


}

