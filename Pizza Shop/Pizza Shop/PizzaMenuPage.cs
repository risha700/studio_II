using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Pizza_Shop
{
    public partial class PizzaMenuPage : Form
    {
        public  static CartMenu PizzaCart { get; set; }
        public PizzaMenuPage()
        {
            InitializeComponent();

            if (PizzaCart == null)
                PizzaCart = new CartMenu();

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

        private void button1_Click(object sender, EventArgs e)
        {
            Pizza pizza1 = new Pizza();

            pizza1.Name = label1.Text;
            double pizzaPrice = 0;

            bool pizzaSizeSelected = false;

            if ( radioButton1.Checked)
            {
                pizza1.Size = radioButton1.Text;
                pizzaPrice += 5;
                pizzaSizeSelected = true;
            }
            else if ( radioButton2.Checked)
            {
                pizza1.Size = radioButton2.Text;
                pizzaPrice += 8;
                pizzaSizeSelected = true;
            }
            else if( radioButton3.Checked)
            {
                pizza1.Size = radioButton3.Text;
                pizzaPrice += 11;
                pizzaSizeSelected = true;
            }
            else 
            {
                pizzaSizeSelected= false;
            }

            if ( checkBox1.Checked)
            {
                pizza1.Toppings.Add(checkBox1.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox2.Checked)
            {
                pizza1.Toppings.Add(checkBox2.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox3.Checked)
            {
                pizza1.Toppings.Add(checkBox3.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox4.Checked)
            {
                pizza1.Toppings.Add(checkBox4.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox5.Checked)
            {
                pizza1.Toppings.Add (checkBox5.Text);
                pizzaPrice += 2.5;
            }

            pizza1.Price = pizzaPrice;
            
            if (!pizzaSizeSelected)
            {
                MessageBox.Show("Please select a size of pizza base please");
            }
            else
            {
                PizzaCart.AddPizzaToCart(pizza1);

                MessageBox.Show($"Pizza Added Successfully ! \n Pizza Cost: {pizzaPrice}");

                foreach (Control x in panelCenter.Controls)
                {
                    if (x is CheckBox chechbox)
                    {
                        chechbox.Checked = false;
                    }

                    if (x is RadioButton radiobutton)
                    {
                        radiobutton.Checked = false;
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pizza pizza2 = new Pizza();

            pizza2.Name = label8.Text;
            double pizzaPrice = 0;

            bool pizzaSizeSelected = false;

            if (radioButton6.Checked)
            {
                pizza2.Size = radioButton6.Text;
                pizzaPrice += 5;
                pizzaSizeSelected = true;
            }
            else if (radioButton5.Checked)
            {
                pizza2.Size = radioButton5.Text;
                pizzaPrice += 8;
                pizzaSizeSelected = true;
            }
            else if (radioButton4.Checked)
            {
                pizza2.Size = radioButton4.Text;
                pizzaPrice += 11;
                pizzaSizeSelected = true;
            }
            else
            {
                pizzaSizeSelected = false;
            }

            if (checkBox10.Checked)
            {
                pizza2.Toppings.Add(checkBox10.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox9.Checked)
            {
                pizza2.Toppings.Add(checkBox9.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox8.Checked)
            {
                pizza2.Toppings.Add(checkBox8.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox7.Checked)
            {
                pizza2.Toppings.Add(checkBox7.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox6.Checked)
            {
                pizza2.Toppings.Add(checkBox6.Text);
                pizzaPrice += 2.5;
            }

            pizza2.Price = pizzaPrice;

            if (!pizzaSizeSelected)
            {
                MessageBox.Show("Please select a size of pizza base please");
            }
            else
            {
                PizzaCart.AddPizzaToCart(pizza2);

                MessageBox.Show($"Pizza Added Successfully ! \n Pizza Cost: {pizzaPrice}");

                foreach (Control x in panel1.Controls)
                {
                    if (x is CheckBox chechbox)
                    {
                        chechbox.Checked = false;
                    }

                    if (x is RadioButton radiobutton)
                    {
                        radiobutton.Checked = false;
                    }
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pizza pizza3 = new Pizza();

            pizza3.Name = label12.Text;
            double pizzaPrice = 0;

            bool pizzaSizeSelected = false;

            if (radioButton9.Checked)
            {
                pizza3.Size = radioButton9.Text;
                pizzaPrice += 5;
                pizzaSizeSelected = true;
            }
            else if (radioButton8.Checked)
            {
                pizza3.Size = radioButton8.Text;
                pizzaPrice += 8;
                pizzaSizeSelected = true;
            }
            else if (radioButton7.Checked)
            {
                pizza3.Size = radioButton7.Text;
                pizzaPrice += 11;
                pizzaSizeSelected = true;
            }
            else
            {
                pizzaSizeSelected = false;
            }

            if (checkBox15.Checked)
            {
                pizza3.Toppings.Add(checkBox15.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox14.Checked)
            {
                pizza3.Toppings.Add(checkBox14.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox13.Checked)
            {
                pizza3.Toppings.Add(checkBox13.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox12.Checked)
            {
                pizza3.Toppings.Add(checkBox12.Text);
                pizzaPrice += 2.5;
            }
            if (checkBox11.Checked)
            {
                pizza3.Toppings.Add(checkBox11.Text);
                pizzaPrice += 2.5;
            }

            pizza3.Price = pizzaPrice;

            if (!pizzaSizeSelected)
            {
                MessageBox.Show("Please select a size of pizza base please");
            }
            else
            {
                PizzaCart.AddPizzaToCart(pizza3);

                MessageBox.Show($"Pizza Added Successfully ! \n Pizza Cost: {pizzaPrice}");

                foreach (Control x in panel2.Controls)
                {
                    if (x is CheckBox chechbox)
                    {
                        chechbox.Checked = false;
                    }

                    if (x is RadioButton radiobutton)
                    {
                        radiobutton.Checked = false;
                    }
                }
            }


        }
    }
}
