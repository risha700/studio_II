using System;
using System.Collections.ObjectModel;

namespace PizzaApp.Models
{
	public class Pizza
	{

        
        public string Name { get; set; }
        public string Details { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public ObservableCollection<Topping> Toppings { get; set; }
        public string Img { get; set; }



        public Pizza() { }

        public static dynamic GetAvailablePizzas()
        {
            ObservableCollection<Pizza> availablePizza = new()
            {
                new Pizza {Name="Margreta", Price=5.99},
                new Pizza {Name="Pepperoni", Price=7.99},
                new Pizza {Name="Salami", Price=9.99},
                new Pizza {Name="Hawaian", Price=9.99},

            };

            return availablePizza;
        }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }
    }


}

