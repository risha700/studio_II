using System;
using Newtonsoft.Json;
using PizzaRito.Entity.Models;

namespace PizzaRito.Utilities;

public  class Helpers : ContentView
{

    public static LinearGradientBrush CreateGradient()
    {
        var gradientBrush = new LinearGradientBrush
        {
            StartPoint = new Point(0, 0),
            EndPoint = new Point(0, 1)
        };
        gradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0));
        gradientBrush.GradientStops.Add(new GradientStop(Colors.Violet, (float)0.3));
        gradientBrush.GradientStops.Add(new GradientStop(Colors.Pink, 1));
        return gradientBrush;
    }

    public static dynamic DeepCopy(dynamic targetObject)
    {
        var serializerSettings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };
        return JsonConvert.DeserializeObject<Pizza>(JsonConvert.SerializeObject(targetObject, serializerSettings), serializerSettings);
    }
    public async static Task NavigateTo(dynamic ToPage,INavigation navigation, dynamic dict = null, int popLevel=1)
    {
        // maui bug on catalyst.
        // Get current page
        var navstack = navigation.NavigationStack.ToList();
        //var page = navigation.NavigationStack.LastOrDefault();
        //if (popLevel > navstack.Count() - 1) popLevel = 1;

        Page page=null;
        while (popLevel > 0)
        {
            page = navstack[^popLevel];
            popLevel -= 1;

        }
        // Remove old page very baaaad perfemance
        navigation.RemovePage(page);
        await Shell.Current.GoToAsync(ToPage, true, dict);
        //await Shell.Current.GoToAsync(nameof(ToPage), true, dict);
    }
}
