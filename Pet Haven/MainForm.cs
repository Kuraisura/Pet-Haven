using Pet_Haven;  // Importing external namespace Pet_Haven.

using System;  // Importing system namespace for core functionality.
using System.Data.SqlClient;  // Importing system namespace for SQL Server database connectivity.
using System.Drawing;  // Importing system namespace for handling colors and drawing.
using System.Windows.Forms;  // Importing system namespace for Windows Forms.

namespace PetHaven
{
    public partial class MainForm : Form
    {
        private DashboardForm dashboardForm;  // Declaring private DashboardForm variable.
        private EmployeeForm employeeForm;  // Declaring private EmployeeForm variable.
        private ProductForm productForm;  // Declaring private ProductForm variable.
        private CustomerForm customerForm;  // Declaring private CustomerForm variable.
        private BillingForm billingForm;  // Declaring private BillingForm variable.
        public Label lblUsername;  // Declaring public Label variable for username.


        SqlConnection cn = new SqlConnection();  // Creating SqlConnection object for database connection.
        SqlCommand cm = new SqlCommand();  // Creating SqlCommand object for executing SQL queries.
        DbConnect dbcon = new DbConnect();  // Creating DbConnect object for database connection details.

        // Constructor to initialize MainForm with username and role
        public MainForm(string username, string role)
        {
            InitializeComponent();  // Initializing form components defined in designer.
            cn = new SqlConnection(dbcon.connection());  // Initializing SqlConnection object with database connection string.
            btnTransaction.Visible = false;  // Initially hide the button
            btnTransaction.Enabled = false;
            BillingForm billingForm = new BillingForm(this);
            billingForm.CheckoutCompleted += BillingForm_CheckoutCompleted;
            

            // Initialize username and role labels
            lblUsername.Text = username;  // Setting text for username label.
            lblRole.Text = role;  // Setting text for role label.

            InitializeForms();  // Initializing child forms used in MainForm.
            LoadDashboard();  // Loading DashboardForm by default.
            loadDailySale();  // Loading daily sales information.

            // Setting minimum and maximum form size
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.MaximumSize = new System.Drawing.Size(1300, 700);

            InitializeUIForRole();  // Ensuring UI elements are initialized based on user role.
        }



        // Method to reset button styles to default
        private void ResetButtonStyles()
        {
            Color defaultBackColor = Color.FromArgb(11, 7, 17);  // Setting default background color.
            Color defaultForeColor = Color.White;  // Setting default text color.

            // Resetting background and text colors for buttons
            btnDashboard.BackColor = defaultBackColor;
            btnCustomers.BackColor = defaultBackColor;
            btnEmployees.BackColor = defaultBackColor;
            btnProducts.BackColor = defaultBackColor;
            btnCash.BackColor = defaultBackColor;

            btnDashboard.ForeColor = defaultForeColor;
            btnCustomers.ForeColor = defaultForeColor;
            btnEmployees.ForeColor = defaultForeColor;
            btnProducts.ForeColor = defaultForeColor;
            btnCash.ForeColor = defaultForeColor;
        }

        private void BillingForm_CheckoutCompleted(object sender, EventArgs e)
        {
            btnTransaction.Visible = true;  // Show the button after checkout completed
            btnTransaction.Enabled = true;  // Enable the button after checkout completed
        }

        // Method to highlight a button with specific styling
        private void HighlightButton(Button button)
        {
            ResetButtonStyles();  // Resetting all button styles to default.
            button.BackColor = Color.LightBlue;  // Setting highlight background color.
            button.ForeColor = Color.Black;  // Setting text color for highlighted button.
        }

