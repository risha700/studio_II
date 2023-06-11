﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaRito.Entity;

namespace PizzaRito.ViewModels
{
	public partial class BaseViewModel:ObservableObject
	{
	
		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		bool isBusy;

		public bool IsNotBusy => !IsBusy;
	}
}

