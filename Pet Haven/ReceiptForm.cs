using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class ReceiptForm : Form
    {
        private string transactionNumber;
        private string customerName;

        public ReceiptForm()
        {
            InitializeComponent();
        }

        public ReceiptForm(string transactionNumber, string customerName, string customerName1)
        {
            this.transactionNumber = transactionNumber;
            this.customerName = customerName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void lblCashier_Click(object sender, EventArgs e)
        {

        }
    }
}
