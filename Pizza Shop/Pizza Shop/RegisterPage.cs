using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Shop
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
            panelCenter.BackColor = Color.FromArgb(130, panelCenter.BackColor);

        }

        private void buttonLoginTab_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Visible = false;
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) 
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxEmailID_Validating(object sender, CancelEventArgs e)
        {
            string email = textBoxEmailID.Text;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                //e.Cancel = true;
                labelMailIDMessage.Text = ("Please enter a valid email address.");
                labelMailIDMessage.Visible = true;
                //textBoxUsername.Focus();
            }
            else
            {
                labelMailIDMessage.Text = "";
                labelMailIDMessage.Visible = false;
            }
        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                //e.Cancel = true;
                labelPasswordMessage.Text = ("Please enter a password.");
                //textBoxPassword.Focus();
            }
            else if (password.Length < 6)
            {
                //e.Cancel = true;
                labelPasswordMessage.Text = ("Password should be at least 6 characters long.");
                //textBoxPassword.Focus();
            }
            else if (!password.Any(char.IsDigit))
            {
                //e.Cancel = true;
                labelPasswordMessage.Text = ("Password should contain at least one digit.");
                //textBoxPassword.Focus();
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            labelPasswordCondition.Visible = true;
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            labelPasswordCondition.Visible = false;
        }
    }
}
