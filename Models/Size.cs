using System;
using System.Collections.ObjectModel;

namespace PizzaApp.Models
{
	public class Size
	{
		public string Name { get; set; }
		public double Price { get; set; }

        public static dynamic GetAvailableSizes()
        {
            ObservableCollection<Size> availableToppings = new()
            {
                new Size {Name="Small", Price=5.99},
                new Size {Name="Medium", Price=7.99},
                new Size {Name="Large", Price=9.99},
                
            };

            return availableToppings;
        }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }
    }


}

