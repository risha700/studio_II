using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp.Models;


namespace PizzaApp.ViewModels
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

