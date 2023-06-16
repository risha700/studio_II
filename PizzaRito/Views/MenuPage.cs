using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;
using PizzaRito.Entity;
using PizzaRito.Entity.Models;
using PizzaRito.ViewModels;

namespace PizzaRito.Views;

public partial class MenuPage : ContentPage
{

    CollectionView menuCollectionView;
    Button gotoCartBtn = new Button { Text = "Your Cart", WidthRequest=100 };

    //public List<Pizza> availablePizza;

    public MenuPage(MenuViewModel vm)
    {
        
        Title = "Menu";
        BindingContext = vm;
        
        menuCollectionView = new CollectionView
        {
            ItemSizingStrategy = ItemSizingStrategy.MeasureFirstItem,
            SelectionMode = SelectionMode.Single,
            Margin = new Thickness(20, 0),
            ItemsSource = vm.availablePizza,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            HeaderTemplate = new DataTemplate(() => {

                return new StackLayout
                {
                    Spacing=30,
                    Padding = new Thickness(0, 30),
                    Children = { new Label { Text = "Available Pizzas", FontAttributes = FontAttributes.Bold, FontSize = 30 }, gotoCartBtn }
                };
            }),
            Header = "",
            EmptyView = new Label
            {
                Text = "No pizzas available",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            },

            ItemsLayout = new GridItemsLayout((int)vm.availablePizza.Count / 2, ItemsLayoutOrientation.Vertical)
            {
                VerticalItemSpacing = 20,
                HorizontalItemSpacing = 20,
            },

            ItemTemplate = new DataTemplate(() =>
            {

                var nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                var detailsLabel = new Label();
                detailsLabel.SetBinding(Label.TextProperty, "Details");

                var priceLabel = new Label();
                priceLabel.SetBinding(Label.TextProperty, "Price");

                var image = new Image { Source = "logo.png", WidthRequest = 150, HeightRequest = 100 };
                //image.SetBinding(Image.SourceProperty, "Img");
                var layout = new Border
                {
                    //Margin = new Thickness(0, 0, 0, 50),
                    StrokeThickness = 2,
                    Padding = new Thickness(10, 10),
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Content = new FlexLayout
                    {
                        Direction = Microsoft.Maui.Layouts.FlexDirection.Column,
                        JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround,
                        AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
                        AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Center,
                        Wrap = Microsoft.Maui.Layouts.FlexWrap.NoWrap,
                        Children = { nameLabel, image, detailsLabel, priceLabel }
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
            })

        };

        menuCollectionView.SelectionChanged += OnCollectionViewSelectionChanged;

        gotoCartBtn.Clicked += async (s, o) =>
        {
            await Shell.Current.GoToAsync(nameof(OrderReviewPage), true,
                new Dictionary<string, object>{
                        { "CurrentOrder", vm.CurrentOrder }
            });
            //await Shell.Current.Navigation.PushModalAsync(new OrderReviewPage());
            //await Application.Current.MainPage.Navigation.PushModalAsync(new OrderReviewPage());
        };

  
        Content = menuCollectionView;



    }

    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentPizza = (e.CurrentSelection.FirstOrDefault() as Pizza);

        currentPizza.Id = Guid.NewGuid(); // way to uniquely identify every new pizza

        //if (currentPizza.Toppings is null) currentPizza.Toppings = new();
        //if (currentPizza.Size is null) currentPizza.Size = new();

        if (currentPizza != null)
        {
            await Shell.Current.GoToAsync(nameof(OrderPage), true,
               new Dictionary<string, object>{
                        { "CurrentPizza", currentPizza }
               });
        }
        menuCollectionView.SelectedItem = null; // reset

    }



}
