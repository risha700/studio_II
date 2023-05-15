using System;
using System.Collections.ObjectModel;

namespace PizzaApp.Models
{
	public class CrustSize
	{
		public string Name { get; set; }
		public double Price { get; set; }
        //public Size()
        //{

        //}
        public static ObservableCollection<CrustSize> GetAvailableSizes()
        {
            ObservableCollection<CrustSize> availableToppings = new()
            {
                new CrustSize {Name="Small", Price=5.99},
                new CrustSize {Name="Medium", Price=7.99},
                new CrustSize {Name="Large", Price=9.99},
                
            };

            return availableToppings;
        }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }
    }


}

