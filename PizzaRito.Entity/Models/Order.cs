
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaRito.Entity.Models;
[Table("orders")]
public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public List<Pizza> Items {get;set;}
	public double Total { get; set; }
	public User Customer { get; set; }
	public DateTime OrderDate { get; set; }
}

// todo: calcualte order total method

