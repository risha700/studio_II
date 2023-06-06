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
    }
}
