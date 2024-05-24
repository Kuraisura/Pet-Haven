using iTextSharp.text.pdf;
using iTextSharp.text;
using PetHaven; // Importing custom namespace
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace Pet_Haven
{
    public partial class BillingForm : Form
    {
        SqlConnection cn = new SqlConnection(); // Instance field for SqlConnection
        SqlCommand cm = new SqlCommand(); // Instance field for SqlCommand
        DbConnect dbcon = new DbConnect(); // Instance field for database connection helper
        SqlDataReader dr; // Instance field for SqlDataReader
        string title = "Pet Haven"; // Instance field for title string
        private MainForm mainForm; // Private field to hold MainForm instance
        private bool isCustomerSelected = false; // Flag to track if a customer is selected
        private bool checkoutConfirmed = false; // Flag to track if checkout is confirmed
        private string selectedCustomerName; // Holds the selected customer's name
        public string CurrentUser { get; set; } // Property for current user's name
        public event EventHandler CheckoutCompleted;

        // Constructor that initializes the form with a MainForm instance
        public BillingForm(MainForm form)
        {
            InitializeComponent(); // Initialize form components
            mainForm = form; // Assign MainForm instance passed from constructor
            cn = new SqlConnection(dbcon.connection()); // Initialize SqlConnection with connection string
            getTransNo(); // Method call to retrieve transaction number
            LoadBilling(); // Method call to load billing data
            btnCheckOut.Enabled = false; // Disable checkout button initially
        }

        // Event handler for checkout button click
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvBilling.Rows.Count > 0)
            {
                ChooseCustomer(); // Method call to choose a customer for checkout
            }
            else
            {
                MessageBox.Show("Please add products to the billing before Choosing Customer.", "No Products Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected virtual void OnCheckoutCompleted(EventArgs e)
        {
            CheckoutCompleted?.Invoke(this, e);
        }

        private void SuccessfulCheckout()
        {
            if (mainForm != null && mainForm.btnTransaction != null)
            {
                mainForm.btnTransaction.Visible = true;
            }
            else
            {
                // Handle case where mainForm or btnTransaction is not accessible
                MessageBox.Show("Unable to access transaction button on main form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Notify MainForm that checkout is completed
            OnCheckoutCompleted(EventArgs.Empty);
        }


        // Method to generate QR code for a transaction and add it to a PDF document
        public void GenerateQRCode(string transactionNumber, Document document)
        {
            // QR code generation using QRCoder library
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(transactionNumber, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(5); // Generate QR code image

            // Convert QR code image to iTextSharp image and add to PDF document
            iTextSharp.text.Image qrCodeImg = iTextSharp.text.Image.GetInstance(qrCodeImage, System.Drawing.Imaging.ImageFormat.Png);
            qrCodeImg.Alignment = iTextSharp.text.Image.ALIGN_CENTER; // Align QR code to center
            qrCodeImg.SetAbsolutePosition(document.PageSize.Width / 2 - 50f, 50f); // Set position
            qrCodeImg.ScaleAbsolute(100f, 100f); // Scale QR code size
            document.Add(qrCodeImg); // Add QR code image to document
        }

        // Method to handle choosing a customer for checkout
        private void ChooseCustomer()
        {
            // Check if there are products in billing
            if (dgvBilling.Rows.Count == 0)
            {
                MessageBox.Show("There are no products to check out. Add products before choosing a customer.", "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Open a BillingCustomer form to select a customer
            BillingCustomer customerForm = new BillingCustomer(this);
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                selectedCustomerName = customerForm.SelectedCustomerName; // Set selected customer's name
                int customerId = customerForm.SelectedCustomerId; // Get selected customer ID

                // Update customer ID in tbl_Billing for the selected transaction
                dbcon.executeQuery("UPDATE tbl_Billing SET cid = " + customerId + " WHERE transno = '" + lblTransNo.Text + "'");

                // Refresh billing display after customer selection
                LoadBilling();

                // Set customer selected flag to true and enable checkout button
                isCustomerSelected = true;
                btnCheckOut.Enabled = true;
            }
        }



        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BillingProduct product = new BillingProduct(this);
            product.uname = mainForm.lblUsername.Text; // Pass logged-in user's name to BillingProduct form
            DialogResult result = product.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Optionally handle any data transfer or processing upon product form OK
                // For example, you might refresh the billing display or update related data.
                LoadBilling(); // Reload billing data after adding a product
            }
            // You may choose not to do any additional data handling here if not needed
        }


        // Event handler for DataGridView cell content click (for delete, increase, and decrease buttons)
        private void dgvBilling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBilling.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                // Delete product from billing if confirmed by user
                if (MessageBox.Show("Are you sure you want to delete this?", "Delete Cash", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbcon.executeQuery("DELETE FROM tbl_Billing WHERE cashid LIKE '" + dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("Record has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadBilling(); // Reload billing data after deletion
                }
            }
            else if (colName == "Increase")
            {
                // Increase product quantity in billing if within available stock
                int i = checkPqty(dgvBilling.Rows[e.RowIndex].Cells[2].Value.ToString());
                if (int.Parse(dgvBilling.Rows[e.RowIndex].Cells[4].Value.ToString()) < i)
                {
                    dbcon.executeQuery("UPDATE tbl_Billing SET qty = qty + " + 1 + " WHERE cashid LIKE '" + dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                }
                else
                {
                    // Inform if stock is insufficient for the requested quantity
                    MessageBox.Show("Remaining quantity on hand is " + i + "!", "Out of Stock ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "Decrease")
            {
                // Decrease product quantity in billing if greater than one
                if (int.Parse(dgvBilling.Rows[e.RowIndex].Cells[4].Value.ToString()) > 1)
                {
                    dbcon.executeQuery("UPDATE tbl_Billing SET qty = qty - " + 1 + " WHERE cashid LIKE '" + dgvBilling.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                }
                else
                {
                    // Inform if quantity cannot be less than one
                    MessageBox.Show("Quantity cannot be less than 1.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            LoadBilling(); // Reload billing data after any modification
        }

        // Method to get the latest transaction number for the new billing
        public string getTransNo()
        {
            string transno = "";

            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;

                cn.Open();
                cm = new SqlCommand("SELECT TOP 1 transno FROM tbl_Billing WHERE transno LIKE '" + sdate + "%' ORDER BY cashid DESC", cn);
                dr = cm.ExecuteReader();

                if (dr.Read())
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lblTransNo.Text = sdate + (count + 1);
                }
                else
                {
                    transno = sdate + "1001";
                    lblTransNo.Text = transno;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
            finally
            {
                cn.Close();
            }

            return transno;
        }

        // Method to load billing details from the database
        public void LoadBilling()
        {
            try
            {
                using (SqlConnection cn = dbcon.GetConnection())
                {
                    int i = 0;
                    double total = 0;
                    dgvBilling.Rows.Clear();

                    string query = @"
                SELECT billing.cashid, billing.pcode, p.pname AS pname, 
                       billing.qty, billing.price, billing.total, c.name AS name, 
                       billing.cashier
                FROM tbl_Billing AS billing
                LEFT JOIN tbl_Customer c ON billing.cid = c.id
                LEFT JOIN tbl_Product p ON billing.pcode = p.pcode
                WHERE billing.transno = @TransNo";

                    using (SqlCommand cm = new SqlCommand(query, cn))
                    {
                        cm.Parameters.AddWithValue("@TransNo", lblTransNo.Text);
                        cn.Open();
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                i++;
                                dgvBilling.Rows.Add(
                                    i,
                                    dr["cashid"].ToString(),
                                    dr["pcode"].ToString(),
                                    dr["pname"].ToString(),
                                    dr["qty"].ToString(),
                                    dr["price"].ToString(),
                                    dr["total"].ToString(),
                                    dr["name"].ToString(),
                                    dr["cashier"].ToString()
                                );
                                total += double.Parse(dr["total"].ToString());
                            }
                        }
                        lblTotal.Text = total.ToString("#,##0.00");
                    }

                    btnCheckOut.Enabled = dgvBilling.Rows.Count > 0; // Enable checkout button if there are items in the billing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        public int checkPqty(string pcode)
        {
            int i = 0;
            try
            {
                cn.Open(); // Opening a database connection
                cm = new SqlCommand("SELECT pqty FROM tbl_Product WHERE pcode LIKE '" + pcode + "'", cn); // Creating a SQL command object
                i = int.Parse(cm.ExecuteScalar().ToString()); // Executing a SQL query and parsing the result
                cn.Close(); // Closing the database connection
            }
            catch (Exception ex)
            {
                cn.Close(); // Ensuring database connection closure on exception
                MessageBox.Show(ex.Message, title); // Displaying an error message
            }
            return i; // Returning the fetched product quantity
        }

        public void DisableResetDailySalesButton()
        {
            mainForm.btnResetSales.Enabled = false; // Disabling a button on MainForm
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBilling(); // Invoking a method to refresh billing data
        }

        private void RefreshBilling()
        {
            LoadBilling(); // Invoking a method to load billing data
        }

        public void SetCheckoutConfirmed(bool confirmed)
        {
            checkoutConfirmed = confirmed; // Setting a checkout confirmation flag
        }

        public void ResetFormState()
        {
            dgvBilling.Rows.Clear(); // Clearing DataGridView rows
        }

        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBilling.Rows)
            {
                if (!row.IsNewRow && string.IsNullOrEmpty(row.Cells[7].Value?.ToString()))
                {
                    MessageBox.Show("Please select a customer for each product before checking out.", "Customer Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Displaying a warning message
                    return; // Exiting method if customer selection is incomplete
                }
            }

            if (!isCustomerSelected)
            {
                MessageBox.Show("Please select a customer before checking out.", "Customer Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Displaying a warning message
                return; // Exiting method if customer is not selected
            }

            if (string.IsNullOrEmpty(lblTransNo.Text))
            {
                MessageBox.Show("Please select a customer before checking out.", "Transaction Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Displaying a warning message
                return; // Exiting method if transaction number is missing
            }

            using (CustomerCashForm customerCashForm = new CustomerCashForm())
            {
                customerCashForm.ShowDialog(); // Showing a modal dialog for customer cash input

                if (customerCashForm.DialogResult == DialogResult.OK)
                {
                    decimal customerCash = customerCashForm.CustomerCash; // Retrieving customer cash amount from dialog
                    decimal totalAmount = CalculateTotalAmount(); // Calling a method to calculate total amount

                    if (customerCash >= totalAmount)
                    {
                        decimal change = customerCash - totalAmount; // Calculating change amount
                        DateTime purchaseDate = DateTime.Now; // Getting current date and time

                        if (MessageBox.Show("Are you sure you want to check out this product?", "Checking Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                string transNo = lblTransNo.Text; // Retrieving transaction number
                                mainForm.loadDailySale(); // Calling a method on MainForm to load daily sales

                                for (int i = 0; i < dgvBilling.Rows.Count; i++)
                                {
                                    int qty = Convert.ToInt32(dgvBilling.Rows[i].Cells[4].Value); // Retrieving quantity from DataGridView
                                    string pcode = dgvBilling.Rows[i].Cells[2].Value.ToString(); // Retrieving product code from DataGridView

                                    dbcon.executeParameterizedQuery("UPDATE tbl_Product SET pqty = pqty - @Qty WHERE pcode = @Pcode",
                                        new SqlParameter("@Qty", qty),
                                        new SqlParameter("@Pcode", pcode)); // Executing parameterized SQL update query
                                }

                                dbcon.executeParameterizedQuery("UPDATE tbl_Billing SET purchaseDate = @PurchaseDate, cash = @Cash, [change] = @Change WHERE transno = @TransNo",
                                    new SqlParameter("@PurchaseDate", purchaseDate),
                                    new SqlParameter("@Cash", customerCash),
                                    new SqlParameter("@Change", change),
                                    new SqlParameter("@TransNo", transNo)); // Executing parameterized SQL update query

                                string directoryPath = @"C:\Users\Public\Documents\";
                                string fileName = Path.Combine(directoryPath, $"{transNo}.pdf");
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath); // Creating directory if it doesn't exist
                                }

                                // Generate PDF receipt with QR code
                                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                                using (Document doc = new Document(PageSize.B7, 10f, 10f, 10f, 10f)) // Creating PDF document with specific page size
                                {
                                    PdfWriter.GetInstance(doc, fs); // Getting PDF writer instance
                                    doc.Open(); // Opening the document

                                    // Adding logo to the PDF and centering it
                                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("C:\\Users\\kurai\\Downloads\\Pet Haven V3\\Pet Haven\\images\\logo.png");
                                    logo.ScaleToFit(80f, 80f); // Scaling the logo
                                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER; // Aligning the logo
                                    doc.Add(logo); // Adding the logo to the document

                                    // Adding company address and contact information and centering it
                                    Paragraph title = new Paragraph("PET HAVEN");
                                    title.Alignment = Element.ALIGN_CENTER; // Aligning the title
                                    title.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16); // Setting font and size for the title
                                    doc.Add(title); // Adding the title to the document
                                    Paragraph address = new Paragraph("Balibago Rd, Balibago, Santa Rosa, 4026 Laguna\nTel #: +63 2 88121784");
                                    address.Alignment = Element.ALIGN_CENTER; // Aligning the address
                                    address.Font = FontFactory.GetFont(FontFactory.HELVETICA, 8); // Setting font and size for the address
                                    doc.Add(address); // Adding the address to the document

                                    // Adding blank lines
                                    doc.Add(new Paragraph(" "));

                                    // Adding date, receipt number, cashier's name, and customer's name
                                    Paragraph header = new Paragraph();
                                    header.Alignment = Element.ALIGN_LEFT; // Aligning to the left
                                    header.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10); // Setting font and size for the header
                                    header.Add(new Chunk("Date and Time: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))); // Adding date and time label
                                    header.Add(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")); // Adding formatted date and time
                                    header.Add(Chunk.NEWLINE); // Adding newline
                                    header.Add(new Chunk("Receipt Number: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))); // Adding receipt number label
                                    header.Add(transNo); // Adding transaction number
                                    header.Add(Chunk.NEWLINE); // Adding newline
                                    header.Add(new Chunk("Cashier: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))); // Adding cashier label
                                    header.Add(new Chunk(CurrentUser)); // Adding current user's name
                                    header.Add(Chunk.NEWLINE); // Adding newline
                                    header.Add(new Chunk("Customer's Name: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))); // Adding customer name label
                                    header.Add(selectedCustomerName); // Adding selected customer's name
                                    doc.Add(header); // Adding header to the document

                                    // Adding blank lines
                                    doc.Add(new Paragraph(" "));

                                    // Adding product details to a table
                                    PdfPTable productTable = new PdfPTable(3); // Creating a table with 3 columns
                                    productTable.WidthPercentage = 100; // Setting table width to 100%
                                    productTable.DefaultCell.Padding = 3; // Adding padding to table cells

                                    // Adding table headers with bold font
                                    PdfPCell cellProduct = new PdfPCell(new Phrase("Product", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))); // Creating cell for product name
                                    PdfPCell cellQuantity = new PdfPCell(new Phrase("Quantity", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))); // Creating cell for quantity
                                    PdfPCell cellPrice = new PdfPCell(new Phrase("Price", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))); // Creating cell for price

                                    // Setting cell alignment and borders
                                    cellProduct.HorizontalAlignment = Element.ALIGN_LEFT; // Aligning product name to the left
                                    cellQuantity.HorizontalAlignment = Element.ALIGN_CENTER; // Aligning quantity to the center
                                    cellPrice.HorizontalAlignment = Element.ALIGN_RIGHT; // Aligning price to the right
                                    cellProduct.Border = PdfPCell.NO_BORDER; // Removing border from product cell
                                    cellQuantity.Border = PdfPCell.NO_BORDER; // Removing border from quantity cell
                                    cellPrice.Border = PdfPCell.NO_BORDER; // Removing border from price cell

                                    // Adding cells to the table
                                    productTable.AddCell(cellProduct); // Adding product cell to the table
                                    productTable.AddCell(cellQuantity); // Adding quantity cell to the table
                                    productTable.AddCell(cellPrice); // Adding price cell to the table

                                    // Adding product details from DataGridView to the table
                                    foreach (DataGridViewRow row in dgvBilling.Rows)
                                    {
                                        if (!row.IsNewRow)
                                        {
                                            string productName = row.Cells[3].Value.ToString(); // Getting product name from DataGridView
                                            string quantity = row.Cells[4].Value.ToString(); // Getting quantity from DataGridView
                                            string price = row.Cells[5].Value.ToString(); // Getting price from DataGridView

                                            productTable.AddCell(productName); // Adding product name to the table
                                            productTable.AddCell(quantity); // Adding quantity to the table
                                            productTable.AddCell("₱" + price); // Adding formatted price to the table
                                        }
                                    }

                                    doc.Add(productTable); // Adding product table to the document

                                    // Adding total, cash, change, and thank you message
                                    Paragraph footer = new Paragraph();
                                    footer.Alignment = Element.ALIGN_LEFT; // Aligning footer to the left
                                    footer.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10); // Setting bold font for footer

                                    // Adding total amount
                                    footer.Add(new Chunk("Total: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                                    footer.Add(new Chunk("₱" + totalAmount.ToString("#,##0.00"), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                                    footer.Add(Chunk.NEWLINE); // Adding newline

                                    // Adding cash amount
                                    footer.Add(new Chunk("Cash: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                                    footer.Add(new Chunk("₱" + customerCash.ToString("#,##0.00"), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                                    footer.Add(Chunk.NEWLINE); // Adding newline

                                    // Adding change amount
                                    footer.Add(new Chunk("Change: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                                    footer.Add(new Chunk("₱" + change.ToString("#,##0.00"), FontFactory.GetFont(FontFactory.HELVETICA, 10)));
                                    footer.Add(Chunk.NEWLINE); // Adding newline

                                    // Adding spacing
                                    for (int i = 0; i < 2; i++) // Adding 2 blank lines
                                    {
                                        footer.Add(new Paragraph(" "));
                                    }

                                    // Adding thank you message
                                    Paragraph thanks = new Paragraph("THANK YOU, COME AGAIN!");
                                    thanks.Alignment = Element.ALIGN_CENTER; // Aligning thank you message to the center
                                    thanks.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10); // Setting bold font for thank you message
                                    footer.Add(thanks); // Adding thank you message to the footer

                                    doc.Add(footer); // Adding footer to the document

                                    // Generating QR code and adding to the document
                                    GenerateQRCode(transNo, doc); // Calling method to generate QR code and add to PDF

                                    doc.Close(); // Closing the document
                                }

                                btnCheckOut.Enabled = false; // Disabling Check Out button after successful transaction
                                mainForm.btnTransaction.Enabled = true;
                                mainForm.btnTransaction.Visible = true;

                                dgvBilling.Rows.Clear(); // Clearing DataGridView rows after checkout
                                MessageBox.Show($"Transaction Successful!\nChange: {change.ToString("#,##0.00")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Showing success message

                                btnCheckOut.Enabled = false; // Disabling Check Out button after successful transaction
                                lblTransNo.Text = string.Empty; // Clearing transaction number label
                                getTransNo(); // Generating new transaction number
                                isCustomerSelected = false; // Resetting customer selection flag
                                OnCheckoutCompleted(EventArgs.Empty);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred during checkout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Showing error message on checkout failure
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insufficient Funds, Please try adding more funds or removing a product", "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Showing insufficient funds message
                    }
                }
            }
        }

        public void ResetCustomerSelection()
        {
            isCustomerSelected = false; // Resetting customer selection flag
            lblTransNo.Text = string.Empty; // Clearing transaction number label
        }

        public decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0; // Initializing total amount variable

            // Calculating total amount from DataGridView
            foreach (DataGridViewRow row in dgvBilling.Rows)
            {
                if (!row.IsNewRow)
                {
                    int qty = Convert.ToInt32(row.Cells[4].Value); // Getting quantity from DataGridView
                    decimal price = Convert.ToDecimal(row.Cells[5].Value); // Getting price from DataGridView

                    totalAmount += qty * price; // Calculating total amount
                }
            }

            return totalAmount; // Returning calculated total amount
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTransNo_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}

