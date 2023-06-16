using System.ComponentModel;
using PizzaApp.Views;
using PizzaRito.Entity.Models;
using PizzaRito.Utilities;

namespace PizzaRito.Views;

// cart

[QueryProperty(nameof(CurrentOrder), "CurrentOrder")]
public partial class OrderReviewPage : ContentPage, INotifyPropertyChanged
{
	CollectionView orderItemsCollectionView = new CollectionView { Margin=new Thickness(0,20,0,0) };
    Button checkoutBtn = new Button { Text = "Check Out" , HorizontalOptions = LayoutOptions.Center};
    Button backToMenuBtn = new Button { Text = "Add More Items", HorizontalOptions = LayoutOptions.Center, BackgroundColor=Colors.Teal };
    Label totalCardPrice = new Label { };

    Grid mainLayout = new Grid {
        VerticalOptions = LayoutOptions.Start,
        HeightRequest = Shell.Current.Window.Height,
        WidthRequest = Shell.Current.Window.Width,
        ColumnSpacing = 0,
        RowSpacing = 0,
        Padding = 20,
        RowDefinitions = {
                new RowDefinition {Height=new GridLength(.2, GridUnitType.Star) },
                new RowDefinition {Height=new GridLength(.40, GridUnitType.Star) },
                new RowDefinition {Height=new GridLength(.40, GridUnitType.Star) },

            },
        ColumnDefinitions = {
                new ColumnDefinition {  Width = new GridLength(.7, GridUnitType.Star) } ,
                new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) },
            },
    };
    VerticalStackLayout pizzaCard = new VerticalStackLayout {Spacing=10, Padding=20 };

    Button cancelOrderBtn = new Button { Text = "Cancel Order", BackgroundColor=Colors.Transparent, TextColor=Colors.OrangeRed };
    Label OrderIdLabel = new Label { FontSize = 15 };
    Order currentOrder;

	public Order CurrentOrder {
		get =>currentOrder;
		set {
			if (value!=null)
			currentOrder = value;
			OnPropertyChanged(nameof(CurrentOrder));
		}
	}


	public OrderReviewPage()
    {

        orderItemsCollectionView.EmptyView = new Label { Text = "Your cart is empty...Add some items!", Margin = new Thickness(0, 20) };
        orderItemsCollectionView.Header = "Review Your Order";
        var activityIndicator = new ActivityIndicator { IsRunning = true, Color = Colors.Orange };

        SetupEvents();

        orderItemsCollectionView.HeaderTemplate = new DataTemplate(() =>
        {

            return new VerticalStackLayout
            {
                Spacing = 20,
                Padding = new Thickness(0, 50),
                Children = { new Label { Text = "Review Your Order", FontAttributes = FontAttributes.Bold }, OrderIdLabel }
            };
        });

        mainLayout.Add(orderItemsCollectionView, 0, 0);

        mainLayout.Add(new Border { Content = pizzaCard }, 1, 0);

        mainLayout.SetRowSpan(pizzaCard, 1);
        mainLayout.SetRowSpan(orderItemsCollectionView, 3);
        mainLayout.Add(activityIndicator, 0, 0);
        Content = mainLayout;

        Shell.Current.Navigated += (s, o) =>
        {
            SetupOrderCollectionView();
            SetupPizzaCard();
            activityIndicator.IsRunning = false;
        };

    }

    private void SetupEvents()
    {
        cancelOrderBtn.Clicked += async (s, o) =>
        {
            var result = await Shell.Current.DisplayAlert("Are you sure?", "Cancel Order", "Yes, Cancel", "Continue Order");
            if (result)
            {
                CurrentOrder.Items.Clear(); 
                CurrentOrder.Id = Guid.NewGuid();

                await Navigation.PopToRootAsync();
                //await Shell.Current.GoToAsync(nameof(MainPage), true); // todo??
            };
        };

        checkoutBtn.Clicked += async (s, o) =>
        {
            await Shell.Current.GoToAsync(nameof(CheckoutPage), true,
                new Dictionary<string, object>{
                        { "Order", CurrentOrder }
            });
        };

        backToMenuBtn.Clicked += async (s, o) => await Shell.Current.GoToAsync(nameof(MenuPage), true); 

    }

    private void SetupPizzaCard()
    {
        
        
        totalCardPrice.SetBinding(Label.TextProperty, new Binding("Total", source: CurrentOrder, stringFormat:"Total {0:C2}", mode:BindingMode.TwoWay));
        OrderIdLabel.SetBinding(Label.TextProperty, new Binding("Id", source: CurrentOrder, stringFormat: "Order# {0}"));
        //pizzaCard.Add(OrderIdLabel);
        pizzaCard.Add(totalCardPrice);
        pizzaCard.Add(backToMenuBtn);
        pizzaCard.Add(checkoutBtn);
        pizzaCard.Add(cancelOrderBtn);

    }

    private void SetupOrderCollectionView()
    {
        orderItemsCollectionView.ItemsSource = CurrentOrder.Items;
        orderItemsCollectionView.ItemsLayout = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical);
        orderItemsCollectionView.ItemTemplate = new DataTemplate(() =>
        {
            var itemName = new Label { };
            var itemPrice = new Label { };
            var itemImg = new Image { HeightRequest=100,WidthRequest=100, Aspect = Aspect.AspectFill };
            var itemImgPlate = new Frame
            { 
                HeightRequest = 70,
                WidthRequest = 70,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0),
                Content = itemImg,
                CornerRadius = 25,
                BackgroundColor = Colors.Transparent,
                IsClippedToBounds = true
            };
            var itemSize = new Label { };
            var editBtn = new Button { Text = "Edit", BackgroundColor=Colors.Transparent, TextColor = Colors.SlateBlue };
            var removeBtn = new Button { Text = "Remove", BackgroundColor = Colors.Transparent, TextColor = Colors.OrangeRed };

            editBtn.Clicked += EditPizza;
            removeBtn.Clicked += RemovePizza;
    
            var itemToppings = new CollectionView { };
            itemToppings.ItemsLayout = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical);

            itemToppings.ItemTemplate = new DataTemplate(() =>
            {
                var toppingLabel = new Label { };
                toppingLabel.SetBinding(Label.TextProperty, "Name");
                return toppingLabel;
            });
            var actionButtons = new HorizontalStackLayout { HorizontalOptions=LayoutOptions.End,Spacing=10, Children = { editBtn, removeBtn, } };
            var layoutContainer = new ScrollView{
                Content= new VerticalStackLayout
                {
                    HeightRequest = 250,
                    Children = { new FlexLayout
                    {
                        Direction=Microsoft.Maui.Layouts.FlexDirection.Row,
                        JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceBetween,
                        AlignContent=Microsoft.Maui.Layouts.FlexAlignContent.Start,
                        AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
                        Children = {
                            itemSize, itemName, itemImgPlate , itemPrice, actionButtons
                        }
                    },
                        new Border { StrokeThickness=0, Content =  itemToppings }  }
                }
            };
            itemName.SetBinding(Label.TextProperty, "Name");
            itemPrice.SetBinding(Label.TextProperty, new Binding("Price", stringFormat:"{0:C2}"));
            itemSize.SetBinding(Label.TextProperty, "Size.Name");
            itemImg.SetBinding(Image.SourceProperty, "Img");
            itemToppings.SetBinding(CollectionView.ItemsSourceProperty, new Binding("Toppings"));

            

            return layoutContainer;
        });
    }

    private async void RemovePizza(object sender, EventArgs e)
    {
        var pizza = ((Button)sender).Parent.BindingContext as Pizza;

        var result = await Shell.Current.DisplayAlert("Are you sure?", $"remove {pizza?.Name} Pizza", "Yes, Remove", "Cancel");
        if (result)
        {
            Console.WriteLine($"DEBUG===> remove pizza total before {CurrentOrder.Total}");
            CurrentOrder.Items.Remove(pizza);
            CurrentOrder.CalculateTotal();
            Console.WriteLine($"DEBUG===> remove pizza total after {CurrentOrder.Total}");
                
            totalCardPrice.SetBinding(Label.TextProperty, new Binding(".", source: CurrentOrder.Total, stringFormat: "Total {0:C2}"));

            //CurrentOrder.Items.Clear();
            //CurrentOrder.Id = Guid.NewGuid();

            //await Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync(nameof(MainPage), true); // todo??
        };

    }

    private void EditPizza(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
