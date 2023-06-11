using PizzaRito.Entity;
using PizzaRito.ViewModels;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaRito.Entity.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;



namespace PizzaRito.Views;

public partial class OrderPage : ContentPage
{
	AppDbContext databaseContext;

    CollectionView availableToppingsView = new CollectionView { Header = "", EmptyView = new Label { Text = "Loading Toppings..." } };
    CollectionView currentPizzaToppingsView = new CollectionView { };
    CollectionView availableSizesView = new CollectionView {Header="" };
    Label selectedPizzaLabel = new Label { FontSize = 24, VerticalOptions = LayoutOptions.Center, Text = $"Loading..." };
    StackLayout selectedPizzaView = new StackLayout { };
    Grid contentGrid = new Grid
    {
        VerticalOptions = LayoutOptions.Start,
        HeightRequest = Shell.Current.Window.Height,
        WidthRequest = Shell.Current.Window.Width,
        ColumnSpacing = 20,
        RowSpacing = 0,
        Padding=10,
        RowDefinitions = {
                new RowDefinition {Height=new GridLength(.5, GridUnitType.Star) },
                new RowDefinition {Height=new GridLength(.5, GridUnitType.Star)},
                
            },
        ColumnDefinitions = {
                new ColumnDefinition {  Width = new GridLength(.6, GridUnitType.Star) } ,
                new ColumnDefinition { Width = new GridLength(.4, GridUnitType.Star) },
            },

    };
    Frame orderBox = new Frame { BackgroundColor=Colors.Transparent };
    ObservableCollection<Topping> availableToppings=new();


    public OrderViewModel OrderVm { get; set; }


	public OrderPage(OrderViewModel viewModel, AppDbContext dbCtx)
	{

		BindingContext = viewModel;
        OrderVm = viewModel;
		Title = "New Order";
		databaseContext = dbCtx;

        selectedPizzaView.Add(selectedPizzaLabel); // loading ...
        contentGrid.Add(availableSizesView, 0, 0);

        contentGrid.Add(availableToppingsView, 0, 1);

        orderBox.Content = new StackLayout {
            Children =
            {
                //new Label {BindingContext=OrderVm.PizzaDetail.Toppings}
                selectedPizzaView,
                currentPizzaToppingsView
            }
        };
        contentGrid.Add(orderBox, 1, 0);

        Content = contentGrid;

        Shell.Current.Navigated += (s,o) =>
        {
            //Console.WriteLine($"==>test Pizza in model: {viewModel.PizzaDetail}");
            RenderSizesView();
            RenderSelectedPizza();
            RenderToppingsView();

            //availableToppings = (ObservableCollection<Topping>)OrderVm.AllToppings.Where(t => t.InStock).AsEnumerable();
            //SetupCurrentPizzaToppings();
        };


    }

    private void RenderSelectedPizza()
    {
        Label pizzaPrice = new Label { FontSize = 24};
        Label pizzaSize = new Label { FontSize = 16};

        selectedPizzaLabel.SetBinding(Label.TextProperty, new Binding("Name", source: OrderVm.PizzaDetail));
        //pizzaPrice.SetBinding(Label.TextProperty, new Binding("Price", source: OrderVm.PizzaDetail, stringFormat:"Price: {0:C2}"));
        pizzaSize.SetBinding(Label.TextProperty, new Binding("Size", source: OrderVm.PizzaDetail));
        selectedPizzaView.Children.Add(pizzaSize);
        SetupCurrentPizzaToppings();
        selectedPizzaView.Children.Add(currentPizzaToppingsView);

    }

    private void SetupCurrentPizzaToppings()
    {
        currentPizzaToppingsView.ItemsSource = OrderVm.PizzaDetail.Toppings;
        currentPizzaToppingsView.ItemTemplate = new DataTemplate(() =>
        {
            var toppingNameLabel = new Label();
            var toppingPriceLabel = new Label();
            toppingNameLabel.SetBinding(Label.TextProperty, "Name");
            toppingPriceLabel.SetBinding(Label.TextProperty, "Price", stringFormat: "Price: {0:C2}");

            return new HorizontalStackLayout { Spacing=10, Children = { toppingNameLabel, toppingPriceLabel } };
        });
    }


    private void RenderSizesView()
    {
        availableSizesView.ItemsSource = OrderVm.AllSizes;
        


        availableSizesView.ItemsLayout = new GridItemsLayout(3, ItemsLayoutOrientation.Vertical)
        {
            HorizontalItemSpacing=20,
            
        };
        availableSizesView.ItemSizingStrategy = ItemSizingStrategy.MeasureAllItems;
        availableSizesView.SelectionMode = SelectionMode.Single;
        availableSizesView.SelectionChanged += SizesViewSelectionChanged;
        availableSizesView.HeaderTemplate = new DataTemplate(() => {

            return new StackLayout
            {
                Padding = new Thickness(0, 30),
                Children = { new Label { Text = "Available Sizes", FontAttributes = FontAttributes.Bold, FontSize = 30 } }
            };
        });

        availableSizesView.ItemTemplate = new DataTemplate(() =>
        {
            
            var sizeNameLabel = new Label { FontAttributes = FontAttributes.Bold, FontSize = 20 };
            var sizePriceLabel = new Label();
            sizePriceLabel.SetBinding(Label.TextProperty, "Price", stringFormat: "Price: {0:C2}");
            sizeNameLabel.SetBinding(Label.TextProperty, "Name");

            var layout = new Border
            {
                VerticalOptions = LayoutOptions.Center,
                //WidthRequest = 200,
                HeightRequest = 200,
                Content = new FlexLayout
                {
                    Direction = Microsoft.Maui.Layouts.FlexDirection.Column,
                    JustifyContent = Microsoft.Maui.Layouts.FlexJustify.Center,
                    AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
                    Children = { sizeNameLabel, sizePriceLabel }
                }
            };
            // Create the visual states
            var normalState = new VisualState { Name = "Normal" };
            var selectedState = new VisualState { Name = "Selected" };

            // Create the setter for the selected state
            var selectedSetter = new Setter { Property = VisualElement.BackgroundColorProperty, Value = Colors.Orange };
            selectedState.Setters.Add(selectedSetter);

            // Create the visual state group and add the states
            var commonStatesGroup = new VisualStateGroup { Name = "CommonStates" };
            commonStatesGroup.States.Add(normalState);
            commonStatesGroup.States.Add(selectedState);

            // Set the visual state group on the grid
            VisualStateManager.SetVisualStateGroups(layout, new VisualStateGroupList { commonStatesGroup });

            return layout;
        });
    }

    private void SizesViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Console.WriteLine($"SizesViewSelectionChanged {sender} {e.CurrentSelection.FirstOrDefault()}");
        //throw new NotImplementedException();
    }

    private void SizeSelectionChanged(object sender, CheckedChangedEventArgs e)
    {
        Console.WriteLine($"SizeSelectionChanged {sender} {e.Value}");
        //throw new NotImplementedException();
    }

    private void ToppingSelectionChanged(object sender, CheckedChangedEventArgs e)
    {
        //throw new NotImplementedException();
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
            //toppingCheckBox.SetBinding(CheckBox.IsCheckedProperty, "Name");

            toppingCheckBox.CheckedChanged += ToppingSelectionChanged;
            var layout = new FlexLayout
            {
                JustifyContent = Microsoft.Maui.Layouts.FlexJustify.Start,
                AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
                AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Center,
                Children = { toppingNameLabel, toppingCheckBox }
            };
            return layout;
        });
    }

    
}

