using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Pizza_Shop
{
    public partial class CartPage : Form
    {
        public CartPage()
        {
            InitializeComponent();      
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxPizzaShop_Click(object sender, EventArgs e)
        {
            PizzaMenuPage Menu = (PizzaMenuPage)Application.OpenForms["PizzaMenuPage"];
            if (Menu == null) // Creating a form if it doesnt exist
            {
                Menu = new PizzaMenuPage();
                this.Hide();
                Menu.Show();
            }
            else
            {
                this.Hide();
                Menu.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PizzaMenuPage Menu = (PizzaMenuPage)Application.OpenForms["PizzaMenuPage"];
            if (Menu == null) // Creating a form if it doesnt exist
            {
                Menu = new PizzaMenuPage();
                this.Hide();
                Menu.Show();
            }
            else
            {
                this.Hide();
                Menu.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TrackOrderPage track = (TrackOrderPage)Application.OpenForms["TrackOrderPage"];
            if (track == null) // Creating a form if it doesnt exist
            {
                track = new TrackOrderPage();
                this.Hide();
                track.Show();
            }
            else
            {
                this.Hide();
                track.Show();
            }
        }

        private void CartPage_Load(object sender, EventArgs e)
        {
            DisplayCartItems();
        }

        private void DisplayCartItems()
        {
            // Clear existing items in the ListView
            listViewCart.Items.Clear();

            // Access the shared cart instances from PizzaMenuPage and ColdDrinksMenuPage
            CartMenu pizzaCart = PizzaMenuPage.PizzaCart;
            CartMenu coldDrinkCart = ColdDrinksMenuPage.ColdDrinkCart;

            // Display pizza items
            foreach (Pizza pizza in pizzaCart.GetPizzas())
            {
                // Add pizza item to the ListView
                ListViewItem pizzaItem = new ListViewItem(pizza.Name);
                pizzaItem.SubItems.Add(pizza.Size);
                pizzaItem.SubItems.Add(string.Join(", ", pizza.Toppings));
                pizzaItem.SubItems.Add(pizza.Price.ToString());

                listViewCart.Items.Add(pizzaItem);
            }

            // Display cold drink items
            foreach (ColdDrink coldDrink in coldDrinkCart.GetColdDrinks())
            {
                // Add cold drink item to the ListView
                ListViewItem coldDrinkItem = new ListViewItem(coldDrink.Name);
                coldDrinkItem.SubItems.Add(coldDrink.Size);
                coldDrinkItem.SubItems.Add(string.Empty);  // Toppings column is empty for cold drinks
                coldDrinkItem.SubItems.Add(coldDrink.Price.ToString());

                listViewCart.Items.Add(coldDrinkItem);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayCartItems();
        }
    }
}
