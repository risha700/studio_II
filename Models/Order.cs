using System;
namespace PizzaApp.Models
{
	public class Order
	{
		public Guid Id { get; set; }
		public List<Pizza> Items {get;set;}
		public double Total { get; set; }
		public User Customer { get; set; }
	}

	// todo: calcualte order total method
}

