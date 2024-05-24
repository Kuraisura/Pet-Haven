using PetHaven; // Assuming this is a custom namespace for database connection
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class TransactionForm : Form
    {
        SqlConnection cn = new SqlConnection(); // SQL connection object
        SqlCommand cm = new SqlCommand(); // SQL command object
        DbConnect dbcon = new DbConnect(); // Custom database connection object
        private string loggedInUsername; // Private field to store logged-in username
        private string userRole; // Private field to store user role
        private string selectedProductCode; // To store selected product code
        private string selectedCustomerName; // To store selected customer name

        public TransactionForm(string username, string role)
        {
            InitializeComponent();
            this.loggedInUsername = username; // Initialize logged-in username
            this.userRole = role; // Initialize user role
            cn = new SqlConnection(dbcon.connection()); // Initialize SQL connection
            LoadTransactions(); // Call method to load transactions upon form initialization
        }

        // Method to load transactions into DataGridView
        public void LoadTransactions()
        {

            dgvTransaction.Rows.Clear(); // Clear any existing rows in DataGridView

            try
            {
                cn.Open(); // Open SQL connection
                string query = @"SELECT b.transno AS TransNo, b.pcode AS Pcode, p.pname AS Name,
                        b.qty AS Qty, b.price AS Price, b.total AS Total,
                        c.name AS [Customer Name], b.cashier AS Cashier, 
                        b.purchaseDate AS [Date of Purchase], b.cash AS Cash, b.change AS Change
                        FROM tbl_Billing b
                        INNER JOIN tbl_Product p ON b.pcode = p.pcode
                        INNER JOIN tbl_Customer c ON b.cid = c.id";

                cm = new SqlCommand(query, cn); // Set SQL command and connection
                SqlDataReader dr = cm.ExecuteReader(); // Execute query and get data reader

                while (dr.Read()) // Loop through each row in data reader
                {
                    int qty = Convert.ToInt32(dr["Qty"]); // Convert quantity to int
                    decimal price = Convert.ToDecimal(dr["Price"]); // Convert price to decimal
                    decimal total = Convert.ToDecimal(dr["Total"]); // Convert total to decimal

                    // Add row to DataGridView with transaction details
                    dgvTransaction.Rows.Add(
                        dr["TransNo"].ToString(),
                        dr["Pcode"].ToString(),
                        dr["Name"].ToString(),
                        qty, // Converted to int
                        price, // Converted to decimal
                        total, // Converted to decimal
                        dr["Customer Name"].ToString(),
                        dr["Cashier"].ToString(),
                        dr["Date of Purchase"].ToString(),
                        dr["Cash"].ToString(),
                        dr["Change"].ToString()
                    );
                }

                dr.Close(); // Close data reader
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close(); // Ensure SQL connection is closed
            }
        }

        // Event handler for DataGridView cell content click event (used for opening PDF receipts)
        // Event handler for DataGridView cell content click event (used for opening PDF receipts)
        private void dgvTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        // Event handler for checkout button click event
     

        // Event handler for back button click event
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(loggedInUsername, userRole); // Initialize MainForm with logged-in user details
            mainForm.lblUsername.Text = loggedInUsername; // Assign the logged-in username to MainForm label
            mainForm.lblRole.Text = userRole; // Assign the user role to MainForm label
            mainForm.Show(); // Show MainForm
            this.Close(); // Close current TransactionForm
            mainForm.btnTransaction.Visible = false;
        }

        // Event handler for text changed in search textbox (currently unused)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Placeholder for any actions on text change in search textbox
        }

        // Event handler for DataGridView cell content click event (currently unused)
        private void dgvTransaction_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "Choose" column and not a header row
            if (e.RowIndex >= 0 && dgvTransaction.Columns[e.ColumnIndex].Name == "Choice")
            {
                // Get the transaction number from the clicked row
                string transNo = dgvTransaction.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Construct the path to the PDF receipt
                string directoryPath = @"C:\Users\Public\Documents\"; // Example directory
                string filePath = Path.Combine(directoryPath, $"{transNo}.pdf");

                // Check if the file exists
                if (File.Exists(filePath))
                {
                    try
                    {
                        // Open the PDF file using the default application
                        Process.Start(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Receipt for Transaction Number {transNo} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        // Event handler for print page event (currently unused)
        private void PrintReceipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Placeholder for any actions when printing receipt page
        }

        // Event handler for selecting a product from a list (example implementation)
        private void SelectProduct(string productCode, string productName)
        {
            selectedProductCode = productCode;
            // Handle displaying selected product in UI if needed
        }

        // Event handler for selecting a customer from a list (example implementation)
        private void SelectCustomer(string customerName)
        {
            selectedCustomerName = customerName;
            // Handle displaying selected customer in UI if needed
        }
    }
}
