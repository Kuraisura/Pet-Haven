namespace Pet_Haven
{
    partial class BillingProduct
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingProduct));
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnSubmit = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(800, 19);
            this.guna2GradientPanel1.TabIndex = 3;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduct.ColumnHeadersHeight = 30;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column7,
            this.Select});
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.Location = new System.Drawing.Point(0, 19);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.Size = new System.Drawing.Size(800, 342);
            this.dgvProduct.TabIndex = 9;
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentClick);
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
            this.Column2.HeaderText = "Pcode";
            this.Column2.Name = "Column2";
            this.Column2.Width = 73;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Category";
            this.Column5.Name = "Column5";
            this.Column5.Width = 92;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "Price";
            this.Column7.Name = "Column7";
            this.Column7.Width = 62;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 50;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.btnBack);
            this.guna2GradientPanel2.Controls.Add(this.btnSubmit);
            this.guna2GradientPanel2.Controls.Add(this.txtSearch);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 361);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.Parent = this.guna2GradientPanel2;
            this.guna2GradientPanel2.Size = new System.Drawing.Size(800, 89);
            this.guna2GradientPanel2.TabIndex = 10;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Animated = true;
            this.btnSubmit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubmit.BorderRadius = 5;
            this.btnSubmit.CheckedState.Parent = this.btnSubmit;
            this.btnSubmit.CustomImages.Parent = this.btnSubmit;
            this.btnSubmit.FillColor = System.Drawing.Color.White;
            this.btnSubmit.FillColor2 = System.Drawing.Color.White;
            this.btnSubmit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.HoverState.Parent = this.btnSubmit;
            this.btnSubmit.Location = new System.Drawing.Point(636, 18);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.ShadowDecoration.Parent = this.btnSubmit;
            this.btnSubmit.Size = new System.Drawing.Size(128, 38);
            this.btnSubmit.TabIndex = 18;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 20;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(188, 18);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtSearch.PlaceholderText = "  Search......";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(405, 36);
            this.txtSearch.TabIndex = 3;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.guna2GradientPanel1;
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.BorderRadius = 5;
            this.btnBack.CheckedState.Parent = this.btnBack;
            this.btnBack.CustomImages.Parent = this.btnBack;
            this.btnBack.FillColor = System.Drawing.Color.White;
            this.btnBack.FillColor2 = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.HoverState.Parent = this.btnBack;
            this.btnBack.Location = new System.Drawing.Point(22, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.Parent = this.btnBack;
            this.btnBack.Size = new System.Drawing.Size(128, 38);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // BillingProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillingProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillingProduct";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        public Guna.UI2.WinForms.Guna2GradientButton btnSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private new System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        public Guna.UI2.WinForms.Guna2GradientButton btnBack;
    }
}