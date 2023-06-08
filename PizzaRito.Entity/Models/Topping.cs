using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaRito.Entity.Models;
[Table("toppings"), Index(nameof(Name), IsUnique = true)]
public class Topping
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
		public bool InStock { get; set; }

        public override string ToString()
        {
            return $"{Name.ToString()} - {Price.ToString()}";
        }
        public static dynamic GetAvailableToppings()
        {
        ObservableCollection<Topping> availableToppings = new()
            {
                new Topping {Name="Salami", InStock=true, Price=0.99},
                new Topping {Name="Cheese it up",InStock=true,Price=0.75},
                new Topping {Name="Pepperoni",InStock=true,Price=0.79},
                new Topping {Name="Olives",InStock=true,Price=0.36},
                new Topping {Name="Mushroom",InStock=true,Price=0.55},
                new Topping {Name="Parmigiano",InStock=true,Price=0.55},
                new Topping {Name="Corn",InStock=true,Price=0.55},
                new Topping {Name="Chilli Flakes",InStock=true,Price=0.55},
                new Topping {Name="Roasted Onions",InStock=true,Price=0.55}

            };

            return availableToppings;
        }

    }




