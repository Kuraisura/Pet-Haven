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
    public partial class CustomerModule : Form
    {
        SqlConnection cn = new SqlConnection(); // SQL connection object
        SqlCommand cm = new SqlCommand(); // SQL command object
        DbConnect dbcon = new DbConnect(); // Custom database connection object
        string title = "Pet Haven"; // Title for message boxes

        bool check = false; // Flag to check form validation
        CustomerForm customer; // Reference to CustomerForm for interaction

        // Constructor to initialize form and database connection
        public CustomerModule(CustomerForm form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection()); // Initialize SQL connection
            customer = form; // Store reference to CustomerForm
            txtName.KeyPress += TxtName_KeyPress; // Event handler for name textbox key press
            txtPhone.KeyPress += TxtPhone_KeyPress; // Event handler for phone textbox key press
        }

        // Method to disable update button
        public void DisableUpdateButton()
        {
            btnUpdate.Enabled = false;
        }

        // Event handler for save button click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField(); // Validate form fields
                if (check)
                {
                    // Check for duplicate customer based on name and address
                    if (IsDuplicateCustomer(txtName.Text, txtAddress.Text))
                    {
                        MessageBox.Show("Customer with the same name and address already exists. Please enter unique details.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validate phone number format
                    if (!IsValidPhoneNumber(txtPhone.Text))
                    {
                        MessageBox.Show("Invalid phone number format. Please enter a valid number starting with '09' and 11 digits.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Confirm customer registration
                    if (MessageBox.Show("Are you sure you want to register this customer?", "Customer Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Insert customer data into database
                        cm = new SqlCommand("INSERT INTO tbl_Customer(name, address, phone) VALUES (@name, @address, @phone)", cn);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);

                        cn.Open(); // Open SQL connection
                        cm.ExecuteNonQuery(); // Execute SQL command
                        cn.Close(); // Close SQL connection
                        MessageBox.Show("Customer has been successfully registered!", title); // Show success message

                        Clear(); // Clear form fields
                        customer.LoadCustomer(); // Reload customers in CustomerForm
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close(); // Close SQL connection on exception
                MessageBox.Show(ex.Message, title); // Show error message
            }
        }

        // Method to check for duplicate customer based on name and address
        private bool IsDuplicateCustomer(string name, string address)
        {
            bool isDuplicate = false;
            try
            {
                cn.Open(); // Open SQL connection
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Customer WHERE name = @name AND address = @address", cn);
                cm.Parameters.AddWithValue("@name", name); // Add name parameter
                cm.Parameters.AddWithValue("@address", address); // Add address parameter
                int count = (int)cm.ExecuteScalar(); // Execute scalar query
                if (count > 0)
                {
                    isDuplicate = true; // Set flag if customer already exists
                }
                cn.Close(); // Close SQL connection
            }
            catch (Exception ex)
            {
                cn.Close(); // Close SQL connection on exception
                MessageBox.Show(ex.Message, title); // Show error message
            }
            return isDuplicate; // Return duplicate status
        }

        // Method to check for duplicate phone number
        private bool IsDuplicatePhoneNumber(string phoneNumber)
        {
            bool isDuplicate = false;
            try
            {
                cn.Open(); // Open SQL connection
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Customer WHERE phone = @phone", cn);
                cm.Parameters.AddWithValue("@phone", phoneNumber); // Add phone number parameter
                int count = (int)cm.ExecuteScalar(); // Execute scalar query
                if (count > 0)
                {
                    isDuplicate = true; // Set flag if phone number already exists
                }
                cn.Close(); // Close SQL connection
            }
            catch (Exception ex)
            {
                cn.Close(); // Close SQL connection on exception
                MessageBox.Show(ex.Message, title); // Show error message
            }
            return isDuplicate; // Return duplicate status
        }

        // Event handler for update button click
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField(); // Validate form fields
                if (check)
                {
                    string currentName = txtName.Text;
                    string currentAddress = txtAddress.Text;
                    string currentPhone = txtPhone.Text;

                    // Check for duplicate customer excluding current record
                    if (IsDuplicateCustomerExceptCurrent(currentName, currentAddress, lblcid.Text))
                    {
                        MessageBox.Show("Customer with the same name and address already exists. Please enter unique details.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validate phone number format
                    if (!IsValidPhoneNumber(currentPhone))
                    {
                        MessageBox.Show("Invalid phone number format. Please enter a valid number starting with '09' and 11 digits.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Check for duplicate phone number excluding current record
                    if (IsDuplicatePhoneNumberExceptCurrent(currentPhone, lblcid.Text))
                    {
                        MessageBox.Show("Phone number already exists. Please enter a unique phone number.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Confirm customer record update
                    if (MessageBox.Show("Are you sure you want to edit this record?", "Record Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Update customer data in database
                        cm = new SqlCommand("UPDATE tbl_Customer SET name=@name, address=@address, phone=@phone WHERE id=@id", cn);
                        cm.Parameters.AddWithValue("@id", lblcid.Text); // Add customer ID parameter
                        cm.Parameters.AddWithValue("@name", txtName.Text); // Add name parameter
                        cm.Parameters.AddWithValue("@address", txtAddress.Text); // Add address parameter
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text); // Add phone number parameter

                        cn.Open(); // Open SQL connection
                        cm.ExecuteNonQuery(); // Execute SQL command
                        cn.Close(); // Close SQL connection
                        MessageBox.Show("Customer data has been successfully updated!", title); // Show success message

                        Clear(); // Clear form fields
                        customer.LoadCustomer(); // Reload customers in CustomerForm
                        this.Dispose(); // Dispose CustomerModule form
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close(); // Close SQL connection on exception
                MessageBox.Show(ex.Message, title); // Show error message
            }
        }

        // Method to check for duplicate customer excluding current record
        private bool IsDuplicateCustomerExceptCurrent(string name, string address, string id)
        {
            bool isDuplicate = false;
            try
            {
                cn.Open(); // Open SQL connection
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Customer WHERE name = @name AND address = @address AND id != @id", cn);
                cm.Parameters.AddWithValue("@name", name); // Add name parameter
                cm.Parameters.AddWithValue("@address", address); // Add address parameter
                cm.Parameters.AddWithValue("@id", id); // Add customer ID parameter
                int count = (int)cm.ExecuteScalar(); // Execute scalar query
                if (count > 0)
                {
                    isDuplicate = true; // Set flag if customer already exists
                }
                cn.Close(); // Close SQL connection
            }
            catch (Exception ex)
            {
                cn.Close(); // Close SQL connection on exception
                MessageBox.Show(ex.Message, title); // Show error message
            }
            return isDuplicate; // Return duplicate status
        }

        // Method to check for duplicate phone number excluding current record
        private bool IsDuplicatePhoneNumberExceptCurrent(string phoneNumber, string id)
        {
            bool isDuplicate = false;
            try
            {
                cn.Open(); // Open SQL connection
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Customer WHERE phone = @phone AND id != @id", cn);
                cm.Parameters.AddWithValue("@phone", phoneNumber); // Add phone number parameter
                cm.Parameters.AddWithValue("@id", id); // Add customer ID parameter
                int count = (int)cm.ExecuteScalar(); // Execute scalar query
                if (count > 0)
                {
                    isDuplicate = true; // Set flag if phone number already exists
                }
                cn.Close(); // Close SQL connection
            }
            catch (Exception ex)
            {
                cn.Close(); // Close SQL connection on exception
                MessageBox.Show(ex.Message, title); // Show error message
            }
            return isDuplicate; // Return duplicate status
        }

        // Event handler for name textbox key press to allow only letters
        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Prevent input if not a letter or control character
            }
        }

        // Event handler for phone textbox key press to allow only digits
        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CheckField()
        {
            check = true;

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                check = false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.StartsWith("09") && phoneNumber.Length == 11 && long.TryParse(phoneNumber, out _);
        }

        private void Clear()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            lblcid.Text = "";
        }
        private void TxtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private bool IsValidAddressCharacter(char keyChar)
        {
            // Define allowed characters: letters, digits, and specific punctuation marks
            bool isValid = char.IsLetterOrDigit(keyChar) ||
                          keyChar == '.' || keyChar == ',' || keyChar == '\'' ||
                          keyChar == '-' || keyChar == '#' || keyChar == '&';

            return isValid;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, digits, and specific punctuation marks
            if (!IsValidAddressCharacter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
