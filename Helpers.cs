
using System;
namespace PizzaApp
{
	public class Helpers:ContentView
	{

        public static LinearGradientBrush CreateGradient()
        {
            var gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Violet, (float)0.5));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Pink, 1));
            return gradientBrush;
        }



    }
}

