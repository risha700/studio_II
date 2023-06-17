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
    public Guid Id { get; set; } = new();

    public string Name { get; set; }
    public string? Details { get; set; }
    public virtual CrustSize? Size { get; set; }
    public double Price { get; set; }
    public virtual ObservableCollection<Topping>? Toppings { get; set; }
    public string? Img { get; set; }
    public virtual ObservableCollection<Order>? Orders { get; set; } // m2m


    public void CalculatePizzaPrice()
    {

        double toppingCost = this.Toppings.Sum((t) => t.Price);
        this.Price = this.Size.Price + toppingCost;

        // might be any coupon discounts later
    }

    public override string ToString()
    {
        return $"{nameof(Pizza)} {Name} - {Price}";
    }

}

