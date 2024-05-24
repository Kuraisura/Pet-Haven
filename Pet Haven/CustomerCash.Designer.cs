namespace Pet_Haven
{
    partial class CustomerCash
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
            this.lblTransNo = new System.Windows.Forms.Label();
            this.txtCustomerCash = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblTransNo
            // 
            this.lblTransNo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransNo.Location = new System.Drawing.Point(11, 19);
            this.lblTransNo.Name = "lblTransNo";
            this.lblTransNo.Size = new System.Drawing.Size(107, 55);
            this.lblTransNo.TabIndex = 19;
            this.lblTransNo.Text = "Cash:";
            this.lblTransNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtCustomerCash.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerCash.HoverState.Parent = this.txtCustomerCash;
            this.txtCustomerCash.Location = new System.Drawing.Point(124, 19);
            this.txtCustomerCash.Name = "txtCustomerCash";
            this.txtCustomerCash.PasswordChar = '\0';
            this.txtCustomerCash.PlaceholderText = "";
            this.txtCustomerCash.SelectedText = "";
            this.txtCustomerCash.ShadowDecoration.Parent = this.txtCustomerCash;
            this.txtCustomerCash.Size = new System.Drawing.Size(229, 55);
            this.txtCustomerCash.TabIndex = 20;
            this.txtCustomerCash.TextChanged += new System.EventHandler(this.txtCustomerCash_TextChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.CheckedState.Parent = this.btnConfirm;
            this.btnConfirm.CustomImages.Parent = this.btnConfirm;
            this.btnConfirm.FillColor = System.Drawing.Color.Black;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.HoverState.Parent = this.btnConfirm;
            this.btnConfirm.Location = new System.Drawing.Point(146, 97);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(180, 45);
            this.btnConfirm.TabIndex = 21;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // CustomerCash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(365, 154);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtCustomerCash);
            this.Controls.Add(this.lblTransNo);
            this.Name = "CustomerCash";
            this.Text = "CustomerCash";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblTransNo;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerCash;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
    }
}