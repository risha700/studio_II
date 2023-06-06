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
    public partial class ColdDrinksMenuPage : Form
    {
        public ColdDrinksMenuPage()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(130, panel1.BackColor);
            panel2.BackColor = Color.FromArgb(130, panel2.BackColor);
            panel3.BackColor = Color.FromArgb(130, panel3.BackColor);
        }

        private void buttonLoginTab_Click(object sender, EventArgs e)
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
