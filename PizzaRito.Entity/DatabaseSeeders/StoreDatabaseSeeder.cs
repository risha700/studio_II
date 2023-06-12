using System;
using System.Collections.ObjectModel;
using PizzaRito.Entity.Models;

namespace PizzaRito.Entity.DatabaseSeeders;

public static class StoreDatabaseSeeder
{
    public static List<Topping> ToppingToSeed = new List<Topping>
    {
        new Topping {Name="Salami", InStock=true, Price=0.99},
        new Topping {Name="Cheese it up",InStock=true,Price=0.75},
        new Topping {Name="Pepperoni",InStock=true,Price=0.79},
        new Topping {Name="Olives",InStock=true,Price=0.36},
        new Topping {Name="Mushroom",InStock=true,Price=0.55},
        new Topping {Name="Parmigiano",InStock=true,Price=0.55},
        new Topping {Name="Corn",InStock=true,Price=0.55},
        new Topping {Name="Chilli Flakes",InStock=true,Price=0.55},
        new Topping {Name="Roasted Onions",InStock=true,Price=0.55},
        new Topping {Name="Green Peppers",InStock=true,Price=0.55}


    };
    public static List<CrustSize> CrustSizeToSeed = new List<CrustSize>
    {
        new CrustSize {Name="Small", Price=5.99},
        new CrustSize {Name="Medium", Price=7.99},
        new CrustSize {Name="Large", Price=9.99},

    };
    
    public static List<Pizza> PizzaToSeed = new List<Pizza>
    {
        
        new Pizza {Name="Margreta", Price=5.99, Size=CrustSizeToSeed[0],
            Toppings=new ObservableCollection<Topping>(ToppingToSeed.GetRange(1,3))  },

        new Pizza {Name="Pepperoni", Price=7.99, Img="pepps.png"},
        new Pizza {Name="Salami", Price=9.99},
        new Pizza {Name="Vegeterian", Price=9.99, Img="veg.png"},
        new Pizza {Name="Hawaian", Price=9.99},
        new Pizza {Name="Four Seasons", Price=9.99},
        new Pizza {Name="All Meats", Price=10.99, Img="meat.png"},
        new Pizza {Name="Build Your Own", Price=10.99, Img="plain.png"}

    };


}

