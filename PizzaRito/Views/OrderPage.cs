using PizzaRito.Entity;
using PizzaRito.ViewModels;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaRito.Entity.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.ComponentModel;
using CommunityToolkit.Maui.Markup;
using PizzaRito.Utilities;
using System.Linq;
using CommunityToolkit.Maui.Converters;
using Newtonsoft.Json;

namespace PizzaRito.Views;

public partial class OrderPage : ContentPage, INotifyPropertyChanged
{


    CollectionView availableToppingsView = new CollectionView { Header = "", EmptyView = new Label { Text = "Loading Toppings..." } };
    CollectionView currentPizzaToppingsView = new CollectionView { };
    CollectionView availableSizesView = new CollectionView {Header="Loading Sizes..." };
    Label selectedPizzaLabel = new Label { FontSize = 24, VerticalOptions = LayoutOptions.Center, Text = $"Loading..." };
    Image selectedPizzaImage = new Image { Source = "logo.png",  Aspect=Aspect.Fill};
    StackLayout selectedPizzaView = new StackLayout { Spacing=10};

    Button cancelOrderBtn = new Button { Text = "Cancel", BackgroundColor = Colors.Transparent, TextColor = Colors.OrangeRed };
    Button addToCartBtn = new Button { Text = "Add To Cart" };
    Grid contentGrid = new Grid
    {
        VerticalOptions = LayoutOptions.Start,
        HeightRequest = Shell.Current.Window.Height,
        WidthRequest = Shell.Current.Window.Width,
        ColumnSpacing = 20,
        RowSpacing = 0,
        Padding=10,
        RowDefinitions = {
                new RowDefinition {Height=new GridLength(.30, GridUnitType.Star) },
                new RowDefinition {Height=new GridLength(.40, GridUnitType.Star)},
                new RowDefinition {Height=new GridLength(.30, GridUnitType.Star)},

            },
        ColumnDefinitions = {
                new ColumnDefinition {  Width = new GridLength(.6, GridUnitType.Star) } ,
                new ColumnDefinition { Width = new GridLength(.4, GridUnitType.Star) },
            },

    };
    Frame orderBox = new Frame { BackgroundColor=Colors.Transparent };
    Label selectedPizzaSizeLabel = new Label { FontSize = 16 };

    
    JsonSerializerSettings serializerSettings = new JsonSerializerSettings
    {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
    };

    public OrderViewModel OrderVm { get; set; }

    public OrderPage(OrderViewModel ordervm):base()
	{

        
        
        OrderVm = ordervm;
        BindingContext = OrderVm;

        Title = "New Order";

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
        contentGrid.Add(selectedPizzaImage, 1, 0);
        
        contentGrid.Add(orderBox, 1, 1);
        contentGrid.Add(new FlexLayout
        {
            Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
            JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround,
            AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
            AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
            Children = {addToCartBtn, cancelOrderBtn}
        }, 0, 2);
        

        Content = contentGrid;

        Shell.Current.Navigated += (s,o) =>
        {
            RenderSizesView();
            RenderSelectedPizza();
            RenderToppingsView();
            cancelOrderBtn.Command = CancelOrderCommand;
            addToCartBtn.Command = AddToCartCommand;
        };

    

    }
    [RelayCommand]
    async private void CancelOrder()
    {
        var result = await Shell.Current.DisplayAlert("Are you sure?", "Cancel Order1", "Yes", "Continue Order");
        if (result)
        {
            await NavigateTo(nameof(MenuPage));
        }


    }

