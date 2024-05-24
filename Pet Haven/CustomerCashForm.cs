using PetHaven; // Namespace for the project
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class CustomerCashForm : Form
    {
        SqlConnection cn = new SqlConnection(); // SQL connection object
        SqlCommand cm = new SqlCommand(); // SQL command object
        DbConnect dbcon = new DbConnect(); // Custom database connection class
        private string transNo; // Private field to store transaction number
        public decimal CustomerCash { get; private set; } // Public property to retrieve customer cash amount

        private BillingForm billingForm; // Instance of BillingForm to interact with it

        // Constructor without parameters
        public CustomerCashForm()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection()); // Initialize SQL connection using connection string
        }

        // Constructor with BillingForm parameter
        public CustomerCashForm(BillingForm billingForm, string transNo)
        {
            InitializeComponent();
            this.billingForm = billingForm; // Assign passed BillingForm instance
            this.transNo = transNo; // Store the transaction number
        }

        // Event handler for Ok button click
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtCustomerCash.Text, out decimal cash)) // Validate and parse customer cash input
            {
                CustomerCash = cash; // Set customer cash property

                // Transfer cash value to lblCash
                lblCash.Text = cash.ToString("#,##0.00");

                // Calculate and display change
                decimal totalAmount = 0;
                if (billingForm != null)
                {
                    totalAmount = billingForm.CalculateTotalAmount(); // Call method from BillingForm instance
                }
                decimal change = cash - totalAmount; // Calculate change
                lblChange.Text = change.ToString("#,##0.00");

                // Perform checkout operations using static method from BillingOperations class
                BillingOperations.PerformCheckout(transNo, cash, change);

                // Close the CustomerCashForm
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount."); // Show message if invalid cash input
            }
        }

        // Static nested class for billing operations
        public class BillingOperations
        {
            // Static method to perform checkout and update billing information
            public static void PerformCheckout(string transNo, decimal cash, decimal change)
            {
                try
                {
                    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kurai\\Downloads\\Pet Haven V3\\Pet Haven\\Pet Haven\\dbPetHaven.mdf;Integrated Security=True";

                    using (SqlConnection dbcon = new SqlConnection(connectionString))
                    {
                        dbcon.Open(); // Open database connection

                        string query = "UPDATE tbl_Billing SET cash = @Cash, [change] = @Change WHERE transno = @TransNo"; // SQL update query

                        SqlCommand cmd = new SqlCommand(query, dbcon);
                        cmd.Parameters.AddWithValue("@Cash", cash); // Add cash parameter
                        cmd.Parameters.AddWithValue("@Change", change); // Add change parameter
                        cmd.Parameters.AddWithValue("@TransNo", transNo); // Add transaction number parameter

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute update query and get rows affected

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Transaction Successful!\nChange: {change.ToString("#,##0.00")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show success message
                        }
                        else
                        {
                            MessageBox.Show("Failed to update billing information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if update fails
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}"); // Log error message to console
                }
            }
        }

        // Event handler for Cancel button click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Set dialog result to cancel
            this.Close(); // Close the CustomerCashForm
        }

        // Optional: Event handler for text change in customer cash input
        private void txtCustomerCash_TextChanged(object sender, EventArgs e)
        {
            // Implement validation or formatting logic if needed
        }

        // Optional: Event handler for click on lblCash label
        private void lblCash_Click(object sender, EventArgs e)
        {
            // Handle click event for lblCash if needed
        }

        // Optional: Event handler for click on lblChange label
        private void lblChange_Click(object sender, EventArgs e)
        {
            // Handle click event for lblChange if needed
        }

        // Optional: Event handler for Paint event of guna2GradientPanel1
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Handle Paint event of guna2GradientPanel1 if needed
        }
    }
}
