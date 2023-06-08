using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Shop
{
    public partial class WelcomePage : Form
    {
        PizzaMenuPage PizzaMenu;
        TrackOrderPage TrackOrder;
        public WelcomePage()
        {
            InitializeComponent();
            PizzaMenu = new PizzaMenuPage();
            TrackOrder = new TrackOrderPage();
        }

        private void buttonMakeOrder_Click(object sender, EventArgs e)
        {
            PizzaMenu.Show();
            this.Hide();
        }

        private void buttonTrackOrder_Click(object sender, EventArgs e)
        {
            TrackOrder.Show();
            this.Hide();
        }

        private void pictureBoxProfileIcon_Click(object sender, EventArgs e)
        {
            LoginPage LogPage = (LoginPage)Application.OpenForms["LoginPage"];
            if (LogPage == null) // Creating a form if it doesnt exist
            {
                LogPage = new LoginPage();
                this.Hide();
                LogPage.Show();
            }
            else
            {
                this.Hide();
                LogPage.Show();
            }
        }

        private void pictureBoxPizzaShop_Click(object sender, EventArgs e)
        {

        }
    }
}
