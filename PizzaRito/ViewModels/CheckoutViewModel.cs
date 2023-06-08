using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaRito.Entity.Models;


namespace PizzaRito.ViewModels
{


	[QueryProperty(nameof(Order), "Order")]
    public partial class CheckoutViewModel:BaseViewModel
	{
		public CheckoutViewModel()
		{
		}

		[ObservableProperty]
		Order order;
	}
}

