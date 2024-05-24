namespace Pet_Haven
{
    partial class BillingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingForm));
            this.dgvBilling = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Increase = new System.Windows.Forms.DataGridViewImageColumn();
            this.Decrease = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCheckOut = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblTransNo = new System.Windows.Forms.Label();
            this.btnChooseCustomer = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBilling
            // 
            this.dgvBilling.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvBilling.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBilling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBilling.BackgroundColor = System.Drawing.Color.White;
            this.dgvBilling.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBilling.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBilling.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBilling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBilling.ColumnHeadersHeight = 30;
            this.dgvBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBilling.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column9,
            this.Column3,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Increase,
            this.Decrease,
            this.Delete});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBilling.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvBilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBilling.EnableHeadersVisualStyles = false;
            this.dgvBilling.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvBilling.Location = new System.Drawing.Point(0, 70);
            this.dgvBilling.Name = "dgvBilling";
            this.dgvBilling.RowHeadersVisible = false;
            this.dgvBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBilling.Size = new System.Drawing.Size(979, 300);
            this.dgvBilling.TabIndex = 5;
            this.dgvBilling.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
            this.dgvBilling.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBilling.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBilling.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBilling.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBilling.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBilling.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBilling.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvBilling.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.dgvBilling.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBilling.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBilling.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBilling.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBilling.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvBilling.ThemeStyle.ReadOnly = false;
            this.dgvBilling.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBilling.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBilling.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBilling.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBilling.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBilling.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvBilling.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBilling.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBilling_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "CashID";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 77;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "Pcode";
            this.Column9.Name = "Column9";
            this.Column9.Width = 73;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column6.HeaderText = "Qty";
            this.Column6.Name = "Column6";
            this.Column6.Width = 53;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column7.HeaderText = "Price";
            this.Column7.Name = "Column7";
            this.Column7.Width = 62;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column8.HeaderText = "Total";
            this.Column8.Name = "Column8";
            this.Column8.Width = 62;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Customer Name";
            this.Column4.Name = "Column4";
            this.Column4.Width = 138;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Cashier";
            this.Column5.Name = "Column5";
            this.Column5.Width = 79;
            // 
            // Increase
            // 
            this.Increase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Increase.HeaderText = "";
            this.Increase.Image = ((System.Drawing.Image)(resources.GetObject("Increase.Image")));
            this.Increase.Name = "Increase";
            this.Increase.Width = 5;
            // 
            // Decrease
            // 
            this.Decrease.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Decrease.HeaderText = "";
            this.Decrease.Image = ((System.Drawing.Image)(resources.GetObject("Decrease.Image")));
            this.Decrease.Name = "Decrease";
            this.Decrease.Width = 5;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 5;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.guna2Panel1.Controls.Add(this.btnCheckOut);
            this.guna2Panel1.Controls.Add(this.btnRefresh);
            this.guna2Panel1.Controls.Add(this.lblTransNo);
            this.guna2Panel1.Controls.Add(this.btnChooseCustomer);
            this.guna2Panel1.Controls.Add(this.lblTotal);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 19);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(979, 51);
            this.guna2Panel1.TabIndex = 4;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Animated = true;
            this.btnCheckOut.BorderRadius = 5;
            this.btnCheckOut.CheckedState.Parent = this.btnCheckOut;
            this.btnCheckOut.CustomImages.Parent = this.btnCheckOut;
            this.btnCheckOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnCheckOut.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.btnCheckOut.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.HoverState.Parent = this.btnCheckOut;
            this.btnCheckOut.Location = new System.Drawing.Point(843, 7);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.ShadowDecoration.Parent = this.btnCheckOut;
            this.btnCheckOut.Size = new System.Drawing.Size(56, 38);
            this.btnCheckOut.TabIndex = 20;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.CheckedState.Parent = this.btnRefresh;
            this.btnRefresh.CustomImages.Parent = this.btnRefresh;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnRefresh.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.Parent = this.btnRefresh;
            this.btnRefresh.Location = new System.Drawing.Point(924, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnRefresh.ShadowDecoration.Parent = this.btnRefresh;
            this.btnRefresh.Size = new System.Drawing.Size(52, 44);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTransNo
            // 
            this.lblTransNo.Location = new System.Drawing.Point(290, 16);
            this.lblTransNo.Name = "lblTransNo";
            this.lblTransNo.Size = new System.Drawing.Size(132, 20);
            this.lblTransNo.TabIndex = 18;
            this.lblTransNo.Text = "0000000000";
            this.lblTransNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTransNo.Click += new System.EventHandler(this.lblTransNo_Click);
            // 
            // btnChooseCustomer
            // 
            this.btnChooseCustomer.Animated = true;
            this.btnChooseCustomer.BorderRadius = 5;
            this.btnChooseCustomer.CheckedState.Parent = this.btnChooseCustomer;
            this.btnChooseCustomer.CustomImages.Parent = this.btnChooseCustomer;
            this.btnChooseCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnChooseCustomer.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.btnChooseCustomer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseCustomer.ForeColor = System.Drawing.Color.White;
            this.btnChooseCustomer.HoverState.Parent = this.btnChooseCustomer;
            this.btnChooseCustomer.Location = new System.Drawing.Point(757, 7);
            this.btnChooseCustomer.Name = "btnChooseCustomer";
            this.btnChooseCustomer.ShadowDecoration.Parent = this.btnChooseCustomer;
            this.btnChooseCustomer.Size = new System.Drawing.Size(80, 38);
            this.btnChooseCustomer.TabIndex = 17;
            this.btnChooseCustomer.Text = "Choose Customer";
            this.btnChooseCustomer.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = false;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(579, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(160, 20);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(439, 16);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(134, 20);
            this.guna2HtmlLabel3.TabIndex = 10;
            this.guna2HtmlLabel3.Text = "Total Price (Pesos)";
            this.guna2HtmlLabel3.Click += new System.EventHandler(this.guna2HtmlLabel3_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(156, 16);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(115, 20);
            this.guna2HtmlLabel2.TabIndex = 9;
            this.guna2HtmlLabel2.Text = "Transaction No.";
            this.guna2HtmlLabel2.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(45, 16);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(94, 20);
            this.guna2HtmlLabel1.TabIndex = 8;
            this.guna2HtmlLabel1.Text = "Add Product";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.CheckedState.Parent = this.btnAdd;
            this.btnAdd.CustomImages.Parent = this.btnAdd;
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.Parent = this.btnAdd;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(3, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAdd.ShadowDecoration.Parent = this.btnAdd;
            this.btnAdd.Size = new System.Drawing.Size(36, 36);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAdd.UseTransparentBackground = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(979, 19);
            this.guna2GradientPanel1.TabIndex = 3;
            this.guna2GradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
            // 
            // BillingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(979, 370);
            this.Controls.Add(this.dgvBilling);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BillingForm";
            this.Text = "A";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvBilling;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CircleButton btnAdd;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotal;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        public Guna.UI2.WinForms.Guna2GradientButton btnChooseCustomer;
        public System.Windows.Forms.Label lblTransNo;
        private Guna.UI2.WinForms.Guna2CircleButton btnRefresh;
        public Guna.UI2.WinForms.Guna2GradientButton btnCheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Increase;
        private System.Windows.Forms.DataGridViewImageColumn Decrease;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}