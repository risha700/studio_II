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
    public partial class ColdDrinksMenuPage : Form
    {
        public static CartMenu ColdDrinkCart { get; set; }
        public ColdDrinksMenuPage()
        {
            InitializeComponent();
            panel3.BackColor = Color.FromArgb(130, panel1.BackColor);
            panel4.BackColor = Color.FromArgb(130, panel2.BackColor);
            panel5.BackColor = Color.FromArgb(130, panel3.BackColor);

            if (ColdDrinkCart == null)
                ColdDrinkCart = new CartMenu();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ColdDrink coldDrink1 = new ColdDrink();

            coldDrink1.Name = label1.Text;
            double coldDrinkPrice = 0;

            bool coldDrinkSizeSelected = false;

            if (radioButton1.Checked)
            {
                coldDrink1.Size = radioButton1.Text;
                coldDrinkPrice += 8;
                coldDrinkSizeSelected = true;
            }
            else if (radioButton2.Checked)
            {
                coldDrink1.Size = radioButton2.Text;
                coldDrinkPrice += 5;
                coldDrinkSizeSelected = true;
            }
            else
            {
                coldDrinkSizeSelected = false;
            }

            coldDrink1.Price = coldDrinkPrice;

            if (!coldDrinkSizeSelected)
            {
                MessageBox.Show("Please select the size of the bottle please.");
            }
            else
            {
                ColdDrinkCart.AddColdDrinkToCart(coldDrink1);

                MessageBox.Show($"Drink added to cart. \n Drink Price: {coldDrinkPrice}");

                foreach (Control x in panel3.Controls)
                {
                    if (x is RadioButton radioButton)
                    {
                        radioButton.Checked = false;
                    }
                }

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColdDrink coldDrink2 = new ColdDrink();

            coldDrink2.Name = label11.Text;
            double coldDrinkPrice = 0;

            bool coldDrinkSizeSelected = false;

            if (radioButton8.Checked)
            {
                coldDrink2.Size = radioButton8.Text;
                coldDrinkPrice += 8;
                coldDrinkSizeSelected = true;
            }
            else if (radioButton7.Checked)
            {
                coldDrink2.Size = radioButton7.Text;
                coldDrinkPrice += 5;
                coldDrinkSizeSelected = true;
            }
            else
            {
                coldDrinkSizeSelected = false;
            }

            coldDrink2.Price = coldDrinkPrice;

            if (!coldDrinkSizeSelected)
            {
                MessageBox.Show("Please select the size of the bottle please.");
            }
            else
            {
                ColdDrinkCart.AddColdDrinkToCart(coldDrink2);

                MessageBox.Show($"Drink added to cart. \n Drink Price: {coldDrinkPrice}");

                foreach (Control x in panel4.Controls)
                {
                    if (x is RadioButton radioButton)
                    {
                        radioButton.Checked = false;
                    }
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColdDrink coldDrink3 = new ColdDrink();

            coldDrink3.Name = label15.Text;
            double coldDrinkPrice = 0;

            bool coldDrinkSizeSelected = false;

            if (radioButton10.Checked)
            {
                coldDrink3.Size = radioButton10.Text;
                coldDrinkPrice += 8;
                coldDrinkSizeSelected = true;
            }
            else if (radioButton9.Checked)
            {
                coldDrink3.Size = radioButton9.Text;
                coldDrinkPrice += 5;
                coldDrinkSizeSelected = true;
            }
            else
            {
                coldDrinkSizeSelected = false;
            }

            coldDrink3.Price = coldDrinkPrice;

            if (!coldDrinkSizeSelected)
            {
                MessageBox.Show("Please select the size of the bottle please.");
            }
            else
            {
                ColdDrinkCart.AddColdDrinkToCart(coldDrink3);

                MessageBox.Show($"Drink added to cart. \n Drink Price: {coldDrinkPrice}");

                foreach (Control x in panel5.Controls)
                {
                    if (x is RadioButton radioButton)
                    {
                        radioButton.Checked = false;
                    }
                }
            }
        }
    }
}
