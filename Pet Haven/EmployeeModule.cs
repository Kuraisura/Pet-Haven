using System;  // Basic namespace for fundamental types and classes.
using System.Collections.Generic;  // Provides generic collections like List, Dictionary.
using System.ComponentModel;  // Support for component-based programming models.
using System.Data;  // Includes classes for working with data.
using System.Drawing;  // Provides access to GDI+ basic graphics functionality.
using System.Linq;  // Provides LINQ (Language-Integrated Query) support.
using System.Text;  // Basic string manipulation and encoding support.
using System.Threading.Tasks;  // Support for asynchronous programming.
using System.Windows.Forms;  // Windows Forms controls and forms.
using System.Data.SqlClient;  // SQL Server data provider.
using PetHaven;  // External namespace for custom PetHaven classes and methods.

namespace Pet_Haven
{
    public partial class EmployeeModule : Form
    {
        SqlConnection cn = new SqlConnection();  // SQL connection object.
        SqlCommand cm = new SqlCommand();  // SQL command object for executing queries.
        DbConnect dbcon = new DbConnect();  // Custom class for database connection management.
        string title = "Pet Haven";  // Title string used for message boxes and titles.

        bool check = false;  // Flag used for validation checks.
        EmployeeForm employeeForm;  // Reference to the parent EmployeeForm.

        // Constructor to initialize the EmployeeModule form.
        public EmployeeModule(EmployeeForm user)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());  // Initialize SQL connection.
            employeeForm = user;  // Assign parent form reference.
            cbRole.SelectedIndex = 1;  // Set default selection in combo box.

