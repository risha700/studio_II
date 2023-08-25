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
using System.Data.SQLite;
using System.Net.Http.Headers;
using Pizza_Shop.Properties;
using System.IO;

namespace Pizza_Shop
{
    public partial class RegisterPage : Form
    {
        //private SQLiteConnection CustomerDatabase;
        private bool PasswordValidated;
        private bool EmailValidated;
        public RegisterPage()
        {
            InitializeComponent();

            PasswordValidated = false;
            EmailValidated = false;

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
                EmailValidated = true;
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
            else
            {
                PasswordValidated = true;
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

        private void WriteCustomerDataToCustomerDatabase()
        {

            //string FirstName = textBoxFirstName.Text;
            //string LastName = textBoxLastName.Text;
            //string Email = textBoxEmailID.Text;
            //int MobileNumber = Convert.ToInt32(textBoxMobileNumber.Text);
            //string Password = textBoxPassword.Text;
            //DateTime DOB = dateTimePickerDOB.Value;
            //string Gender = comboBoxGender.SelectedItem.ToString();


            
          //  CustomerDatabase.Open();

         //   string createTableQuery = @"CREATE TABLE IF NOT EXISTS Customer (
           //     ID INTEGER PRIMARY KEY AUTOINCREMENT,
          //      FirstName TEXT NOT NULL,
          //      LastName TEXT NOT NULL,
          //      Email TEXT NOT NULL,
          //      MobileNumber INTEGER NOT NULL,
          //      Password TEXT NOT NULL,
         //       DateOfBirth TEXT NOT NULL,
         //       Gender TEXT NOT NULL
         //   );";

           // SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, CustomerDatabase);
          //  createTableCommand.ExecuteNonQuery();


            //string insertCommand = "INSERT INTO Customer (FirstName, LastName, Email, MobileNumber, Password, DateOfBirth, Gender)" +
            //    $"Values (@FirstName, @LastName, @Email, @MobileNumber, @Password, @DOB, @Gender)";

           // SQLiteCommand addCustomerData = new SQLiteCommand(insertCommand, CustomerDatabase);

           // addCustomerData.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
           // addCustomerData.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
          //  addCustomerData.Parameters.AddWithValue("@Email", textBoxEmailID.Text);
          //  addCustomerData.Parameters.AddWithValue("@MobileNumber", textBoxMobileNumber.Text);
           // addCustomerData.Parameters.AddWithValue("@Password", textBoxPassword.Text);
           // addCustomerData.Parameters.AddWithValue("@DOB", dateTimePickerDOB.Value.ToString());
           // addCustomerData.Parameters.AddWithValue("@Gender", comboBoxGender.SelectedItem.ToString());


          //  int rowsAffected = addCustomerData.ExecuteNonQuery();

        //    if (rowsAffected > 0)
         //   {
                // Insert successful
         //       labelRegisterMessage.Visible = true;
         //       labelRegisterMessage.Text = "Registration successful!";
         //   }
          //  else
          //  {
                // Insert failed
           //     labelRegisterMessage.Visible = true;
            //    labelRegisterMessage.Text = "Registration failed! Try Again Please";
          //  }

            
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {
          //  string connectionString = "Data Source=F:\\Otago Polytechnic\\Level 5\\Study Block 2\\Studio 2\\Project\\studio_II\\Pizza Shop\\Databases\\CustomerInformationDatabase.db";
            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string relativePath = @"Databases\CustomerInformationDatabase.db";
            //string databasePath = Path.Combine(baseDirectory, relativePath);

            //string connectionString = $"Data Source={databasePath}";

           // CustomerDatabase = new SQLiteConnection(connectionString);

           // labelRegisterMessage.Font = new Font(labelRegisterMessage.Font.FontFamily, 12, FontStyle.Regular);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Perform validation
            if (string.IsNullOrEmpty(textBoxFirstName.Text) ||
                string.IsNullOrEmpty(textBoxLastName.Text) ||
                string.IsNullOrEmpty(textBoxEmailID.Text) ||
                string.IsNullOrEmpty(textBoxMobileNumber.Text) ||
                string.IsNullOrEmpty(textBoxPassword.Text) ||
                comboBoxGender.SelectedItem == null ||
                dateTimePickerDOB.Value == DateTimePicker.MinimumDateTime || 
                dateTimePickerDOB.Value == DateTimePicker.MaximumDateTime
               )
            {
                labelRegisterMessage.Visible = true;
                labelRegisterMessage.Text = "Please fill all fields. All fields are mandatory!";
            }
            else
            {
               // WriteCustomerDataToCustomerDatabase();
            }
        }

        private void textBoxMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Prevent the input of non-digit characters
                e.Handled = true;
            }
        }
    }
}
