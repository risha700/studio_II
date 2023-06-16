using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaRito.Entity;

namespace PizzaRito.ViewModels
{
	public partial class BaseViewModel:ObservableObject
	{
		bool isBusy;

		public bool IsBusy
		{
			get => isBusy;
			set => SetProperty(ref isBusy, value);
		}
	}
}

