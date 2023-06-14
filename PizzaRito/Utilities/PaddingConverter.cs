using System;
using System.Collections.ObjectModel;
using System.Globalization;
using PizzaRito.Entity.Models;

namespace PizzaRito.Utilities
{
	public class PaddingConverter:IMultiValueConverter
	{
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] is ObservableCollection<Topping> toppings && values[1] is Topping currentItem)
            {
                //var longesWord = toppings.OrderByDescending(i => i.Name.Length).FirstOrDefault().Name.Length;
                var itemLenght = currentItem.Name.Length-currentItem.Price.ToString().Length;
                var setPadding = (int divisor, int dividend) => divisor - (dividend % divisor);
                return currentItem.Price.ToString("C2").PadLeft(setPadding(20, itemLenght) , '.'); // why all that todo: refactor to grid
                

            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