        // Method to initialize all child forms used in MainForm
        private void InitializeForms()
        {
            // Initializing DashboardForm
            dashboardForm = new DashboardForm();
            dashboardForm.TopLevel = false;
            dashboardForm.FormBorderStyle = FormBorderStyle.None;
            dashboardForm.Dock = DockStyle.Fill;

            // Initializing EmployeeForm
            employeeForm = new EmployeeForm();
            employeeForm.TopLevel = false;
            employeeForm.FormBorderStyle = FormBorderStyle.None;
            employeeForm.Dock = DockStyle.Fill;

            // Initializing ProductForm
            productForm = new ProductForm();
            productForm.TopLevel = false;
            productForm.FormBorderStyle = FormBorderStyle.None;
            productForm.Dock = DockStyle.Fill;

            // Initializing CustomerForm
            customerForm = new CustomerForm();
            customerForm.TopLevel = false;
            customerForm.FormBorderStyle = FormBorderStyle.None;
            customerForm.Dock = DockStyle.Fill;

            // Initializing BillingForm with reference to MainForm
            billingForm = new BillingForm(this);
            billingForm.TopLevel = false;
            billingForm.FormBorderStyle = FormBorderStyle.None;
            billingForm.Dock = DockStyle.Fill;
        }

        // Method to load DashboardForm into the panel
        private void LoadDashboard()
        {
            panelChild.Controls.Clear();  // Clearing existing controls in panel.
            panelChild.Controls.Add(dashboardForm);  // Adding DashboardForm to panel.
            dashboardForm.Show();  // Showing DashboardForm.
            dashboardForm.BringToFront();  // Bringing DashboardForm to front.
        }

        // Method to load EmployeeForm into the panel
        private void LoadEmployeeForm()
        {
            employeeForm.LoggedInUsername = lblUsername.Text;  // Passing logged-in username to EmployeeForm.
            panelChild.Controls.Clear();  // Clearing existing controls in panel.
            panelChild.Controls.Add(employeeForm);  // Adding EmployeeForm to panel.
            employeeForm.Show();  // Showing EmployeeForm.
            employeeForm.BringToFront();  // Bringing EmployeeForm to front.
        }

        // Method to load ProductForm into the panel
        private void LoadProductForm()
        {
            panelChild.Controls.Clear();  // Clearing existing controls in panel.
            panelChild.Controls.Add(productForm);  // Adding ProductForm to panel.
            productForm.Show();  // Showing ProductForm.
            productForm.BringToFront();  // Bringing ProductForm to front.
        }

        // Method to load CustomerForm into the panel
        private void LoadCustomerForm()
        {
            panelChild.Controls.Clear();  // Clearing existing controls in panel.
            panelChild.Controls.Add(customerForm);  // Adding CustomerForm to panel.
            customerForm.Show();  // Showing CustomerForm.
            customerForm.BringToFront();  // Bringing CustomerForm to front.
        }

        // Method to load BillingForm into the panel
        private void LoadBillingForm()
        {
            billingForm.CurrentUser = lblUsername.Text;  // Passing current username to BillingForm.
            panelChild.Controls.Clear();  // Clearing existing controls in panel.
            panelChild.Controls.Add(billingForm);  // Adding BillingForm to panel.
            billingForm.Show();  // Showing BillingForm.
            billingForm.BringToFront();  // Bringing BillingForm to front.
        }

        // Event handler for Dashboard button click
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();  // Loading DashboardForm.
            HighlightButton(btnDashboard);  // Highlighting Dashboard button.
        }

