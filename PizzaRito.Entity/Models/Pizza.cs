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
    public List<Topping>? Toppings { get; set; }
    public string? Img { get; set; }

}

