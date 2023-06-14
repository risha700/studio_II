using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;
using PizzaRito.Entity;
using PizzaRito.Entity.Models;



namespace PizzaRito.Views;

public partial class MenuPage : ContentPage
{

    AppDbContext databaseContext;
    CollectionView menuCollectionView;

    public MenuPage(AppDbContext dbCtx)
    {

        databaseContext = dbCtx;

        Title = "Menu";

        List<Pizza> availablePizza = dbCtx.Pizzas.OrderBy(e => e.Name).Include(p => p.Size).Include(p => p.Toppings).ToList();

        menuCollectionView = new CollectionView
        {
            ItemSizingStrategy = ItemSizingStrategy.MeasureFirstItem,
            SelectionMode = SelectionMode.Single,
            Margin = new Thickness(20, 0),
            ItemsSource = availablePizza,
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            HeaderTemplate = new DataTemplate(() => {

                return new StackLayout
                {
                    Padding = new Thickness(0, 30),
                    Children = { new Label { Text = "Available Pizzas", FontAttributes = FontAttributes.Bold, FontSize = 30 } }
                };
            }),
            Header ="",
            EmptyView = new Label
            {
                Text = "No pizzas available",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            },

            ItemsLayout = new GridItemsLayout((int)availablePizza.Count / 2, ItemsLayoutOrientation.Vertical)
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
        Content = menuCollectionView;


    }
    
    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentPizza = (e.CurrentSelection.FirstOrDefault() as Pizza);

        currentPizza.Id = Guid.NewGuid(); // way to uniquely identify every new pizza
        

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
