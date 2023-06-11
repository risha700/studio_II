using PizzaRito.Entity;
using PizzaRito.ViewModels;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaRito.Entity.Models;
using Microsoft.Maui.Controls;

namespace PizzaRito.Views;

public partial class OrderPage : ContentPage
{
	AppDbContext databaseContext;


	Label pizzaLabel = new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = $"Loading..." };
	Image pizzaImage = new Image { };
	CollectionView pizzaToppings = new CollectionView { HeightRequest=300, Header = "Pizza Toppings" };
	ObservableCollection<Topping> availableToppings=new();

    CollectionView availableToppingsView = new CollectionView {Header="" ,EmptyView = new Label { Text = "Loading Toppings..." } };

    public OrderViewModel OrderVm { get; set; }


	public OrderPage(OrderViewModel viewModel, AppDbContext dbCtx)
	{

		BindingContext = viewModel;
        OrderVm = viewModel;
		Title = "New Order";
		databaseContext = dbCtx;

		//availableToppings = dbCtx.Toppings.Where(t => t.InStock).ToList();


        Content = new VerticalStackLayout
		{
			Children = {
                    pizzaLabel,
					new Frame{ Content= pizzaToppings },
                    new Frame{ Content= availableToppingsView },
				}
		};

        Shell.Current.Navigated += (s,o) =>
        {
            //Console.WriteLine($"==>test Pizza in model: {viewModel.PizzaDetail}");

            pizzaLabel.SetBinding(Label.TextProperty, new Binding("Name", source: OrderVm.PizzaDetail));
            //availableToppings = (ObservableCollection<Topping>)OrderVm.AllToppings.Where(t => t.InStock).AsEnumerable();
            RenderToppingsView();
            SetupPizzaToppings();

        };


    }

    private void SetupPizzaToppings()
    {
        pizzaToppings.ItemsSource = OrderVm.PizzaDetail.Toppings;
        pizzaToppings.ItemTemplate = new DataTemplate(() =>
        {
            var toppingNameLabel = new Label();
            toppingNameLabel.SetBinding(Label.TextProperty, "Name");

            return toppingNameLabel;
        });
    }

    private void ToppingSelectionChanged(object sender, CheckedChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void RenderToppingsView()
    {
        
        availableToppingsView.ItemsSource = OrderVm.AllToppings.Where(t => t.InStock);
        availableToppingsView.ItemsLayout = new GridItemsLayout(3, ItemsLayoutOrientation.Vertical)
        {
            VerticalItemSpacing = 20,
            HorizontalItemSpacing = 20,
        };
        availableToppingsView.HeaderTemplate = new DataTemplate(() => {
            
            return new StackLayout {
                Padding=new Thickness(0,30),
                Children = { new Label { Text = "Available Toppings", FontAttributes=FontAttributes.Bold, FontSize=30 } }
            };
        });
        
        availableToppingsView.ItemTemplate = new DataTemplate(() => {
            var toppingNameLabel = new Label();
            toppingNameLabel.SetBinding(Label.TextProperty, "Name");
            var toppingCheckBox = new CheckBox { IsChecked = false, };
            //toppingCheckBox.SetBinding(CheckBox.prop, "Name");
            toppingCheckBox.CheckedChanged += ToppingSelectionChanged;

            return new FlexLayout
            {
                JustifyContent = Microsoft.Maui.Layouts.FlexJustify.Start,
                AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
                AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Center,
                Children = { toppingNameLabel, toppingCheckBox }
            };
        });
    }
}
