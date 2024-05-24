namespace Pet_Haven
{
    partial class CustomerCashForm
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.txtCustomerCash = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCustomerCash = new System.Windows.Forms.Label();
            this.btnOk = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.lblChange);
            this.guna2GradientPanel1.Controls.Add(this.lblCash);
            this.guna2GradientPanel1.Controls.Add(this.txtCustomerCash);
            this.guna2GradientPanel1.Controls.Add(this.lblCustomerCash);
            this.guna2GradientPanel1.Controls.Add(this.btnOk);
            this.guna2GradientPanel1.Controls.Add(this.btnCancel);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(513, 210);
            this.guna2GradientPanel1.TabIndex = 5;
            this.guna2GradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
            // 
            // lblChange
            // 
            this.lblChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblChange.Location = new System.Drawing.Point(158, 173);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(54, 25);
            this.lblChange.TabIndex = 46;
            this.lblChange.Text = "0.00";
            this.lblChange.Visible = false;
            this.lblChange.Click += new System.EventHandler(this.lblChange_Click);
            // 
            // lblCash
            // 
            this.lblCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblCash.Location = new System.Drawing.Point(158, 142);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(54, 25);
            this.lblCash.TabIndex = 45;
            this.lblCash.Text = "0.00";
            this.lblCash.Visible = false;
            this.lblCash.Click += new System.EventHandler(this.lblCash_Click);
            // 
            // txtCustomerCash
            // 
            this.txtCustomerCash.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerCash.DefaultText = "";
            this.txtCustomerCash.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerCash.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerCash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerCash.DisabledState.Parent = this.txtCustomerCash;
            this.txtCustomerCash.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerCash.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerCash.FocusedState.Parent = this.txtCustomerCash;
            this.txtCustomerCash.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerCash.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerCash.HoverState.Parent = this.txtCustomerCash;
            this.txtCustomerCash.Location = new System.Drawing.Point(163, 46);
            this.txtCustomerCash.Margin = new System.Windows.Forms.Padding(7);
            this.txtCustomerCash.Name = "txtCustomerCash";
            this.txtCustomerCash.PasswordChar = '\0';
            this.txtCustomerCash.PlaceholderText = "Amount";
            this.txtCustomerCash.SelectedText = "";
            this.txtCustomerCash.ShadowDecoration.Parent = this.txtCustomerCash;
            this.txtCustomerCash.Size = new System.Drawing.Size(340, 70);
            this.txtCustomerCash.TabIndex = 24;
            this.txtCustomerCash.TextChanged += new System.EventHandler(this.txtCustomerCash_TextChanged);
            // 
            // lblCustomerCash
            // 
            this.lblCustomerCash.AutoSize = true;
            this.lblCustomerCash.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerCash.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCash.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCustomerCash.Location = new System.Drawing.Point(12, 48);
            this.lblCustomerCash.Name = "lblCustomerCash";
            this.lblCustomerCash.Size = new System.Drawing.Size(156, 56);
            this.lblCustomerCash.TabIndex = 23;
            this.lblCustomerCash.Text = "Cash:";
            // 
            // btnOk
            // 
            this.btnOk.Animated = true;
            this.btnOk.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOk.BorderRadius = 5;
            this.btnOk.CheckedState.Parent = this.btnOk;
            this.btnOk.CustomImages.Parent = this.btnOk;
            this.btnOk.FillColor = System.Drawing.Color.White;
            this.btnOk.FillColor2 = System.Drawing.Color.White;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.HoverState.Parent = this.btnOk;
            this.btnOk.Location = new System.Drawing.Point(375, 160);
            this.btnOk.Name = "btnOk";
            this.btnOk.ShadowDecoration.Parent = this.btnOk;
            this.btnOk.Size = new System.Drawing.Size(128, 38);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.FillColor2 = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(128, 38);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.guna2GradientPanel1;
            // 
            // CustomerCashForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(513, 210);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerCashForm";
            this.Text = "CustomerCashForm";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerCash;
        private System.Windows.Forms.Label lblCustomerCash;
        public Guna.UI2.WinForms.Guna2GradientButton btnOk;
        public Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        public System.Windows.Forms.Label lblChange;
        public System.Windows.Forms.Label lblCash;
    }
}