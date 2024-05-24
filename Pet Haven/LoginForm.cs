using PetHaven;  // Importing external namespace PetHaven.

using System;  // Importing system namespace for core functionality.
using System.Data;  // Importing system namespace for data handling.
using System.Data.SqlClient;  // Importing system namespace for SQL Server database connectivity.
using System.Windows.Forms;  // Importing system namespace for Windows Forms.

namespace Pet_Haven
{
    public partial class LoginForm : Form
    {
        SqlConnection cn = new SqlConnection();  // Creating SqlConnection object for database connection.
        SqlCommand cm = new SqlCommand();  // Creating SqlCommand object for executing SQL queries.
        DbConnect dbcon = new DbConnect();  // Creating DbConnect object for database connection details.
        SqlDataReader dr;  // Creating SqlDataReader object for reading data from database.
        string title = "Pet Haven";  // Declaring and initializing string variable for form title.
        private string message;  // Declaring private string variable to store message.

        public LoginForm()
        {
            InitializeComponent();  // Initializing form components defined in designer.
            cn = new SqlConnection(dbcon.connection());  // Initializing SqlConnection object with database connection string.
        }

        public LoginForm(string message) : this()
        {
            this.message = message;  // Overloaded constructor to initialize message variable.
        }

        // Event handler for form load event.
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Display any message passed from another form
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);  // Showing message box with information message.
            }
        }

        // Event handler for Exit button click.
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();  // Exiting the application on confirmation.
            }
        }

        // Event handler for Login button click.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string _name = "", _role = "";  // Declaring variables to store username and role.

                cn.Open();  // Opening database connection.
                cm = new SqlCommand("SELECT name, role FROM tbl_Employee WHERE BINARY_CHECKSUM(name) = BINARY_CHECKSUM(@name) AND BINARY_CHECKSUM(password) = BINARY_CHECKSUM(@password)", cn);  // Creating SqlCommand with parameterized SQL query.
                cm.Parameters.AddWithValue("@name", txtUsername.Text);  // Adding parameter for username.
                cm.Parameters.AddWithValue("@password", txtPassword.Text);  // Adding parameter for password.
                dr = cm.ExecuteReader();  // Executing query and initializing SqlDataReader.

                dr.Read();  // Reading data from SqlDataReader.
                if (cn.State == ConnectionState.Closed)  // Checking if database connection is closed.
                {
                    cn.Open();  // Opening database connection.
                }

                if (dr.HasRows)  // Checking if SqlDataReader has rows (valid username and password).
                {
                    _name = dr["name"].ToString();  // Retrieving username from SqlDataReader.
                    _role = dr["role"].ToString();  // Retrieving role from SqlDataReader.
                    MessageBox.Show("Welcome " + _name + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Showing welcome message.
                    MainForm main = new MainForm(_name, _role);  // Creating instance of MainForm with username and role.
                    this.Hide();  // Hiding current login form.
                    main.ShowDialog();  // Showing MainForm.
                }
                else
                {
                    MessageBox.Show("Invalid username and password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // Showing invalid credentials message.
                }

                dr.Close();  // Closing SqlDataReader.
                cn.Close();  // Closing database connection.
            }
            catch (Exception ex)
            {
                dr.Close();  // Closing SqlDataReader on exception.
                cn.Close();  // Closing database connection on exception.
                MessageBox.Show(ex.Message, title);  // Showing error message in MessageBox.
            }
        }

        // Event handler for Username TextBox text changed event.
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // No specific action needed in this method.
        }

        // Event handler for Password TextBox text changed event.
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // No specific action needed in this method.
        }
    }
}
