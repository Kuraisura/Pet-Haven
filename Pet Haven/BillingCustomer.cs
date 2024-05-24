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
    // The BillingCustomer class inherits from Form, which is part of the Windows Forms library.
    public partial class BillingCustomer : Form
    {
        // Encapsulation: Private fields to store database connection and command objects.
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cm = new SqlCommand();
        private DbConnect dbcon = new DbConnect();
        private SqlDataReader dr;
        private string title = "Pet Haven";  // Encapsulated title string for message boxes.
        private BillingForm billing;  // Composition: BillingCustomer contains an instance of BillingForm.

        // Public properties with private setters for encapsulating selected customer information.
        public string SelectedCustomerName { get; private set; }
        public int SelectedCustomerId { get; private set; }

        // Constructor: Initializes the form and loads customer data.
        public BillingCustomer(BillingForm form)
        {
            InitializeComponent();  // Calls the method to initialize UI components.
            cn = new SqlConnection(dbcon.connection());  // Sets up the database connection.
            billing = form;  // Initializes the BillingForm instance.
            LoadCustomer();  // Loads customer data into the DataGridView.
        }

        // Event handler for form load event.
        private void BillingCustomer_Load(object sender, EventArgs e)
        {
            // Currently empty, but can be used to handle actions when the form loads.
        }

        // Event handler for DataGridView cell content click event.
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Choice")
            {
                // Retrieves customer information from the selected row.
                string customerId = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                string customerName = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                string customerAddress = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                string customerPhone = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();

                try
                {
                    // Updates the billing information with the selected customer ID.
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_Billing SET cid=@customerId WHERE transno LIKE @transno", cn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.Parameters.AddWithValue("@transno", billing.lblTransNo.Text);

                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        cn.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer has been successfully selected!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Sets the selected customer information and updates the billing form.
                            SelectedCustomerId = int.Parse(customerId);
                            SelectedCustomerName = customerName;
                            billing.SetCheckoutConfirmed(true);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update billing information.", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cn.Close();  // Ensures the connection is closed on error.
                }
            }
        }

        // Event handler for the text changed event of the search textbox.
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();  // Reloads customer data based on the search text.
        }

        // Method to load customer data from the database.
        public void LoadCustomer()
        {
            try
            {
                int i = 0;
                dgvCustomer.Rows.Clear();  // Clears existing rows in the DataGridView.
                cm = new SqlCommand("SELECT id, name, address, phone FROM tbl_Customer ORDER BY name", cn);
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // Adds rows to the DataGridView with customer data.
                    dgvCustomer.Rows.Add(i, dr["id"].ToString(), dr["name"].ToString(), dr["address"].ToString(), dr["phone"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);  // Displays any errors encountered.
            }
        }

        // Event handler for the back button click event.
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();  // Closes the current form.
            this.Dispose();  // Disposes of the form resources.
            billing.Show();  // Shows the billing form.
            billing.Activate();  // Activates the billing form.
        }
    }
}
