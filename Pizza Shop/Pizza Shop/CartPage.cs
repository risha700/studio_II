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
        PizzaMenuPage mainCart;
        public CartPage()
        {
            InitializeComponent();
            ////Form form = new Form();
            ////form = mainCart;
            
            //panelCenter.BackColor = Color.FromArgb(130, panelCenter.BackColor);

            //// Attach the event handler
            //treeViewCart.NodeMouseDoubleClick += treeViewCart_NodeMouseDoubleClick;

            //// Populate the tree view with cart items
            //PopulateTreeView();
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

        //private void PopulateTreeView()
        //{
        //    // Assuming you have a cart object
        //    foreach (Pizza pizza in cart.Pizzas)
        //    {
        //        TreeNode pizzaNode = new TreeNode(pizza.Name);

        //        // Add toppings as child nodes
        //        foreach (string topping in pizza.Toppings)
        //        {
        //            TreeNode toppingNode = new TreeNode(topping);
        //            pizzaNode.Nodes.Add(toppingNode);
        //        }

        //        // Add the pizza node to the tree view
        //        treeViewCart.Nodes.Add(pizzaNode);
        //    }
        //}

        //private void RemoveSelectedItem()
        //{
        //    TreeNode selectedNode = treeViewCart.SelectedNode;

        //    if (selectedNode != null)
        //    {
        //        // Remove the item from the cart
        //        selectedNode.Remove();

        //        // Perform any additional actions or updates
        //        // ...

        //        MessageBox.Show("Item removed from cart.");
        //    }
        //}

        //private void treeViewCart_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    RemoveSelectedItem();
        //}

    }
}
