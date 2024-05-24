using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class CustomerForm : Form
    {
        SqlConnection cn = new SqlConnection(); // SQL connection object
        SqlCommand cm = new SqlCommand(); // SQL command object
        DbConnect dbcon = new DbConnect(); // Custom database connection object
        SqlDataReader dr; // Data reader for SQL queries
        string title = "Pet Haven"; // Title for message boxes

        public CustomerForm()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection()); // Initialize SQL connection
            LoadCustomer(); // Load customers into DataGridView upon form initialization
        }

        // Method to load customers into DataGridView
        public void LoadCustomer()
        {
            int i = 0; // Counter for rows in DataGridView
            dgvCustomer.Rows.Clear(); // Clear existing rows in DataGridView

            cm = new SqlCommand("SELECT * FROM tbl_Customer WHERE CONCAT(name,address,phone) LIKE '%" + txtSearch.Text + "%'", cn); // SQL command to select customers based on search criteria

            try
            {
                cn.Open(); // Open SQL connection
                dr = cm.ExecuteReader(); // Execute SQL command and get data reader

                while (dr.Read()) // Loop through each row in data reader
                {
                    i++; // Increment row counter
                    dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()); // Add row to DataGridView with customer details
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

        // Event handler for DataGridView cell content click
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Check if clicked outside valid range

            string colName = dgvCustomer.Columns[e.ColumnIndex].Name; // Get name of clicked column

            if (colName == "Edits") // Check if "Edits" column is clicked
            {
                // Open customer editing module
                CustomerModule module = new CustomerModule(this);
                module.lblcid.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() ?? string.Empty; // Set customer ID from DataGridView
                module.txtName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString() ?? string.Empty; // Set customer name from DataGridView
                module.txtAddress.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString() ?? string.Empty; // Set customer address from DataGridView
                module.txtPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString() ?? string.Empty; // Set customer phone from DataGridView

                module.btnSave.Enabled = false; // Disable save button (assuming it's intended for new entries)
                module.btnUpdate.Enabled = true; // Enable update button for existing customer
                module.ShowDialog(); // Show editing module as a dialog
            }
            else if (colName == "Deletes") // Check if "Deletes" column is clicked
            {
                if (MessageBox.Show("Are you sure you want to delete this customer record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Delete customer record if confirmed
                    string customerId = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dbcon.executeQuery("DELETE FROM tbl_Customer WHERE id = '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("Customer data has been successfully removed", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            LoadCustomer(); // Reload customers after any changes
        }

        // Event handler for text changed in search textbox
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer(); // Reload customers based on search criteria
        }

        // Event handler for add button click to add new customer
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerModule module = new CustomerModule(this); // Create new instance of CustomerModule
            module.DisableUpdateButton(); // Disable update button (assuming it's for new entries)
            module.ShowDialog(); // Show CustomerModule as a dialog
        }
    }
}
