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
    public int Id { get; set; }
    public string Name { get; set; }
	public double Price { get; set; }

    public override string ToString()
    {
        return $"{nameof(CrustSize)} {Name} - {Price}";
    }
}




