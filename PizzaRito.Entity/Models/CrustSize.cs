using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaRito.Entity.Models;
[Table("crusts"), Index(nameof(Name), IsUnique = true)]
public class CrustSize
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // make it keyless
    public int Id { get; set; }
    public string Name { get; set; }
	public double Price { get; set; }
    //public ICollection<Pizza>? Pizzas { get; set; } // many 2 one

    public override string ToString()
    {
        return $"{Name} .................... {Price:C2}";
    }
}




