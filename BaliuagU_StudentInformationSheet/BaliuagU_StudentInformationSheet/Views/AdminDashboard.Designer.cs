namespace BaliuagU_StudentInformationSheet.Views
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.accountSettingsBtn = new System.Windows.Forms.Button();
            this.dashbordBtn = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.profileAdmin1 = new BaliuagU_StudentInformationSheet.Tools.ProfileAdmin();
            this.dashboard1 = new BaliuagU_StudentInformationSheet.Tools.Dashboard();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.Controls.Add(this.logoutBtn);
            this.panel2.Controls.Add(this.accountSettingsBtn);
            this.panel2.Controls.Add(this.dashbordBtn);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 540);
            this.panel2.TabIndex = 4;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.logoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.Black;
            this.logoutBtn.Location = new System.Drawing.Point(14, 483);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(185, 37);
            this.logoutBtn.TabIndex = 7;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // accountSettingsBtn
            // 
            this.accountSettingsBtn.FlatAppearance.BorderSize = 0;
            this.accountSettingsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.accountSettingsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.accountSettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountSettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountSettingsBtn.ForeColor = System.Drawing.Color.Black;
            this.accountSettingsBtn.Location = new System.Drawing.Point(0, 249);
            this.accountSettingsBtn.Name = "accountSettingsBtn";
            this.accountSettingsBtn.Size = new System.Drawing.Size(219, 50);
            this.accountSettingsBtn.TabIndex = 4;
            this.accountSettingsBtn.Text = "Account Settings";
            this.accountSettingsBtn.UseVisualStyleBackColor = true;
            this.accountSettingsBtn.Click += new System.EventHandler(this.accountSettingsBtn_Click);
            // 
            // dashbordBtn
            // 
            this.dashbordBtn.FlatAppearance.BorderSize = 0;
            this.dashbordBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.dashbordBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.dashbordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashbordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashbordBtn.ForeColor = System.Drawing.Color.Black;
            this.dashbordBtn.Location = new System.Drawing.Point(0, 193);
            this.dashbordBtn.Name = "dashbordBtn";
            this.dashbordBtn.Size = new System.Drawing.Size(219, 50);
            this.dashbordBtn.TabIndex = 3;
            this.dashbordBtn.Text = "Dashboard";
            this.dashbordBtn.UseVisualStyleBackColor = true;
            this.dashbordBtn.Click += new System.EventHandler(this.dashbordBtn_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(84, 152);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dashboard1);
            this.panel1.Controls.Add(this.profileAdmin1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 540);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // profileAdmin1
            // 
            this.profileAdmin1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("profileAdmin1.BackgroundImage")));
            this.profileAdmin1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profileAdmin1.Dock = System.Windows.Forms.DockStyle.Right;
            this.profileAdmin1.Location = new System.Drawing.Point(215, 0);
            this.profileAdmin1.Name = "profileAdmin1";
            this.profileAdmin1.Size = new System.Drawing.Size(717, 540);
            this.profileAdmin1.TabIndex = 0;
            // 
            // dashboard1
            // 
            this.dashboard1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dashboard1.Location = new System.Drawing.Point(-502, 0);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(717, 540);
            this.dashboard1.TabIndex = 1;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(932, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(948, 579);
            this.MinimumSize = new System.Drawing.Size(948, 579);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button accountSettingsBtn;
        private System.Windows.Forms.Button dashbordBtn;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Tools.ProfileAdmin profileAdmin1;
        private Tools.Dashboard dashboard1;
    }
}