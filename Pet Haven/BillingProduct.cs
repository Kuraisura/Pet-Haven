using PetHaven;// Assuming this is a custom namespace for database connection
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class BillingProduct : Form
    {
        SqlConnection cn = new SqlConnection(); // SQL connection object
        SqlCommand cm = new SqlCommand(); // SQL command object
        DbConnect dbcon = new DbConnect(); // Custom database connection object
        SqlDataReader dr; // Data reader for SQL queries
        string title = "Pet Haven"; // Title for message boxes
        public string uname; // Public field to store username
        BillingForm billing; // Reference to BillingForm for interaction

        public BillingProduct(BillingForm form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection()); // Initialize SQL connection
            billing = form; // Assign BillingForm instance passed as parameter
            LoadProduct(); // Load products into DataGridView upon form initialization
        }

        // Event handler for text changed in search textbox
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(); // Reload products based on search criteria
        }

        // Event handler for DataGridView cell content click (currently unused)
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for any actions on DataGridView cell content click
        }

        // Method to check if product already exists in billing and get current quantity
        public bool ProductExistsInBilling(string pcode, out int currentBillingQty)
        {
            bool exists = false; // Flag indicating if product exists in billing
            currentBillingQty = 0; // Initialize current billing quantity

            try
            {
                cn.Open(); // Open SQL connection
                cm = new SqlCommand("SELECT qty FROM tbl_Billing WHERE transno = @transno AND pcode = @pcode", cn); // SQL command to check if product exists
                cm.Parameters.AddWithValue("@transno", billing.lblTransNo.Text); // Parameter for transaction number
                cm.Parameters.AddWithValue("@pcode", pcode); // Parameter for product code
                object result = cm.ExecuteScalar(); // Execute scalar query to get quantity

                if (result != null)
                {
                    currentBillingQty = Convert.ToInt32(result); // Convert result to integer
                    exists = true; // Set flag to true if product exists in billing
                }

                cn.Close(); // Close SQL connection
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message box
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Ensure connection is closed
            }

            return exists; // Return whether product exists in billing
        }

        // Method to load products into DataGridView
        
        public void LoadProduct()
        {
            int i = 0; // Counter for rows in DataGridView
            dgvProduct.Rows.Clear(); // Clear existing rows in DataGridView

            cm = new SqlCommand("SELECT pcode, pname, pcategory, pprice FROM tbl_Product WHERE CONCAT(pname, pcategory) LIKE '%" + txtSearch.Text + "%' AND pqty > 0", cn); // SQL command to select products based on search criteria

            try
            {
                cn.Open(); // Open SQL connection
                dr = cm.ExecuteReader(); // Execute SQL command and get data reader

                while (dr.Read()) // Loop through each row in data reader
                {
                    i++; // Increment row counter
                    dgvProduct.Rows.Add(i, dr["pcode"].ToString(), dr["pname"].ToString(), dr["pcategory"].ToString(), dr["pprice"].ToString()); // Add row to DataGridView with product details
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message box
            }
            finally
            {
                dr.Close(); // Close data reader
                cn.Close(); // Close SQL connection
            }
        }

        // Event handler for DataGridView cell content click (currently unused)
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for any actions on DataGridView cell content click
        }

        // Event handler for submit button click to add selected products to billing

        // Event handler for submit button click to add selected products to billing
        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            bool productsSelected = false; // Flag indicating if products are selected for billing

            foreach (DataGridViewRow row in dgvProduct.Rows) // Loop through each row in DataGridView
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value); // Check if product is selected
                if (isChecked)
                {
                    try
                    {
                        string pcode = row.Cells[1].Value.ToString(); // Get product code from DataGridView (assuming it's in the second column)
                        string pname = row.Cells[2].Value.ToString(); // Get product name from DataGridView (assuming it's in the third column)
                        string priceString = row.Cells[4].Value.ToString(); // Get product price from DataGridView (assuming it's in the fifth column)

                        if (!string.IsNullOrEmpty(priceString) && double.TryParse(priceString, out double price))
                        {
                            int productQty = GetProductQty(pcode); // Get product quantity from tbl_Product
                            int currentBillingQty = 0; // Initialize current billing quantity

                            if (ProductExistsInBilling(pcode, out currentBillingQty)) // Check if product already exists in billing
                            {
                                if (currentBillingQty + 1 > productQty) // Check if adding one more exceeds available quantity
                                {
                                    MessageBox.Show($"Remaining quantity on hand is {productQty - currentBillingQty} for product: {pname}", title, MessageBoxButtons.OK, MessageBoxIcon.Warning); // Show warning message
                                    continue; // Skip to next iteration
                                }

                                // Update quantity if product already exists in billing
                                cm = new SqlCommand("UPDATE tbl_Billing SET qty = qty + 1 WHERE transno = @transno AND pcode = @pcode", cn);
                                cm.Parameters.AddWithValue("@transno", billing.lblTransNo.Text); // Parameter for transaction number
                                cm.Parameters.AddWithValue("@pcode", pcode); // Parameter for product code
                            }
                            else
                            {
                                if (productQty < 1) // Check if product quantity is less than 1
                                {
                                    MessageBox.Show($"Remaining quantity on hand is {productQty} for product: {pname}", title, MessageBoxButtons.OK, MessageBoxIcon.Warning); // Show warning message
                                    continue; // Skip to next iteration
                                }

                                // Insert new record if product does not exist in billing
                                cm = new SqlCommand("INSERT INTO tbl_Billing(transno, pcode, pname, qty, price, cashier) VALUES (@transno, @pcode, @pname, @qty, @price, @cashier)", cn);
                                cm.Parameters.AddWithValue("@transno", billing.lblTransNo.Text); // Parameter for transaction number
                                cm.Parameters.AddWithValue("@pcode", pcode); // Parameter for product code
                                cm.Parameters.AddWithValue("@pname", pname); // Parameter for product name
                                cm.Parameters.AddWithValue("@qty", 1); // Assuming quantity is fixed at 1
                                cm.Parameters.AddWithValue("@price", price); // Parameter for product price
                                cm.Parameters.AddWithValue("@cashier", uname); // Parameter for cashier (username)
                            }

                            cn.Open(); // Open SQL connection
                            cm.ExecuteNonQuery(); // Execute SQL command
                            cn.Close(); // Close SQL connection after execution
                        }
                        else
                        {
                            MessageBox.Show("Invalid price format for product: " + pname, title, MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message for invalid price format
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message box
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                            cn.Close(); // Ensure SQL connection is closed
                    }

                    productsSelected = true; // Set flag to true indicating products are selected
                }
            }

            if (!productsSelected)
            {
                MessageBox.Show("Please select at least one product.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning); // Show warning if no products are selected
                return; // Exit method
            }

            billing.LoadBilling(); // Refresh BillingForm to display updated billing information
            this.Dispose(); // Dispose the form after processing
        }


        // Helper method to get product quantity from tbl_Product
        // Helper method to get product quantity from tbl_Product
        private int GetProductQty(string pcode)
        {
            int qty = 0; // Initialize quantity variable

            try
            {
                cn.Open(); // Open SQL connection
                cm = new SqlCommand("SELECT pqty FROM tbl_Product WHERE pcode = @pcode", cn); // SQL command to select product quantity
                cm.Parameters.AddWithValue("@pcode", pcode); // Parameter for product code
                qty = Convert.ToInt32(cm.ExecuteScalar()); // Convert result to integer
                cn.Close(); // Close SQL connection
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message box
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close(); // Ensure SQL connection is closed
            }

            return qty; // Return product quantity
        }

        // Event handler for back button click to return to BillingForm
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the current form (BillingProduct.cs)
            billing.Show(); // Show the BillingForm.cs that was passed as a parameter
        }

    }
}
