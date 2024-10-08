namespace BaliuagU_StudentInformationSheet.Views
{
    partial class SuperAdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dashboard1 = new BaliuagU_StudentInformationSheet.Tools.Dashboard();
            this.manageUsers1 = new BaliuagU_StudentInformationSheet.Tools.ManageUsers();
            this.profileSuperAdmin1 = new BaliuagU_StudentInformationSheet.Tools.ProfileSuperAdmin();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.accountSettingsBtn = new System.Windows.Forms.Button();
            this.manageUsersBtn = new System.Windows.Forms.Button();
            this.dashboardBtn = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dashboard1);
            this.panel1.Controls.Add(this.manageUsers1);
            this.panel1.Controls.Add(this.profileSuperAdmin1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 540);
            this.panel1.TabIndex = 1;
            // 
            // dashboard1
            // 
            this.dashboard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dashboard1.BackgroundImage")));
            this.dashboard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboard1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dashboard1.Location = new System.Drawing.Point(-1229, 0);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(717, 540);
            this.dashboard1.TabIndex = 2;
            // 
            // manageUsers1
            // 
            this.manageUsers1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("manageUsers1.BackgroundImage")));
            this.manageUsers1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.manageUsers1.Dock = System.Windows.Forms.DockStyle.Right;
            this.manageUsers1.Location = new System.Drawing.Point(-512, 0);
            this.manageUsers1.Name = "manageUsers1";
            this.manageUsers1.Size = new System.Drawing.Size(717, 540);
            this.manageUsers1.TabIndex = 1;
            // 
            // profileSuperAdmin1
            // 
            this.profileSuperAdmin1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("profileSuperAdmin1.BackgroundImage")));
            this.profileSuperAdmin1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profileSuperAdmin1.Dock = System.Windows.Forms.DockStyle.Right;
            this.profileSuperAdmin1.Location = new System.Drawing.Point(205, 0);
            this.profileSuperAdmin1.Name = "profileSuperAdmin1";
            this.profileSuperAdmin1.Size = new System.Drawing.Size(727, 540);
            this.profileSuperAdmin1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(26)))), ((int)(((byte)(87)))));
            this.panel2.Controls.Add(this.logoutBtn);
            this.panel2.Controls.Add(this.accountSettingsBtn);
            this.panel2.Controls.Add(this.manageUsersBtn);
            this.panel2.Controls.Add(this.dashboardBtn);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 540);
            this.panel2.TabIndex = 2;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(101)))), ((int)(((byte)(170)))));
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(88)))), ((int)(((byte)(137)))));
            this.logoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(101)))), ((int)(((byte)(170)))));
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
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
            this.accountSettingsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(88)))), ((int)(((byte)(137)))));
            this.accountSettingsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(101)))), ((int)(((byte)(170)))));
            this.accountSettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountSettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountSettingsBtn.ForeColor = System.Drawing.Color.White;
            this.accountSettingsBtn.Location = new System.Drawing.Point(0, 305);
            this.accountSettingsBtn.Name = "accountSettingsBtn";
            this.accountSettingsBtn.Size = new System.Drawing.Size(213, 50);
            this.accountSettingsBtn.TabIndex = 5;
            this.accountSettingsBtn.Text = "Account Settings";
            this.accountSettingsBtn.UseVisualStyleBackColor = true;
            this.accountSettingsBtn.Click += new System.EventHandler(this.accountSettingsBtn_Click);
            // 
            // manageUsersBtn
            // 
            this.manageUsersBtn.FlatAppearance.BorderSize = 0;
            this.manageUsersBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(88)))), ((int)(((byte)(137)))));
            this.manageUsersBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(101)))), ((int)(((byte)(170)))));
            this.manageUsersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageUsersBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageUsersBtn.ForeColor = System.Drawing.Color.White;
            this.manageUsersBtn.Location = new System.Drawing.Point(0, 249);
            this.manageUsersBtn.Name = "manageUsersBtn";
            this.manageUsersBtn.Size = new System.Drawing.Size(213, 50);
            this.manageUsersBtn.TabIndex = 4;
            this.manageUsersBtn.Text = "Manage Users";
            this.manageUsersBtn.Click += new System.EventHandler(this.manageUsersBtn_Click);
            // 
            // dashboardBtn
            // 
            this.dashboardBtn.FlatAppearance.BorderSize = 0;
            this.dashboardBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(88)))), ((int)(((byte)(137)))));
            this.dashboardBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(101)))), ((int)(((byte)(170)))));
            this.dashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardBtn.ForeColor = System.Drawing.Color.White;
            this.dashboardBtn.Location = new System.Drawing.Point(0, 193);
            this.dashboardBtn.Name = "dashboardBtn";
            this.dashboardBtn.Size = new System.Drawing.Size(213, 50);
            this.dashboardBtn.TabIndex = 3;
            this.dashboardBtn.Text = "Dashboard";
            this.dashboardBtn.UseVisualStyleBackColor = true;
            this.dashboardBtn.Click += new System.EventHandler(this.dashboardBtn_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(84, 143);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BaliuagU_StudentInformationSheet.Properties.Resources.admin_img;
            this.pictureBox1.Location = new System.Drawing.Point(56, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SuperAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(932, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(948, 579);
            this.MinimumSize = new System.Drawing.Size(948, 579);
            this.Name = "SuperAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperAdminDashboard";
            this.Load += new System.EventHandler(this.SuperAdminDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dashboardBtn;
        private System.Windows.Forms.Button accountSettingsBtn;
        private System.Windows.Forms.Button manageUsersBtn;
        private System.Windows.Forms.Button logoutBtn;
        private Tools.Dashboard dashboard1;
        private Tools.ManageUsers manageUsers1;
        private Tools.ProfileSuperAdmin profileSuperAdmin1;
    }
}