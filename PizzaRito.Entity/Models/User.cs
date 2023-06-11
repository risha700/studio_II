
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaRito.Entity.Models;

[Table("users")]
public class User
	{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }
}