    [RelayCommand]
    async private void AddToCart()
    {
        if(OrderVm.CurrentPizza.Size is null)
        {
            await Shell.Current.DisplayAlert("Choose size", "To continue!", "Ok");
            return ;
        }
        var newPizza = OrderVm.CurrentPizza;

        var shallowCopy = JsonConvert.DeserializeObject<Pizza>(JsonConvert.SerializeObject(newPizza, serializerSettings), serializerSettings);
        OrderVm.CurrentOrder.Items.Add(shallowCopy);

        //Console.WriteLine($"DEBUG===> OrderPage Added to cart {newPizza}-{newPizza.Id}" );

        var result = await Shell.Current.DisplayAlert("Added", "to your order",  "Continue Ordering", "Check Out");
        if (result)
        {
            await NavigateTo(nameof(MenuPage));
        }
        else
        {
            await Shell.Current.GoToAsync(nameof(CheckoutPage), true,
               new Dictionary<string, object>{
                        { "Order", OrderVm.CurrentOrder }
               });
        }


    }
    async Task NavigateTo(dynamic ToPage, dynamic dict = null)
    {
        // Get current page
        var page = Navigation.NavigationStack.LastOrDefault();
        
        // Remove old page
        Navigation.RemovePage(page);
        
        // Load new page
        await Shell.Current.GoToAsync(nameof(ToPage), true, dict);


    }
    private void RenderSelectedPizza()
    {
        Label pizzaId = new Label { FontSize = 24 };
        pizzaId.SetBinding(Label.TextProperty, new Binding("Id", source:OrderVm.CurrentPizza));
        selectedPizzaView.Add(pizzaId);


        Label pizzaPrice = new Label { FontSize = 24 };
        selectedPizzaView.BindingContext = OrderVm.CurrentPizza;
        selectedPizzaLabel.SetBinding(Label.TextProperty, new Binding("Name"));
        selectedPizzaSizeLabel.SetBinding(Label.TextProperty, new Binding("Size"));

        selectedPizzaView.Children.Add(selectedPizzaSizeLabel);
        if (!String.IsNullOrEmpty(OrderVm.CurrentPizza.Img))
        {
            selectedPizzaImage.SetBinding(Image.SourceProperty, new Binding(".", source:OrderVm.CurrentPizza.Img, mode:BindingMode.TwoWay));
        }
        SetupCurrentPizzaToppings();
        selectedPizzaView.Children.Add(currentPizzaToppingsView);

    }

    private void SetupCurrentPizzaToppings()
    {
        currentPizzaToppingsView.ItemsSource = OrderVm.CurrentPizza.Toppings;
        
        currentPizzaToppingsView.ItemTemplate = new DataTemplate(() =>
        {
            var toppingNameLabel = new Label();
            var toppingPriceLabel = new Label();
            
            
            toppingNameLabel.SetBinding(Label.TextProperty, new Binding("Name", mode:BindingMode.Default));
     
            var binding = new MultiBinding
            {
                Converter = new PaddingConverter(),
                Mode = BindingMode.Default
            };

            binding.Bindings.Add(new Binding(nameof(OrderVm.CurrentPizza.Toppings), source: OrderVm.CurrentPizza));
            binding.Bindings.Add(new Binding(".", source: toppingNameLabel.BindingContext));
            toppingPriceLabel.SetBinding(Label.TextProperty, binding);

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
        if (OrderVm.CurrentPizza.Size is not null)
        {
            availableSizesView.SelectedItem = OrderVm.AllSizes.Single(s => s.Name == OrderVm.CurrentPizza.Size.Name);

        }

    }

    private void SizesViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var crust = e.CurrentSelection.FirstOrDefault() as CrustSize;

        OrderVm.CurrentPizza.Size = crust;

        selectedPizzaSizeLabel.SetBinding(Label.TextProperty, new Binding("Size", source: OrderVm.CurrentPizza));

        //Console.WriteLine($"SizesViewSelectionChanged {sender} {e.CurrentSelection.FirstOrDefault()}");
        //Console.WriteLine($"OrderVm.CurrentPizza.Size {OrderVm.CurrentPizza.Size}");
        

    }

    private void ToppingSelectionChanged(object sender, CheckedChangedEventArgs e)
    {
        var btn = (CheckBox)sender;
        var topping = btn.BindingContext as Topping;
        //Console.WriteLine($"ToppingSelectionChanged {topping} {e.Value}");
        if (e.Value)
        {
            if(OrderVm.CurrentPizza.Toppings.Any(i => i.ToString().Equals(topping.ToString())))
            {
                OrderVm.CurrentPizza.Toppings.Remove(
                    OrderVm.CurrentPizza.Toppings.Single(t => t.ToString().Equals(topping.ToString())));
            }
            OrderVm.CurrentPizza.Toppings.Add(topping);

          
        }
        else
        {
            while(OrderVm.CurrentPizza.Toppings.Contains(topping)) OrderVm.CurrentPizza.Toppings.Remove(topping);
        }

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
            var toppingCheckBox = new CheckBox { IsChecked=false };
            var currentItem = toppingNameLabel.BindingContext as Topping;

            var binding = new MultiBinding
            {
                Converter = new LambdaConverter(),
                Mode = BindingMode.OneWay
            };

            binding.Bindings.Add(new Binding(nameof(OrderVm.CurrentPizza.Toppings), source: OrderVm.CurrentPizza));
            binding.Bindings.Add(new Binding(".", source: toppingCheckBox.BindingContext));
            toppingCheckBox.SetBinding(CheckBox.IsCheckedProperty, binding);


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

