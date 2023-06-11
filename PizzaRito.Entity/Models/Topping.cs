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
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
		public bool InStock { get; set; }
        public virtual ObservableCollection<Pizza>? Pizzas { get; set; } // implicit many-to-many


        public override string ToString()
        {
            return $"{Name.ToString()} - {Price.ToString()}";
        }


    }




