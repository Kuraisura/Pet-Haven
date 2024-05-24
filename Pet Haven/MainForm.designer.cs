namespace PetHaven
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.panelChild = new System.Windows.Forms.Panel();
            this.panelReport = new System.Windows.Forms.Panel();
            this.btnTransaction = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnResetSales = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblDailySale = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.panelReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.btnLogout);
            this.panelSideMenu.Controls.Add(this.btnCash);
            this.panelSideMenu.Controls.Add(this.btnProducts);
            this.panelSideMenu.Controls.Add(this.btnEmployees);
            this.panelSideMenu.Controls.Add(this.btnCustomers);
            this.panelSideMenu.Controls.Add(this.btnDashboard);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 600);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Silver;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 540);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(250, 60);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCash
            // 
            this.btnCash.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCash.FlatAppearance.BorderSize = 0;
            this.btnCash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnCash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.ForeColor = System.Drawing.Color.Silver;
            this.btnCash.Image = ((System.Drawing.Image)(resources.GetObject("btnCash.Image")));
            this.btnCash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCash.Location = new System.Drawing.Point(0, 385);
            this.btnCash.Name = "btnCash";
            this.btnCash.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCash.Size = new System.Drawing.Size(250, 60);
            this.btnCash.TabIndex = 8;
            this.btnCash.Text = "   Billing";
            this.btnCash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCash.UseVisualStyleBackColor = true;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.Silver;
            this.btnProducts.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.Image")));
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(0, 325);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(250, 60);
            this.btnProducts.TabIndex = 6;
            this.btnProducts.Text = "   Products";
            this.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnEmployees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.Color.Silver;
            this.btnEmployees.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployees.Image")));
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(0, 265);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(250, 60);
            this.btnEmployees.TabIndex = 5;
            this.btnEmployees.Text = "   Employees";
            this.btnEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.Silver;
            this.btnCustomers.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomers.Image")));
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(0, 205);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCustomers.Size = new System.Drawing.Size(250, 60);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.Text = "   Customers";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Silver;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 145);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(250, 60);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.lblUsername);
            this.panelLogo.Controls.Add(this.lblRole);
            this.panelLogo.Controls.Add(this.logo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 145);
            this.panelLogo.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblUsername.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Silver;
            this.lblUsername.Location = new System.Drawing.Point(28, 85);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(192, 17);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // lblRole
            // 
            this.lblRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblRole.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.Silver;
            this.lblRole.Location = new System.Drawing.Point(25, 111);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(195, 17);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRole.Click += new System.EventHandler(this.lblRole_Click);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(25, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(195, 60);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // panelChild
            // 
            this.panelChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(250, 0);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(979, 370);
            this.panelChild.TabIndex = 2;
            this.panelChild.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChild_Paint);
            // 
            // panelReport
            // 
            this.panelReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelReport.Controls.Add(this.btnTransaction);
            this.panelReport.Controls.Add(this.btnResetSales);
            this.panelReport.Controls.Add(this.lblDailySale);
            this.panelReport.Controls.Add(this.label3);
            this.panelReport.Controls.Add(this.label2);
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelReport.Location = new System.Drawing.Point(250, 370);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(979, 230);
            this.panelReport.TabIndex = 1;
            // 
            // btnTransaction
            // 
            this.btnTransaction.Animated = true;
            this.btnTransaction.BorderRadius = 5;
            this.btnTransaction.CheckedState.Parent = this.btnTransaction;
            this.btnTransaction.CustomImages.Parent = this.btnTransaction;
            this.btnTransaction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnTransaction.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.btnTransaction.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.Silver;
            this.btnTransaction.HoverState.Parent = this.btnTransaction;
            this.btnTransaction.Location = new System.Drawing.Point(729, 60);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.ShadowDecoration.Parent = this.btnTransaction;
            this.btnTransaction.Size = new System.Drawing.Size(187, 108);
            this.btnTransaction.TabIndex = 19;
            this.btnTransaction.Text = "Transaction History";
            this.btnTransaction.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // btnResetSales
            // 
            this.btnResetSales.Animated = true;
            this.btnResetSales.BorderRadius = 5;
            this.btnResetSales.CheckedState.Parent = this.btnResetSales;
            this.btnResetSales.CustomImages.Parent = this.btnResetSales;
            this.btnResetSales.Enabled = false;
            this.btnResetSales.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnResetSales.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.btnResetSales.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetSales.ForeColor = System.Drawing.Color.Silver;
            this.btnResetSales.HoverState.Parent = this.btnResetSales;
            this.btnResetSales.Location = new System.Drawing.Point(936, 217);
            this.btnResetSales.Name = "btnResetSales";
            this.btnResetSales.ShadowDecoration.Parent = this.btnResetSales;
            this.btnResetSales.Size = new System.Drawing.Size(10, 10);
            this.btnResetSales.TabIndex = 18;
            this.btnResetSales.Visible = false;
            this.btnResetSales.Click += new System.EventHandler(this.btnResetSales_Click);
            // 
            // lblDailySale
            // 
            this.lblDailySale.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailySale.ForeColor = System.Drawing.Color.Silver;
            this.lblDailySale.Location = new System.Drawing.Point(15, 117);
            this.lblDailySale.Name = "lblDailySale";
            this.lblDailySale.Size = new System.Drawing.Size(685, 104);
            this.lblDailySale.TabIndex = 0;
            this.lblDailySale.Text = "0.00";
            this.lblDailySale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDailySale.Click += new System.EventHandler(this.lblDailySale_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(121)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(22, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(528, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total sales recorded in the inventory";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(121)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 44);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sales Report";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panelChild;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1229, 600);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pet Haven";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.panelReport.ResumeLayout(false);
            this.panelReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnProducts;
        public System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelChild;
        public System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDailySale;
        public Guna.UI2.WinForms.Guna2GradientButton btnResetSales;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        public Guna.UI2.WinForms.Guna2GradientButton btnTransaction;
    }
}

