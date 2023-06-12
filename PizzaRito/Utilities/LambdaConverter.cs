using System;
using System.Collections.ObjectModel;
using System.Globalization;
using PizzaRito.Entity.Models;

namespace PizzaRito.Utilities;

public class LambdaConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values != null && values.Length == 2 && values[0] is ObservableCollection<Topping> toppings && values[1] is Topping currentItem)
        {
            //Console.WriteLine($"DEBUG====> qualified {currentItem} " +
            //    $"contains: {toppings.Any(i=> i.ToString().Equals(currentItem.ToString()))}");
            return toppings.Any(i => i.ToString().Equals(currentItem.ToString()));
        }
        //Console.WriteLine($"DEBUG====> didnt qualify with lenght: {values.Length} ##first: {values[0]} ##second:{values[1]}");
        return false;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        //Console.WriteLine($"DEBUG====> needed to convertback: value {value} param :{parameter} ");
        return null;
    }
}