            // Event handlers for key press events.
            txtPhone.KeyPress += new KeyPressEventHandler(txtPhone_KeyPress);
            txtName.KeyPress += new KeyPressEventHandler(txtName_KeyPress);
        }

        // Method to disable the Update button.
        public void DisableUpdateButton()
        {
            btnUpdate.Enabled = false;
        }


        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private bool CanAddAdministrator()
        {
            int adminCount = 0;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Employee WHERE role = 'Administrator'", cn);
                adminCount = (int)cm.ExecuteScalar();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return adminCount < 2;
        }

        // Event handler for Save button click.
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate date of birth.
                DateTime minDateOfBirth = new DateTime(1934, 1, 1);
                DateTime maxDateOfBirth = new DateTime(2006, 12, 31);
                if (cbBirth.Value < minDateOfBirth || cbBirth.Value > maxDateOfBirth)
                {
                    MessageBox.Show("Date of birth must be between January 1, 1934, and December 31, 2006.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check other required fields and perform validation.
                CheckField();
                if (check)
                {
                    // Validate phone number format.
                    if (!IsValidPhoneNumber(txtPhone.Text))
                    {
                        MessageBox.Show("The phone number is not valid. Please enter a valid 11-digit phone number starting with '09'.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Check if phone number already exists.
                    if (PhoneNumberExists(txtPhone.Text))
                    {
                        MessageBox.Show("The phone number already exists. Please try again with a different phone number.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Check if name-password combination already exists.
                    if (NamePasswordExists(txtName.Text, txtPassword.Text))
                    {
                        MessageBox.Show("The name and password combination already exists. Please try again with different credentials.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Check limitation for adding Administrators.
                    if (cbRole.Text == "Administrator" && !CanAddAdministrator())
                    {
                        MessageBox.Show("Only two users can have the Administrator role.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Prompt user to confirm registration.
                    if (MessageBox.Show("Are you sure you want to register this user?", "User Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Execute SQL command to insert new employee.
                        cm = new SqlCommand("INSERT INTO tbl_Employee(name,address,phone,role,dob,password)VALUES(@name,@address,@phone,@role,@dob,@password)", cn);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@role", cbRole.Text);
                        cm.Parameters.AddWithValue("@dob", cbBirth.Value);
                        cm.Parameters.AddWithValue("@password", txtPassword.Text);

                        cn.Open();  // Open connection.
                        cm.ExecuteNonQuery();  // Execute non-query command.
                        cn.Close();  // Close connection.

                        MessageBox.Show("User has been successfully registered!", title);  // Confirmation message.
                        Clear();  // Clear input fields.
                        employeeForm.LoadEmployee();  // Reload employee data in parent form.
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();  // Close connection on error.
                MessageBox.Show(ex.Message, title);  // Display error message.
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Check if the phone number is 11 digits long and starts with '09'
            return phoneNumber.Length == 11 && phoneNumber.StartsWith("09");
        }

        private bool PhoneNumberExists(string phoneNumber)
        {
            bool exists = false;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Employee WHERE phone = @phone", cn);
                cm.Parameters.AddWithValue("@phone", phoneNumber);
                int count = (int)cm.ExecuteScalar();
                exists = count > 0;
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return exists;
        }

        private bool PhoneNumberExists(string phoneNumber, string excludedUserId)
        {
            bool exists = false;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Employee WHERE phone = @phone AND id != @excludedUserId", cn);
                cm.Parameters.AddWithValue("@phone", phoneNumber);
                cm.Parameters.AddWithValue("@excludedUserId", excludedUserId);
                int count = (int)cm.ExecuteScalar();
                exists = count > 0;
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return exists;
        }

        private bool NamePasswordExists(string name, string password)
        {
            bool exists = false;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Employee WHERE name = @name AND password = @password", cn);
                cm.Parameters.AddWithValue("@name", name);
                cm.Parameters.AddWithValue("@password", password);
                int count = (int)cm.ExecuteScalar();
                exists = count > 0;
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return exists;
        }

        private bool NamePasswordExists(string name, string password, string excludedUserId)
        {
            bool exists = false;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Employee WHERE name = @name AND password = @password AND id != @excludedUserId", cn);
                cm.Parameters.AddWithValue("@name", name);
                cm.Parameters.AddWithValue("@password", password);
                cm.Parameters.AddWithValue("@excludedUserId", excludedUserId);
                int count = (int)cm.ExecuteScalar();
                exists = count > 0;
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return exists;
        }

        // Event handler for Update button click.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();  // Validate required fields.
                if (check)
                {
                    bool loggedInUserIsAdmin = (cbRole.Enabled == false);  // Check if logged-in user is admin.

                    // Additional validation for non-admin users.
                    if (!loggedInUserIsAdmin)
                    {
                        // Validate phone number format.
                        if (!IsValidPhoneNumber(txtPhone.Text))
                        {
                            MessageBox.Show("The phone number is not valid. Please enter a valid 11-digit phone number starting with '09'.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Check if phone number already exists (excluding current user).
                        if (PhoneNumberExists(txtPhone.Text, lbluid.Text))
                        {
                            MessageBox.Show("The phone number already exists. Please try again with a different phone number.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Check if name-password combination already exists (excluding current user).
                        if (NamePasswordExists(txtName.Text, txtPassword.Text, lbluid.Text))
                        {
                            MessageBox.Show("The name and password combination already exists. Please try again with different credentials.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Limitation for adding Administrators.
                        if (cbRole.Text == "Administrator" && !CanAddAdministrator())
                        {
                            MessageBox.Show("Only two users can have the Administrator role.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else // Additional validation for administrators.
                    {
                        // Validate phone number format for administrators.
                        if (!IsValidPhoneNumber(txtPhone.Text))
                        {
                            MessageBox.Show("The phone number is not valid for administrators. Please enter a valid 11-digit phone number starting with '09'.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Prompt user to confirm update.
                    if (MessageBox.Show("Are you sure you want to update this user's information?", "User Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Execute SQL command to update employee information.
                        cm = new SqlCommand("UPDATE tbl_Employee SET name = @name, address = @address, phone = @phone, role = @role, dob = @dob, password = @password WHERE id = @id", cn);
                        cm.Parameters.AddWithValue("@id", lbluid.Text);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@role", cbRole.Text);
                        cm.Parameters.AddWithValue("@dob", cbBirth.Value);
                        cm.Parameters.AddWithValue("@password", txtPassword.Text);

                        cn.Open();  // Open connection.
                        cm.ExecuteNonQuery();  // Execute non-query command.
                        cn.Close();  // Close connection.

                        MessageBox.Show("User information has been successfully updated!", title);  // Confirmation message.
                        Clear();  // Clear input fields.
                        employeeForm.LoadEmployee();  // Reload employee data in parent form.
                        this.Dispose();  // Dispose current form.

                        if (loggedInUserIsAdmin)
                        {
                            Application.Restart();  // Restart application for administrators.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();  // Close connection on error.
                MessageBox.Show(ex.Message, title);  // Display error message.
            }
        }

        // Event handler for Phone TextBox text change.
        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            CheckPhoneNumberExists();  // Check if phone number already exists.
        }

        // Event handler for Phone TextBox key press.

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))  // Check if key is not a digit or control key.
            {
                e.Handled = true;  // Cancel the key press.
            }
        }

        // Event handler for Phone TextBox leave (focus leave).
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (!IsValidPhoneNumber(txtPhone.Text))  // Validate phone number format.
            {
                MessageBox.Show("The phone number is not valid. Please enter a valid 11-digit phone number starting with '09'.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();  // Set focus back to Phone TextBox.
            }
        }

        // Method to check if phone number already exists in database.
        private void CheckPhoneNumberExists()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPhone.Text))  // Check if phone number field is empty.
                {
                    return;
                }


                cn.Open();// Open connection.
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM tbl_Employee WHERE phone = @phone", cn);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                int count = (int)command.ExecuteScalar();  // Execute scalar query to get count.

                if (count > 0)  // Check if phone number already exists.
                {
                    MessageBox.Show("This phone number already exists.", "Duplicate Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Text = "";  // Optionally clear the TextBox.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");  // Display error message on exception.
            }
            finally
            {
                cn.Close();  // Always close connection in finally block.
            }
        }

        // Event handler for Clear button click.
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();  // Call method to clear input fields.
        }

        // Event handler for Cancel button click.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();  // Call method to clear input fields.
        }

        // Event handler for Exit button click.
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();  // Dispose current form.
        }

        // Event handler for Role ComboBox selected index change.
        private void txtRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRole.Text == "Supplier")
            {
                this.Height = 453 - 26;  // Adjust form height.
                lblPassword.Visible = false;  // Hide password label.
                txtPassword.Visible = false;  // Hide password TextBox.
                txtPassword.Clear();  // Clear password field.
                check = true;  // Set validation flag to true (bypass validation).
            }
            else
            {
                lblPassword.Visible = true;  // Show password label.
                txtPassword.Visible = true;  // Show password TextBox.
                this.Height = 453;  // Reset form height.
            }
        }

        // Event handler when form loads.
        private void EmployeeModule_Load(object sender, EventArgs e)
        {
            if (cbRole.Text == "Administrator" && employeeForm.LoggedInUsername == txtName.Text)
            {
                cbRole.Enabled = false;  // Disable Role ComboBox for administrators.
            }
        }

        private void CheckField()
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Required data field(s) are empty!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                check = false; // Set check to false to prevent further processing
                return;
            }

            // Validate only if the role is not Supplier
            if (cbRole.Text != "Supplier")
            {
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Password field is empty!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    check = false; // Set check to false to prevent further processing
                    return;
                }
            }

            check = true; // Set check to true if all validations pass
        }

        // Method to calculate age based on birth date.
        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;

            return age;
        }

        // Method to clear input fields.
        private void Clear()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cbRole.SelectedIndex = 1;
            txtPassword.Clear();
            cbBirth.Value = DateTime.Now;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void cbBirth_ValueChanged(object sender, EventArgs e)
        {
            // No action needed in this method.
        }

        // Event handler for Name TextBox text changed.

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a control key (e.g., backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                // If not, cancel the event (ignore the key press)
                e.Handled = true;
            }
        }

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // No action needed in this method.
        }

        // Event handler for Password TextBox text changed.
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // No action needed in this method.
        }

        // Method to validate if key pressed in Address TextBox is valid.
        private bool IsValidAddressCharacter(char keyChar)
        {
            // Define allowed characters: letters, digits, and specific punctuation marks.
            bool isValid = char.IsLetterOrDigit(keyChar) ||
                          keyChar == '.' || keyChar == ',' || keyChar == '\'' ||
                          keyChar == '-' || keyChar == '#' || keyChar == '&';

            return isValid;
        }

        // Event handler for Address TextBox key press.
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidAddressCharacter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Cancel the key press.
            }
        }
    }
}