        // Event handler for Customers button click
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            LoadCustomerForm();  // Loading CustomerForm.
            HighlightButton(btnCustomers);  // Highlighting Customers button.
        }

        // Event handler for Employees button click
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            LoadEmployeeForm();  // Loading EmployeeForm.
            HighlightButton(btnEmployees);  // Highlighting Employees button.
        }

        // Event handler for Products button click
        private void btnProducts_Click(object sender, EventArgs e)
        {
            LoadProductForm();  // Loading ProductForm.
            HighlightButton(btnProducts);  // Highlighting Products button.
        }

        // Event handler for Cash button click (Billing)
        private void btnCash_Click(object sender, EventArgs e)
        {
            LoadBillingForm();  // Loading BillingForm.
            HighlightButton(btnCash);  // Highlighting Cash button.
        }

        // Event handler for Exit button click (Logout)
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                billingForm.ResetFormState();  // Resetting BillingForm state.
                this.Close();  // Closing MainForm.
                LoginForm loginForm = new LoginForm();  // Creating new instance of LoginForm.
                loginForm.Show();  // Showing LoginForm.
            }
        }

        // Event handler for MainForm load event
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDashboard();  // Loading DashboardForm on MainForm load.
            HighlightButton(btnDashboard);  // Highlighting Dashboard button.
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelChild_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDailySale_Click(object sender, EventArgs e)
        {

        }

        private void ResetDailySales()
        {
            try
            {
                cn.Open();  // Opening database connection.
                cm = new SqlCommand("DELETE FROM tbl_Billing", cn);  // Creating SqlCommand to delete records.
                cm.ExecuteNonQuery();  // Executing deletion query.
                cn.Close();  // Closing database connection.
                lblDailySale.Text = "0.00";  // Resetting daily sales display.

                // Showing success message after reset
                MessageBox.Show("Daily sales have been reset and all billing records have been deleted.", "Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                cn.Close();  // Closing database connection on exception.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Showing error message.
            }
        }

        // Method to load daily sales information from database
        public void loadDailySale()
        {
            string sdate = DateTime.Now.ToString("yyyyMMdd");  // Getting current date in specific format.

            try
            {
                cn.Open();  // Opening database connection.
                cm = new SqlCommand("SELECT ISNULL(SUM(total),0) AS total FROM tbl_Billing WHERE transno LIKE'" + sdate + "%'", cn);  // Creating SqlCommand to fetch daily sales total.
                lblDailySale.Text = double.Parse(cm.ExecuteScalar().ToString()).ToString("#,##0.00");  // Setting daily sales display text.
                cn.Close();  // Closing database connection.
            }
            catch (Exception ex)
            {
                cn.Close();// Closing database connection on exception.
                MessageBox.Show(ex.Message); // Showing error message.
            }
        }

        // Event handler for role label click (placeholder)
        private void lblRole_Click(object sender, EventArgs e)
        {
            // Placeholder method for future functionality.
        }

        // Event handler for username label click (placeholder)
        private void lblUsername_Click(object sender, EventArgs e)
        {
            // Placeholder method for future functionality.
        }

        // Event handler for additional functionality button click (placeholder)
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            // Placeholder method for future functionality.
        }

        // Event handler for reset button click (placeholder)
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Placeholder method for future functionality.
        }

        // Event handler for reset sales button click
        private void btnResetSales_Click(object sender, EventArgs e)
        {
            if (lblRole.Text == "Administrator")  // Checking if user role is Administrator.
            {
                // Administrator can reset daily sales
                if (MessageBox.Show("Are you sure you want to reset daily sales and delete all billing records?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResetDailySales();  // Resetting daily sales and billing records.
                }
            }
            else
            {
                // Displaying access denied message for non-Administrator roles.
                MessageBox.Show("You do not have permission to reset daily sales.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Method to initialize UI elements based on user role
        private void InitializeUIForRole()
        {
            string role = lblRole.Text;  // Getting user role from label.

            // Setting UI elements based on user role
            switch (role)
            {
                case "Administrator":
                    // All buttons enabled for Administrator
                    btnEmployees.Enabled = true;
                    btnCustomers.Enabled = true;
                    btnProducts.Enabled = true;
                    btnCash.Enabled = true;
                    btnResetSales.Enabled = true;
                    break;
                case "Cashier":
                    // Disable specific buttons for Cashier
                    btnEmployees.Enabled = false;
                    btnCustomers.Enabled = true;
                    btnProducts.Enabled = false; // Cannot edit or delete
                    btnCash.Enabled = true;
                    btnResetSales.Enabled = false; // Cannot reset daily sales
                    break;
                case "Supplier":
                    // Disable specific buttons for Supplier
                    btnEmployees.Enabled = false;
                    btnCustomers.Enabled = false;
                    btnProducts.Enabled = true;
                    btnCash.Enabled = false;
                    btnResetSales.Enabled = false;
                    break;
                default:
                    // Handle unknown role or default case
                    MessageBox.Show("Unknown role encountered.");  // Showing message for unknown role.
                    break;
            }
        }

        // Event handler for transaction button click
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // Open TransactionForm with current username and role
            TransactionForm transactionForm = new TransactionForm(lblUsername.Text, lblRole.Text);
            transactionForm.Show();  // Showing TransactionForm.

            this.Close();  // Closing current MainForm.
        }


    }
}

