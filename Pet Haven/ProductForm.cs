using PetHaven; // Importing external namespace PetHaven.
using System; // Importing system namespace for core functionality.
using System.Data.SqlClient; // Importing system namespace for SQL Server database connectivity.
using System.Linq; // Importing LINQ namespace for querying collections.
using System.Windows.Forms; // Importing system namespace for Windows Forms.

namespace Pet_Haven
{
    public partial class ProductForm : Form
    {
        SqlConnection cn = new SqlConnection(); // Declaring SqlConnection object for database connection.
        SqlCommand cm = new SqlCommand(); // Declaring SqlCommand object for executing SQL queries.
        DbConnect dbcon = new DbConnect(); // Declaring DbConnect object for database connection details.
        string title = "Pet Haven"; // Declaring string variable for window title.

        // Constructor to initialize ProductForm
        public ProductForm()
        {
            InitializeComponent(); // Initializing form components defined in designer.
            cn = new SqlConnection(dbcon.connection()); // Initializing SqlConnection object with database connection string.
            LoadProduct(); // Loading product data into DataGridView.
        }

        // Method to load products into DataGridView based on search text
        public void LoadProduct()
        {
            int i = 0; // Initializing index counter.
            dgvProduct.Rows.Clear(); // Clearing existing rows in DataGridView.
            cm = new SqlCommand("SELECT pcode, pname, pcategory, pqty, pprice FROM tbl_Product WHERE CONCAT(pname, pcategory) LIKE '%" + txtSearch.Text + "%'", cn); // Creating SqlCommand object to retrieve products based on search text.
            try
            {
                cn.Open(); // Opening database connection.
                SqlDataReader dr = cm.ExecuteReader(); // Executing SQL query and retrieving data.
                while (dr.Read())
                {
                    i++; // Incrementing index counter.
                    // Adding product data to DataGridView rows.
                    dgvProduct.Rows.Add(i, dr["pcode"].ToString(), dr["pname"].ToString(), dr["pcategory"].ToString(), dr["pqty"].ToString(), dr["pprice"].ToString());
                }
                dr.Close(); // Closing SqlDataReader.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error); // Displaying error message if exception occurs.
            }
            finally
            {
                cn.Close(); // Closing database connection.
            }
        }

        // Event handler for text change in search textbox
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(); // Reloading product data based on updated search text.
        }

        // Event handler for add button click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule module = new ProductModule(this); // Creating instance of ProductModule form.
            module.DisableUpdateButton(); // Calling method to disable update button in ProductModule form.
            module.ShowDialog(); // Displaying ProductModule form as dialog.
        }

        // Event handler for DataGridView cell content click
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name; // Getting column name of clicked cell.
            if (colName == "Edit")
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Checking if valid cell is clicked.

                ProductModule module = new ProductModule(this); // Creating instance of ProductModule form.
                // Setting values in ProductModule form based on DataGridView cell values.
                module.lblPcode.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() ?? string.Empty;
                module.txtName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString() ?? string.Empty;
                module.cbCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString() ?? string.Empty;
                module.txtQty.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString() ?? string.Empty;
                module.txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString() ?? string.Empty;

                module.btnSave.Enabled = false; // Disabling save button in ProductModule form.
                module.btnUpdate.Enabled = true; // Enabling update button in ProductModule form.
                module.ShowDialog(); // Displaying ProductModule form as dialog.
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this item?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Deleting product record from database based on product code.
                    dbcon.executeQuery("DELETE FROM tbl_Product WHERE pcode LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("Item record has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning); // Showing success message.
                    // Updating dashboard labels after product delete based on category and quantity.
                    UpdateDashboardLabelsAfterDelete(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString(), dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            LoadProduct(); // Reloading product data after operation.
        }

        // Method to update dashboard labels after product delete
        private void UpdateDashboardLabelsAfterDelete(string category, string deletedQty)
        {
            // Finding instance of DashboardForm in open forms collection.
            DashboardForm dashboardFormInstance = Application.OpenForms.OfType<DashboardForm>().FirstOrDefault();
            if (dashboardFormInstance != null) // Checking if DashboardForm instance exists.
            {
                switch (category)
                {
                    case "Dog":
                        int dogQtyDeleted = int.Parse(deletedQty); // Parsing deleted quantity to integer.
                        dashboardFormInstance.UpdateDogLabelAfterDelete(dogQtyDeleted); // Updating dog label in DashboardForm.
                        break;
                    case "Cat":
                        int catQtyDeleted = int.Parse(deletedQty); // Parsing deleted quantity to integer.
                        dashboardFormInstance.UpdateCatLabelAfterDelete(catQtyDeleted); // Updating cat label in DashboardForm.
                        break;
                    case "Bird":
                        int birdQtyDeleted = int.Parse(deletedQty); // Parsing deleted quantity to integer.
                        dashboardFormInstance.UpdateBirdLabelAfterDelete(birdQtyDeleted); // Updating bird label in DashboardForm.
                        break;
                    case "Fish":
                        int fishQtyDeleted = int.Parse(deletedQty); // Parsing deleted quantity to integer.
                        dashboardFormInstance.UpdateFishLabelAfterDelete(fishQtyDeleted); // Updating fish label in DashboardForm.
                        break;
                    default:
                        break;
                }
            }
        }

        // Method to disable editing controls (example method)
        public void DisableEditing()
        {
            btnAdd.Enabled = false; // Disabling add button.
            // Example: Disabling other editing controls as needed.
        }

        // Event handler for refresh button click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProduct(); // Calling method to refresh product data.
        }

        // Method to refresh product data
        private void RefreshProduct()
        {
            LoadProduct(); // Reloading product data into DataGridView.
        }
    }
}
