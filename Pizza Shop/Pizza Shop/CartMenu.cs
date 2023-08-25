using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Shop
{
    public class CartMenu
    {
        List<Pizza> pizzas;
        List<ColdDrink> coldDrinks;

        public CartMenu()
        {
            pizzas = new List<Pizza>();
            coldDrinks = new List<ColdDrink>();
        }

        public List<Pizza> GetPizzas()
        {
            return pizzas;
        }

        public List<ColdDrink> GetColdDrinks()
        {
            return coldDrinks;
        }

        public void AddPizzaToCart(Pizza pizza)
        {
            pizzas.Add(pizza);
        }

        public void AddColdDrinkToCart (ColdDrink coldDrink)
        {
            coldDrinks.Add(coldDrink);
        }
    }

    public class Pizza
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public List<String> Toppings { get; set; }
        public double Price { get; set; }

        public Pizza()
        {
            Toppings = new List<String>();
            Price = 0;
        }
    }

    public class ColdDrink 
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }

        public ColdDrink()
        {
            Price = 0;
        }
    }
}
