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
    public partial class TrackOrderPage : Form
    {
        public TrackOrderPage()
        {
            InitializeComponent();
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            WelcomePage Wel = (WelcomePage)Application.OpenForms["WelcomePage"];
            if (Wel == null) // Creating a form if it doesnt exist
            {
                Wel = new WelcomePage();
                this.Hide();
                Wel.Show();
            }
            else
            {
                this.Hide();
                Wel.Show();
            }
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
    }
}
