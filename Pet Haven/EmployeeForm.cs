using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class EmployeeForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DbConnect dbcon = new DbConnect();
        SqlDataReader dr;
        string title = "Pet Haven";
        public string LoggedInUsername { get; set; } // Property to store the logged-in username

        public EmployeeForm()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());

            LoadEmployee(); // Method call to load employee data on form initialization

            // Format the Date of Birth column to display only the date
            dgvEmployee.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvEmployee.Columns[7].Visible = true; // Make sure the password column is visible
        }

        // Method to load employee data into DataGridView
        public void LoadEmployee()
        {
            int i = 0;
            dgvEmployee.Rows.Clear();

            // Construct the SQL command with parameters to avoid SQL injection
            string query = "SELECT id, name, address, phone, role, dob, password FROM tbl_Employee WHERE CONCAT(name, address, phone, dob, role) LIKE @search";
            cm = new SqlCommand(query, cn);
            cm.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvEmployee.Rows.Add(i, dr["id"].ToString(), dr["name"].ToString(), dr["address"].ToString(), dr["phone"].ToString(), dr["role"].ToString(), Convert.ToDateTime(dr["dob"]).ToString("yyyy-MM-dd"), dr["password"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        // Event handler for search text box text changed event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadEmployee(); // Refresh employee data based on search text
        }

        // Event handler for Add button click to open EmployeeModule for adding a new employee
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeModule module = new EmployeeModule(this);
            module.DisableUpdateButton(); // Method call to disable update button in EmployeeModule
            module.ShowDialog();
        }

        // Event handler for DataGridView cell content click (Edit or Delete actions)
        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvEmployee.Columns[e.ColumnIndex].Name;
            string employeeName = dgvEmployee.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? string.Empty; // Get employee name from DataGridView
            string employeeRole = dgvEmployee.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? string.Empty; // Get employee role from DataGridView

            if (colName == "Editss")
            {
                // Prevent editing another administrator's data
                if (employeeRole == "Administrator" && employeeName != LoggedInUsername)
                {
                    MessageBox.Show("You cannot edit the information of another Administrator.", "Edit Permission", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Open EmployeeModule for editing selected employee's data
                EmployeeModule module = new EmployeeModule(this);
                module.lbluid.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
                module.txtName.Text = employeeName;
                module.txtAddress.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? string.Empty;

                // Trim any leading or trailing spaces from the phone number
                module.txtPhone.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].Value?.ToString().Trim() ?? string.Empty;

                module.cbRole.Text = employeeRole;
                module.cbBirth.Value = dgvEmployee.Rows[e.RowIndex].Cells[6].Value != null ? Convert.ToDateTime(dgvEmployee.Rows[e.RowIndex].Cells[6].Value) : DateTime.Now;
                module.txtPassword.Text = dgvEmployee.Rows[e.RowIndex].Cells[7].Value?.ToString() ?? string.Empty;

                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.ShowDialog();
            }
            else if (colName == "Deletess")
            {
                // Handle deletion based on employee role and permission
                if (employeeRole == "Administrator" && employeeName == LoggedInUsername)
                {
                    MessageBox.Show("You cannot delete your own account.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (employeeRole == "Administrator" && employeeName != LoggedInUsername)
                {
                    MessageBox.Show("You cannot delete another Administrator's account.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbcon.executeQuery("DELETE FROM tbl_Employee WHERE id LIKE'" + dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("User data has been successfully removed", title, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }

            LoadEmployee(); // Reload employee data after any modifications
        }

    }
}
