using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using PizzaApp.Models;


namespace PizzaApp.Views;

public partial class MenuPage : ContentPage
{

    HorizontalStackLayout mainLayout = new HorizontalStackLayout {
		//Direction = Microsoft.Maui.Layouts.FlexDirection.Column,
		//JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround,
  //      AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.End,
  //      AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,

        BackgroundColor = Colors.Teal,
    };


    dynamic emptyViewLabel = new Label
    {
        Text = "No pizzas available",
        HorizontalOptions = LayoutOptions.Fill,
        VerticalOptions = LayoutOptions.Fill
    };
    public MenuPage()
	{
		Title = "PizzaWay Menu";

        dynamic availablePizza = Pizza.GetAvailablePizzas();

        CollectionView menuCollectionView = new CollectionView
        {
            ItemsSource = availablePizza,
            EmptyView = emptyViewLabel,
            ItemsLayout = LinearItemsLayout.Horizontal,
            //ItemsLayout = new GridItemsLayout(3, ItemsLayoutOrientation.Vertical),

            SelectionMode = SelectionMode.Single,
            //WidthRequest = 500,
            ItemTemplate = new DataTemplate(() =>
            {

                var nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                var detailsLabel = new Label();
                detailsLabel.SetBinding(Label.TextProperty, "Details");

                var priceLabel = new Label();
                priceLabel.SetBinding(Label.TextProperty, "Price");

                var image = new Image { Source = "placeholder.png", WidthRequest = 150, HeightRequest=100};
                //image.SetBinding(Image.SourceProperty, "Img");

                var contentGrid = new Grid
                {
                    RowDefinitions = {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        
                    },
                    ColumnDefinitions = {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },


                    },
                    ColumnSpacing = 10,
                    RowSpacing = 10,
                    
                    //BackgroundColor = Colors.Blue,
                    //Children = { nameLabel, detailsLabel, priceLabel, image },
                    Padding = new Thickness(10)
                };

                var viewGrid = new Grid
                {
                    

                    RowDefinitions = {
                        new RowDefinition { Height = new GridLength(.5, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(.25, GridUnitType.Star) },
                        new RowDefinition{ Height = GridLength.Auto},

                    },
                    ColumnDefinitions = {
                        new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star) },
                        //new ColumnDefinition (),


                    },
                    
                    ColumnSpacing = 3,
                    //WidthRequest = 250,
                    //HeightRequest = 200,
                    RowSpacing = 3,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Padding = new Thickness(10)
                };

                viewGrid.Add(image, 0, 0);
                viewGrid.Add(nameLabel, 0, 1);
                viewGrid.Add(priceLabel, 0, 3);
                viewGrid.Add(detailsLabel, 0, 2);


                contentGrid.Add(viewGrid, 0, 0);

                contentGrid.SetColumnSpan(viewGrid, 1);
                contentGrid.SetRowSpan(viewGrid, 1);
                return viewGrid;
            })

        };

        menuCollectionView.SelectionChanged += OnCollectionViewSelectionChanged;
        //menuCollectionView.SetBinding(ItemsView.ItemsSourceProperty, "availablePizza");
        mainLayout.Add(new HorizontalStackLayout { Children = { menuCollectionView } });
        Content = mainLayout;


    }
    
    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //string previous = (e.PreviousSelection.FirstOrDefault() as Monkey)?.Name;
        Pizza currentPizza = (e.CurrentSelection.FirstOrDefault() as Pizza);
        await Shell.Current.GoToAsync(nameof(OrderPage), true,
              new Dictionary<string, object>{
                    { "Pizza", currentPizza }
              });
        //await DisplayAlert($"hi", $"Pizza is {current}", "Ok");

    }
}
