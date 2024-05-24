using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class ProductModule : Form
    {
        SqlConnection cn = new SqlConnection(); // SqlConnection instance for database connection
        SqlCommand cm = new SqlCommand(); // SqlCommand instance for executing SQL queries
        DbConnect dbcon = new DbConnect(); // Custom class for managing database connection details
        string title = "Pet Haven"; // String for message box titles
        bool check = false; // Boolean flag for form validation
        ProductForm product; // Reference to ProductForm for interaction

        // Breed-to-Category dictionary for mapping breeds to categories
        Dictionary<string, string> breedCategoryMap = new Dictionary<string, string>
        {
        // Dogs
        { "Labrador", "Dog" },
    { "Bulldog", "Dog" },
    { "Poodle", "Dog" },
    { "Golden Retriever", "Dog" },
    { "American Bulldog", "Dog" },
    { "American Cocker Spaniel", "Dog" },
    { "American Eskimo Dog", "Dog" },
    { "American Foxhound", "Dog" },
    { "American Pit Bull Terrier", "Dog" },
    { "American Staffordshire Terrier", "Dog" },
    { "American Water Spaniel", "Dog" },
    { "Boston Terrier", "Dog" },
            { "Askal", "Dog" },
    { "Coonhound", "Dog" },
    { "Plott Hound", "Dog" },
    { "Rat Terrier", "Dog" },
    { "Alaskan Malamute", "Dog" },
    { "Beagle", "Dog" },
    { "Border Collie", "Dog" },
    { "Border Terrier", "Dog" },
    { "Bullmastiff", "Dog" },
    { "English Bulldog", "Dog" },
    { "English Cocker Spaniel", "Dog" },
    { "English Setter", "Dog" },
    { "English Springer Spaniel", "Dog" },
    { "Jack Russell Terrier", "Dog" },
    { "Staffordshire Bull Terrier", "Dog" },
    { "Cavalier King Charles Spaniel", "Dog" },
    { "Affenpinscher", "Dog" },
    { "Doberman Pinscher", "Dog" },
    { "German Shepherd", "Dog" },
    { "Great Dane", "Dog" },
    { "Miniature Schnauzer", "Dog" },
    { "Pomeranian", "Dog" },
    { "Rottweiler", "Dog" },
    { "Weimaraner", "Dog" },
    { "Dachshund", "Dog" },
    { "German Shorthaired Pointer", "Dog" },
    { "Basset Hound", "Dog" },
    { "Beauceron", "Dog" },
    { "Brittany Spaniel", "Dog" },
    { "French Bulldog", "Dog" },
    { "Papillon", "Dog" },
    { "Pyrenean Shepherd", "Dog" },
    { "Dogue de Bordeaux", "Dog" },
    { "Bergamasco Sheepdog", "Dog" },
    { "Cane Corso", "Dog" },
    { "Italian Greyhound", "Dog" },
    { "Neapolitan Mastiff", "Dog" },
    { "Spinone Italiano", "Dog" },
    { "Bolognese", "Dog" },
    { "Black Russian Terrier", "Dog" },
    { "Borzoi", "Dog" },
    { "Caucasian Shepherd Dog", "Dog" },
    { "Russian Toy", "Dog" },
    { "Siberian Husky", "Dog" },
    { "Samoyed", "Dog" },
    { "Akita Inu", "Dog" },
    { "Japanese Chin", "Dog" },
    { "Japanese Spitz", "Dog" },
    { "Shiba Inu", "Dog" },
    { "Tosa Inu", "Dog" },
    { "Kishu Ken", "Dog" },
    { "Chow Chow", "Dog" },
    { "Pekingese", "Dog" },
    { "Shar Pei", "Dog" },
    { "Shih Tzu", "Dog" },
    { "Chinese Crested", "Dog" },
    { "Australian Cattle Dog", "Dog" },
    { "Australian Shepherd", "Dog" },
    { "Australian Terrier", "Dog" },
    { "Kelpie", "Dog" },
    { "Silky Terrier", "Dog" },
    { "Canadian Eskimo Dog", "Dog" },
    { "Nova Scotia Duck Tolling Retriever", "Dog" },
    { "Newfoundland", "Dog" },
    { "Belgian Malinois", "Dog" },
    { "Belgian Sheepdog", "Dog" },
    { "Belgian Tervuren", "Dog" },
    { "Brussels Griffon", "Dog" },
    { "Bernese Mountain Dog", "Dog" },
    { "St. Bernard", "Dog" },
    { "Swiss Mountain Dog", "Dog" },
    { "Entlebucher Mountain Dog", "Dog" },
    { "Spanish Mastiff", "Dog" },
    { "Ibizan Hound", "Dog" },
    { "Pyrenean Mastiff", "Dog" },
    { "Spanish Water Dog", "Dog" },
    { "Chihuahua", "Dog" },
    { "Xoloitzcuintli", "Dog" },
    { "Brazilian Mastiff (Fila Brasileiro)", "Dog" },
    { "Boerboel", "Dog" },
    { "Rhodesian Ridgeback", "Dog" },
    { "Dogo Argentino", "Dog" },
    { "Komondor", "Dog" },
    { "Puli", "Dog" },
    { "Vizsla", "Dog" },
    { "Kuvasz", "Dog" },
    { "Polish Lowland Sheepdog", "Dog" },
    { "Polish Tatra Sheepdog", "Dog" },
    { "Portuguese Podengo", "Dog" },
    { "Portuguese Water Dog", "Dog" },
    { "Estrela Mountain Dog", "Dog" },
    { "Indian Pariah Dog", "Dog" },
    { "Rajapalayam", "Dog" },
    { "Mudhol Hound", "Dog" },
    { "Thai Ridgeback", "Dog" },
    { "Bangkaew Dog", "Dog" },
    { "Finnish Lapphund", "Dog" },
    { "Finnish Spitz", "Dog" },
    { "Karelian Bear Dog", "Dog" },
    { "Norwegian Buhund", "Dog" },
    { "Norwegian Elkhound", "Dog" },
    { "Norwegian Lundehund", "Dog" },
    { "Swedish Vallhund", "Dog" },
    { "Norrbottenspets", "Dog" },
    { "Broholmer", "Dog" },
    { "Danish-Swedish Farmdog", "Dog" },
    { "Dutch Shepherd", "Dog" },
    { "Keeshond", "Dog" },
    { "Schapendoes", "Dog" },
    { "Anatolian Shepherd Dog", "Dog" },
    { "Kangal Shepherd Dog", "Dog" },
    { "Pharaoh Hound", "Dog" },

        // Cats
        { "American Shorthair", "Cat" },
    { "American Curl", "Cat" },
    { "American Bobtail", "Cat" },
    { "Maine Coon", "Cat" },
    { "Ragdoll", "Cat" },
    { "Ocicat", "Cat" },
    { "Selkirk Rex", "Cat" },
    { "LaPerm", "Cat" },
    { "British Shorthair", "Cat" },
    { "British Longhair", "Cat" },
    { "Cornish Rex", "Cat" },
    { "Devon Rex", "Cat" },
    { "Siberian", "Cat" },
    { "Russian Blue", "Cat" },
    { "Donskoy", "Cat" },
    { "Peterbald", "Cat" },
    { "Sphynx", "Cat" },
    { "Japanese Bobtail", "Cat" },
    { "Egyptian Mau", "Cat" },
    { "Siamese", "Cat" },
    { "Korat", "Cat" },
    { "Turkish Van", "Cat" },
    { "Turkish Angora", "Cat" },
    { "Norwegian Forest Cat", "Cat" },
    { "Burmese", "Cat" },
    { "Persian", "Cat" },
    { "Chartreux", "Cat" },
    { "Italian Rex", "Cat" },
    { "Brazilian Shorthair", "Cat" },
    { "Singapura", "Cat" },
    { "Australian Mist", "Cat" },
    { "European Shorthair", "Cat" },
    { "German Rex", "Cat" },
    { "Austrian Rex", "Cat" },
    { "Balinese", "Cat" },
    { "Dragon Li", "Cat" },
    { "Manx", "Cat" },
    { "Cypriot Cat", "Cat" },
    { "African Wildcat", "Cat" },
    { "Swedish Forest Cat", "Cat" },
    { "Polish Domestic Cat", "Cat" },
    { "Thai", "Cat" },
    { "Scottish Fold", "Cat" },
    { "Scottish Straight", "Cat" },
    { "Hungarian Longhair", "Cat" },
    { "Maltese", "Cat" },
    { "Spanish Cat", "Cat" },
    { "Portuguese Shorthair", "Cat" },
    { "Pura", "Cat" },
    { "New Zealand Cat", "Cat" },
    { "Armenian Van Cat", "Cat" },
    { "Finnish Cat", "Cat" },
    { "Aegean Cat", "Cat" },
    { "Arabian Mau", "Cat" },
    { "Icelandic Cat", "Cat" },
    { "Indian Billi", "Cat" },
    { "Mexican Hairless Cat", "Cat" },
    { "Ukrainian Levkoy", "Cat" },
    { "Kazakhstani Cat", "Cat" },
    { "Latvian Rex", "Cat" },
    { "Lithuanian Rex", "Cat" },
    { "Dutch Cat", "Cat" },

        // Birds
         { "Cockatoo", "Bird" },
    { "Budgerigar", "Bird" },
    { "Lovebird", "Bird" },
    { "Eclectus Parrot", "Bird" },
    { "Macaw", "Bird" },
    { "Conure", "Bird" },
    { "Amazon Parrot", "Bird" },
    { "Parrotlet", "Bird" },
    { "African Grey Parrot", "Bird" },
    { "Cockatiel", "Bird" },
    { "Finch", "Bird" },
    { "Canary", "Bird" },
    { "King Parrot", "Bird" },
    { "Parakeet", "Bird" },
    { "Sparrow", "Bird" },

        // Fish
       { "Betta Fish", "Fish" },
    { "Goldfish", "Fish" },
    { "Guppy", "Fish" },
    { "Neon Tetra", "Fish" },
    { "Koi Fish", "Fish" },
    { "Ryukin Goldfish", "Fish" },
    { "Shubunkin Goldfish", "Fish" },
    { "Medaka", "Fish" },
    { "Fancy Goldfish", "Fish" },
    { "Bristlenose Pleco", "Fish" },
    { "Harlequin Rasbora", "Fish" },
    { "Swordtail", "Fish" },
    { "Rainbowfish", "Fish" },
    { "Australian Bass", "Fish" },
    { "Banded Rainbowfish", "Fish" },
    { "Murray River Rainbowfish", "Fish" },
    { "Discus", "Fish" },
    { "Angelfish", "Fish" },
    { "Cardinal Tetra", "Fish" },
    { "Corydoras Catfish", "Fish" },
    { "Zebra Danio", "Fish" },
    { "Platy", "Fish" },
    { "African Cichlids", "Fish" },
    { "Kribensis", "Fish" },
    { "Congo Tetra", "Fish" },
    { "Clown Loach", "Fish" },
    { "Paradise Fish", "Fish" },
    { "White Cloud Mountain Minnow", "Fish" },
    { "Molly Fish", "Fish" },
    { "Gourami", "Fish" },
    { "Red-tailed Catfish", "Fish" },
    { "Arowana", "Fish" },
    };

        public void DisableUpdateButton()
        {
            btnUpdate.Enabled = false; // Method to disable the update button
        }

        public ProductModule(ProductForm form)
        {
            InitializeComponent(); // Initialize form components
            cn = new SqlConnection(dbcon.connection()); // Initialize SqlConnection using connection string
            product = form; // Assign ProductForm instance

            // Initialize cbCategory ComboBox
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList; // Set ComboBox style to DropDownList
            cbCategory.SelectedIndex = 0; // Set default selection
            cbCategory.Enabled = false; // Disable the ComboBox

            // Attach event handlers
            txtPrice.KeyPress += new KeyPressEventHandler(txtPrice_KeyPress); // Attach event handler for price TextBox key press
            txtQty.KeyPress += new KeyPressEventHandler(txtQty_KeyPress); // Attach event handler for quantity TextBox key press
            txtName.TextChanged += new EventHandler(txtName_TextChanged); // Attach event handler for name TextBox text change
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Update category based on breed if it exists in the dictionary
            string breed = txtName.Text.Trim();

            // Try to find the breed ignoring case
            KeyValuePair<string, string> foundPair = breedCategoryMap.FirstOrDefault(x => x.Key.Equals(breed, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(foundPair.Key))
            {
                cbCategory.Text = foundPair.Value; // Set the category in the ComboBox
            }
            else
            {
                cbCategory.SelectedIndex = 0; // Reset to default if breed not found
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField(); // Validate form fields

                if (check)
                {
                    // Check if breed is valid ignoring case
                    string breed = txtName.Text.Trim();
                    KeyValuePair<string, string> foundPair = breedCategoryMap.FirstOrDefault(x => x.Key.Equals(breed, StringComparison.OrdinalIgnoreCase));

                    if (foundPair.Key == null)
                    {
                        MessageBox.Show("Invalid Breed. Please input a valid one.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Use the original dictionary entry for breed to ensure correct casing
                    string originalBreed = foundPair.Key;
                    string category = foundPair.Value;

                    if (IsDuplicateProductName(originalBreed))
                    {
                        MessageBox.Show("Product name already exists. Please use a different name.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validate price format
                    double price;
                    if (!double.TryParse(txtPrice.Text, out price))
                    {
                        MessageBox.Show("Invalid Price format. Please input a valid number.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show("Are you sure you want to register this product?", "Product Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Insert product into database
                        cm = new SqlCommand("INSERT INTO tbl_Product(pname, pcategory, pqty, pprice) VALUES (@pname, @pcategory, @pqty, @pprice)", cn);
                        cm.Parameters.AddWithValue("@pname", originalBreed); // Use originalBreed for correct casing
                        cm.Parameters.AddWithValue("@pcategory", category); // Set category from dictionary
                        cm.Parameters.AddWithValue("@pqty", int.Parse(txtQty.Text));
                        cm.Parameters.AddWithValue("@pprice", price); // Use validated price

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully registered!", title);
                        Clear(); // Clear form fields
                        product.LoadProduct(); // Reload products in ProductForm
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField(); // Ensure all fields are filled before proceeding with update

                if (check)
                {
                    string breed = txtName.Text.Trim();
                    KeyValuePair<string, string> foundPair = breedCategoryMap.FirstOrDefault(x => x.Key.Equals(breed, StringComparison.OrdinalIgnoreCase));

                    // Check if breed is valid
                    if (foundPair.Key == null)
                    {
                        MessageBox.Show("Invalid Breed. Please input a valid one.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Always set category based on breed
                    string originalBreed = foundPair.Key;
                    string category = foundPair.Value;

                    // Check if the updated name is different from the original name
                    if (breed != txtName.Text.Trim() && IsDuplicateProductName(originalBreed))
                    {
                        MessageBox.Show("Product name already exists. Please use a different name.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show("Are you sure you want to Edit this product?", "Product Edited", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Update product in database
                        cm = new SqlCommand("UPDATE tbl_Product SET pname=@pname, pcategory=@pcategory, pqty=@pqty, pprice=@pprice WHERE pcode=@pcode", cn);
                        cm.Parameters.AddWithValue("@pcode", lblPcode.Text); // Assuming lblPcode displays the product code
                        cm.Parameters.AddWithValue("@pname", originalBreed);
                        cm.Parameters.AddWithValue("@pcategory", category); // Set category from dictionary
                        cm.Parameters.AddWithValue("@pqty", int.Parse(txtQty.Text));
                        cm.Parameters.AddWithValue("@pprice", double.Parse(txtPrice.Text));

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully updated!", title);
                        product.LoadProduct(); // Reload products in ProductForm
                        this.Dispose(); // Close the ProductModule form
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
        }



        private bool IsBreedValid(string breed)
        {
            // Check if breed exists in breedCategoryMap
            return breedCategoryMap.ContainsKey(breed.Trim());
        }


        private bool IsDuplicateProductName(string productName)
        {
            bool isDuplicate = false;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(*) FROM tbl_Product WHERE pname = @pname", cn);
                cm.Parameters.AddWithValue("@pname", productName);
                int count = (int)cm.ExecuteScalar();
                if (count > 0)
                {
                    isDuplicate = true;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return isDuplicate;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Ensure textBox is not null before proceeding
            if (textBox == null)
                return;

            // Allow digits, control keys (like backspace), and a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Disallow the minus sign
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }

            // Ensure format "111.11" (two digits after the decimal point)
            if (e.KeyChar == '.' && textBox.SelectionStart == 0)
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Check if the current text already contains a decimal point
                string currentText = textBox.Text.Insert(textBox.SelectionStart, e.KeyChar.ToString());
                int decimalIndex = currentText.IndexOf('.');
                if (decimalIndex >= 0 && currentText.Substring(decimalIndex).Length > 3)
                {
                    e.Handled = true;
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();// Clear form fields
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();// Dispose the ProductModule form
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ProductModule_Load(object sender, EventArgs e)
        {

        }
        // Clear all input fields
        private void Clear()
        {
            txtName.Clear(); 
            cbCategory.SelectedIndex = 0; 
            txtQty.Clear(); 
            txtPrice.Clear();
            lblPcode.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }


        // Validate that all required fields are filled
        private void CheckField()
        {
            check = true;

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(cbCategory.Text) || string.IsNullOrWhiteSpace(txtQty.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                check = false;
            }
        }

        private void ProductModule_Load_1(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
