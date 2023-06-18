﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PizzaRito.Entity;
using PizzaRito.Entity.Models;

namespace PizzaRito.ViewModels;

public partial class MenuViewModel:BaseViewModel
{
    public AppDbContext databaseContext;

    
    public List<Pizza> availablePizza;


    [ObservableProperty]
    public Order currentOrder;


 
    public MenuViewModel(AppDbContext dbCtx, OrderViewModel orderVm)
	{

        //dbCtx.Pizzas.OrderBy(e => e.Name).Include(p => p.Size).Include(p => p.Toppings).Load();

        //availablePizza = dbCtx.Pizzas.Local.OrderBy(e => e.Name).ToList();
        //dbCtx.Entry(availablePizza).State = EntityState.Detached;
        dbCtx.Pizzas.Where(e => e.IsCatalouge).Include(p => p.CrustSize).Include(p => p.Toppings).Load();
        availablePizza = dbCtx.Pizzas.Where(e => e.IsCatalouge).ToList();
        CurrentOrder = orderVm.CurrentOrder;

    }


}

