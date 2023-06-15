using System.ComponentModel;
using PizzaRito.Entity.Models;

namespace PizzaRito.Views;

// cart

[QueryProperty(nameof(CurrentOrder), "CurrentOrder")]
public partial class OrderReviewPage : ContentPage, INotifyPropertyChanged
{
	CollectionView orderItemsCollectionView = new CollectionView { };
    Button finalizeOrder = new Button { Text = "Check Out" };
    Grid mainLayout = new Grid {
        VerticalOptions = LayoutOptions.Start,
        HeightRequest = Shell.Current.Window.Height,
        WidthRequest = Shell.Current.Window.Width,
        ColumnSpacing = 20,
        RowSpacing = 0,
        Padding = 10,
        RowDefinitions = {
                new RowDefinition {Height=new GridLength(1, GridUnitType.Star) },

            },
        ColumnDefinitions = {
                new ColumnDefinition {  Width = new GridLength(.7, GridUnitType.Star) } ,
                new ColumnDefinition { Width = new GridLength(.3, GridUnitType.Star) },
            },
    };
    StackLayout pizzaCard = new StackLayout { };

    Button cancelOrderBtn = new Button
    {
        Text = "CancelOrder",

    };
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
        orderItemsCollectionView.EmptyView = new Label { Text = "Loading..." };
        orderItemsCollectionView.Header = "Review Your Order";

        cancelOrderBtn.Clicked += async (s, o) =>
        {
            var result = await Shell.Current.DisplayAlert("Are you sure?", "Cancel Order", "Yes, Cancel", "Continue Order");
            if (result)
            {
                currentOrder = new Order { Items=new() };

       
                await Navigation.PopToRootAsync();
                //var page = Navigation.NavigationStack.LastOrDefault();
                //Navigation.RemovePage(page);
                //await Shell.Current.GoToAsync(nameof(MainPage), true);
            };
        };

        orderItemsCollectionView.HeaderTemplate = new DataTemplate(() =>
        {

            return new FlexLayout
            {
                Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
                WidthRequest = Shell.Current.Window.Width,
                JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
                AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Center,
                AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
                Children = { new Label { Text = "Review Your Order" } }
            };
        });

        mainLayout.Add(orderItemsCollectionView, 0,0);

        mainLayout.Add(new Border { Content = new VerticalStackLayout { Children = {pizzaCard, finalizeOrder, cancelOrderBtn } } }, 1, 0);


        Content = mainLayout;

        Shell.Current.Navigated += (s, o) =>
        {
            //Console.WriteLine($"DEBUG==> OrderReview current orderis: {CurrentOrder.Items.FirstOrDefault()}");
            SetupOrderCollectionView();
            var totalPrice = new Label { };
            totalPrice.Text = "10$";
            pizzaCard.Add(totalPrice);
        };

    }

    private void SetupOrderCollectionView()
    {
        orderItemsCollectionView.ItemsSource = CurrentOrder.Items;
        orderItemsCollectionView.ItemsLayout = new GridItemsLayout(1, ItemsLayoutOrientation.Vertical);
        orderItemsCollectionView.ItemTemplate = new DataTemplate(() =>
        {
            var itemName = new Label { };
            var itemPrice = new Label { };
            var itemImg = new Image { HeightRequest = 100, WidthRequest=100 };
            var itemSize = new Label { };
            var editBtn = new Button { Text = "Edit", BackgroundColor=Colors.Transparent, TextColor = Colors.SlateBlue };
            var removeBtn = new Button { Text = "Remove", BackgroundColor = Colors.Transparent, TextColor = Colors.OrangeRed };

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
                        AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
                        Children = { itemName, itemPrice, itemImg, itemSize, actionButtons }
                    },
                        new Border { StrokeThickness=0, Content =  itemToppings }  }
                }
            };
            itemName.SetBinding(Label.TextProperty, "Name");
            itemPrice.SetBinding(Label.TextProperty, "Price");
            itemSize.SetBinding(Label.TextProperty, "Size");
            itemImg.SetBinding(Image.SourceProperty, "Img");
            itemToppings.SetBinding(CollectionView.ItemsSourceProperty, new Binding("Toppings"));

            return layoutContainer;
        });
    }
}
