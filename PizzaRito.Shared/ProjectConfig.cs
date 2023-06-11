using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRito.Shared;

public static class ProjectConfig
{
    
    
    static string dbPath => System.IO.Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NetApp.db");

    //public static string DatabasePath => $"Data Source={dbPath}";
    public static string DatabasePath => $"Data Source=/Users/rs/Documents/AppDb/Pizzarito.db";

}