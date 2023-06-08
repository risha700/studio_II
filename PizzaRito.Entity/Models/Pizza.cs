using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaRito.Entity.Models;

[Table("pizzas"), Index(nameof(Name), IsUnique = true)]
public class Pizza
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string? Details { get; set; }
    public CrustSize? Size { get; set; }
    public double Price { get; set; }
    public ObservableCollection<Topping>? Toppings { get; set; }
    public string? Img { get; set; }



    public static dynamic GetAvailablePizzas()
    {
        ObservableCollection<Pizza> availablePizza = new()
            {
                new Pizza {Name="Margreta", Price=5.99},
                new Pizza {Name="Pepperoni", Price=7.99},
                new Pizza {Name="Salami", Price=9.99},
                new Pizza {Name="Hawaian", Price=9.99},
                new Pizza {Name="Four Seasons", Price=9.99},
                new Pizza {Name="All Meats", Price=10.99}

            };

        return availablePizza;
    }

    public void CalculatePizzaPrice()
    {

        double toppingCost = this.Toppings.Sum((t) => t.Price);
        this.Price = this.Size.Price + toppingCost;
        // might be any coupon discounts later
    }

    public override string ToString()
    {
        return $"{Name} - {Price}";
    }

}

