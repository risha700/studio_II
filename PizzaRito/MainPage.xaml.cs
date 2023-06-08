using PizzaRito.Entity;
using PizzaRito.Entity.Models;

namespace PizzaRito;

public partial class MainPage : ContentPage
{
	int count = 0;
	AppDbContext databaseContext;
    public MainPage(AppDbContext ctx)
	{
		InitializeComponent();
		databaseContext = ctx;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		Console.WriteLine($"contet can connect {databaseContext.Database.CanConnect()}");
		try
		{

            //Pizza pz = new Pizza
            //{
            //    Name = "Build it yourself",
            //    Details = "anything",
            //    Img = "any.ong",
            //    Price = 10.88,
            //    //Size = new CrustSize { Name = "2xl", Price = 1.22 },
            //    //Toppings = new List<Topping>{ new Topping { Name = "Green Olives", Price = 2.24, InStock = true } }
            //};
            //Console.WriteLine($"piiza {pz.ToString()}");

            //databaseContext.Pizzas.Add(pz);
            //databaseContext.SaveChanges();
            Console.WriteLine($"dbpath{databaseContext.DbPath}");
            var allpizzas = databaseContext.Pizzas.ToList();
            foreach(var p in allpizzas)
            {
                Console.WriteLine(p.Name);
            }
            //databaseContext.Database.CommitTransaction();
            
            //Console.WriteLine($"piiza {databaseContext.Pizzas.ToList().Last().Name}");


        }
        catch (Exception ex)
		{

            Console.WriteLine($"Exceptopm {ex.Message}, {ex.InnerException}");
        }


        count++;
		
		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


