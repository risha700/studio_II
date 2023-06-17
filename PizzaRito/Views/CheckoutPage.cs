using System.ComponentModel;
using PizzaRito.Entity.Models;
using PizzaRito.ViewModels;

namespace PizzaRito.Views;


[QueryProperty(nameof(CurrentOrder), "CurrentOrder")]
public class CheckoutPage : ContentPage, INotifyPropertyChanged
{
	Button cashPayBtn = new Button { Text = "Cash", BackgroundColor = Colors.LawnGreen, WidthRequest = 250, HeightRequest = 250, FontSize = 30 };
	Label orderId = new Label {Text="Order# ", FontSize=15 };
    Label orderTotal = new Label {Text="Total: ", FontSize = 22, FontAttributes=FontAttributes.Bold };

    Order currentOrder;

	public Order CurrentOrder
	{
		get => currentOrder;
		set
		{
			if (value != null)
				currentOrder = value;
			OnPropertyChanged(nameof(CurrentOrder));
		}
	}

	CheckoutViewModel CheckoutVm;
	public CheckoutPage(CheckoutViewModel vm)
	{
		CheckoutVm = vm;
        Content = new StackLayout
		{
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Start,
			Spacing=200,
			Children =
			{
				orderId,
				orderTotal,
				new Label{ Text="Payment Method", FontSize=30, FontAttributes=FontAttributes.Bold, HorizontalOptions=LayoutOptions.Center, },
				new FlexLayout{
					Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
					JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround,
					AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Center,
					AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center,
					Children={
                        cashPayBtn,
                        new Button { Text="Digital", IsEnabled=false, BackgroundColor=Colors.SlateGray, WidthRequest=250, HeightRequest=250, FontSize=30},
                    }},
				
            }
		};

		Shell.Current.Navigated += (s, o) =>
		{
            
            CurrentOrder.CalculateTotal();
			orderTotal.SetBinding(Label.TextProperty, new Binding("Total", stringFormat: "Amount to pay: {0:C2}", source: CurrentOrder));
            orderId.SetBinding(Label.TextProperty, new Binding("Id", stringFormat: "Order #: {0}", source: CurrentOrder));
        };

        cashPayBtn.Clicked += CashCheckoutPayment;
	}

    private async void CashCheckoutPayment(object sender, EventArgs e)
    {
		Button doneBtn = new Button { Text = "Start Over" };
        CheckoutVm.PersistOrder(CurrentOrder);

        doneBtn.Clicked += async (s, o) =>
		{
			// shoud persist to db
            CurrentOrder.Items.Clear();
			CurrentOrder.Id = Guid.NewGuid();
            await Navigation.PopToRootAsync();
			//await Shell.Current.GoToAsync(nameof(MainPage), true);
		};
		var thanksBanner = new VerticalStackLayout {
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions =LayoutOptions.Center,
			Spacing=10,
			Children = {
                new Label { Text="Thank you for your order Please pay at kiosk 3" },
                orderId,
				orderTotal,
				doneBtn
			},
		};
		await Application.Current.MainPage.Navigation.PushModalAsync(new ContentPage { Content = thanksBanner });
    }

}
