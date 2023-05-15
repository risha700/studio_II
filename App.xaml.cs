
using PizzaApp.Views;

namespace PizzaApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        //Resources.Add("GlobalActivityIndicator", new GlobalActivityIndicator());

        MainPage = new AppShell();


    }


}

