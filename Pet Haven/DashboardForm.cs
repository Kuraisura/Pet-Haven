using Pet_Haven;
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

namespace PetHaven
{
    public partial class DashboardForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DbConnect dbcon = new DbConnect();
        string title = "Pet Haven";
        public DashboardForm()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
        }

        public int extractData(string str)
        {
            int data = 0;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT ISNULL(SUM(pqty),0) AS qty FROM tbl_Product WHERE pcategory=@category", cn);
                cm.Parameters.AddWithValue("@category", str);
                data = int.Parse(cm.ExecuteScalar().ToString());
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return data;
        }
        private void lblDog_Click(object sender, EventArgs e)
        {

        }

        public void UpdateLabels()
        {
            lblDog.Text = extractData("Dog").ToString();
            lblCat.Text = extractData("Cat").ToString();
            lblBird.Text = extractData("Bird").ToString();
            lblFish.Text = extractData("Fish").ToString();
        }

        public void UpdateDogLabelAfterDelete(int deletedQty)
        {
            int currentDogQty = int.Parse(lblDog.Text);
            lblDog.Text = (currentDogQty - deletedQty).ToString();
        }

        public void UpdateCatLabelAfterDelete(int deletedQty)
        {
            int currentCatQty = int.Parse(lblCat.Text);
            lblCat.Text = (currentCatQty - deletedQty).ToString();
        }

        public void UpdateBirdLabelAfterDelete(int deletedQty)
        {
            int currentBirdQty = int.Parse(lblBird.Text);
            lblBird.Text = (currentBirdQty - deletedQty).ToString();
        }

        public void UpdateFishLabelAfterDelete(int deletedQty)
        {
            int currentFishQty = int.Parse(lblFish.Text);
            lblFish.Text = (currentFishQty - deletedQty).ToString();
        }

        public void UpdateDogLabelAfterAddition(int addedQty)
        {
            int currentDogQty = int.Parse(lblDog.Text);
            lblDog.Text = (currentDogQty + addedQty).ToString();
        }

        public void UpdateCatLabelAfterAddition(int addedQty)
        {
            int currentCatQty = int.Parse(lblCat.Text);
            lblCat.Text = (currentCatQty + addedQty).ToString();
        }

        public void UpdateBirdLabelAfterAddition(int addedQty)
        {
            int currentBirdQty = int.Parse(lblBird.Text);
            lblBird.Text = (currentBirdQty + addedQty).ToString();
        }

        public void UpdateFishLabelAfterAddition(int addedQty)
        {
            int currentFishQty = int.Parse(lblFish.Text);
            lblFish.Text = (currentFishQty + addedQty).ToString();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void DashboardForm_Activated(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblBird_Click(object sender, EventArgs e)
        {

        }

        private void lblFish_Click(object sender, EventArgs e)
        {

        }

        private void lblCat_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            UpdateLabels();
        }
        
    }
}
