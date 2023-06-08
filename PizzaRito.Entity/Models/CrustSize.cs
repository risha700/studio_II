using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaRito.Entity.Models;
[Table("crusts"), Index(nameof(Name), IsUnique = true)]
public class CrustSize
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
	public double Price { get; set; }

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




