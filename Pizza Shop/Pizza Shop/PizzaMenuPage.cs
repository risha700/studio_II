using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pizza_Shop
{
    public partial class PizzaMenuPage : Form
    {
        public PizzaMenuPage()
        {
            InitializeComponent();
            panelCenter.BackColor = Color.FromArgb(130, panelCenter.BackColor);
            panel1.BackColor = Color.FromArgb(130, panelCenter.BackColor);
            panel2.BackColor = Color.FromArgb(130, panelCenter.BackColor);
        }

        private void buttonLoginTab_Click_1(object sender, EventArgs e)
        {
            ColdDrinksMenuPage ColdDrinks = (ColdDrinksMenuPage)Application.OpenForms["ColdDrinksMenuPage"];
            if (ColdDrinks == null) // Creating a form if it doesnt exist
            {
                ColdDrinks = new ColdDrinksMenuPage();
                this.Hide();
                ColdDrinks.Show();
            }
            else
            {
                this.Hide();
                ColdDrinks.Show();
            }
        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
