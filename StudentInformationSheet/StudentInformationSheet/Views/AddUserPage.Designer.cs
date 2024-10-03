namespace StudentInformationSheet
{
    partial class AddUserPage
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
            System.Windows.Forms.Button homeBtn;
            System.Windows.Forms.Button registerBtn;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UserType = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.eyesclosedicon = new System.Windows.Forms.PictureBox();
            this.EchoPassword = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            homeBtn = new System.Windows.Forms.Button();
            registerBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesclosedicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EchoPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // homeBtn
            // 
            homeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            homeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            homeBtn.BackgroundImage = global::StudentInformationSheet.Properties.Resources.framebgfinal;
            homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            homeBtn.FlatAppearance.BorderSize = 0;
            homeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            homeBtn.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            homeBtn.ForeColor = System.Drawing.Color.Indigo;
            homeBtn.Location = new System.Drawing.Point(549, 664);
            homeBtn.Margin = new System.Windows.Forms.Padding(0);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new System.Drawing.Size(187, 42);
            homeBtn.TabIndex = 53;
            homeBtn.Text = "HOME";
            homeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            homeBtn.UseVisualStyleBackColor = false;
            homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // registerBtn
            // 
            registerBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            registerBtn.BackColor = System.Drawing.Color.Plum;
            registerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            registerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            registerBtn.FlatAppearance.BorderSize = 0;
            registerBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            registerBtn.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            registerBtn.ForeColor = System.Drawing.Color.Indigo;
            registerBtn.Location = new System.Drawing.Point(237, 519);
            registerBtn.Margin = new System.Windows.Forms.Padding(0);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new System.Drawing.Size(130, 49);
            registerBtn.TabIndex = 4;
            registerBtn.Text = "Register";
            registerBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            registerBtn.UseVisualStyleBackColor = false;
            registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = global::StudentInformationSheet.Properties.Resources.framebgfinal;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.UserType);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(registerBtn);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.eyesclosedicon);
            this.groupBox1.Controls.Add(this.EchoPassword);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(92, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 629);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // UserType
            // 
            this.UserType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserType.BackColor = System.Drawing.Color.White;
            this.UserType.DisplayMember = "Male, Female";
            this.UserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserType.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserType.FormattingEnabled = true;
            this.UserType.Items.AddRange(new object[] {
            "User",
            "Administrator"});
            this.UserType.Location = new System.Drawing.Point(94, 165);
            this.UserType.Name = "UserType";
            this.UserType.Size = new System.Drawing.Size(417, 38);
            this.UserType.TabIndex = 48;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox4.Image = global::StudentInformationSheet.Properties.Resources.linephoto;
            this.pictureBox4.Location = new System.Drawing.Point(94, 209);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(417, 10);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(89, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 30);
            this.label4.TabIndex = 14;
            this.label4.Text = "User Type";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::StudentInformationSheet.Properties.Resources.linephoto;
            this.pictureBox3.Location = new System.Drawing.Point(94, 465);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(417, 10);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.Image = global::StudentInformationSheet.Properties.Resources.linephoto;
            this.pictureBox2.Location = new System.Drawing.Point(94, 335);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(417, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // eyesclosedicon
            // 
            this.eyesclosedicon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eyesclosedicon.BackColor = System.Drawing.Color.Transparent;
            this.eyesclosedicon.BackgroundImage = global::StudentInformationSheet.Properties.Resources.eyeclosedicon;
            this.eyesclosedicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eyesclosedicon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyesclosedicon.Location = new System.Drawing.Point(470, 418);
            this.eyesclosedicon.Name = "eyesclosedicon";
            this.eyesclosedicon.Size = new System.Drawing.Size(37, 37);
            this.eyesclosedicon.TabIndex = 6;
            this.eyesclosedicon.TabStop = false;
            this.eyesclosedicon.Click += new System.EventHandler(this.eyesclosedicon_Click);
            // 
            // EchoPassword
            // 
            this.EchoPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EchoPassword.BackColor = System.Drawing.Color.Transparent;
            this.EchoPassword.BackgroundImage = global::StudentInformationSheet.Properties.Resources.eyeicon;
            this.EchoPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EchoPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EchoPassword.Location = new System.Drawing.Point(470, 418);
            this.EchoPassword.Name = "EchoPassword";
            this.EchoPassword.Size = new System.Drawing.Size(37, 37);
            this.EchoPassword.TabIndex = 5;
            this.EchoPassword.TabStop = false;
            this.EchoPassword.Visible = false;
            this.EchoPassword.Click += new System.EventHandler(this.EchoPassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = global::StudentInformationSheet.Properties.Resources.loginPhotodesign;
            this.pictureBox1.Location = new System.Drawing.Point(580, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(467, 610);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(89, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(89, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label1.Location = new System.Drawing.Point(226, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sign Up";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Fuchsia;
            this.txtPassword.Location = new System.Drawing.Point(94, 419);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(370, 36);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Fuchsia;
            this.txtUsername.Location = new System.Drawing.Point(94, 290);
            this.txtUsername.MaxLength = 25;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(417, 36);
            this.txtUsername.TabIndex = 2;
            // 
            // AddUserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StudentInformationSheet.Properties.Resources.BackgroundForAll;
            this.ClientSize = new System.Drawing.Size(1255, 721);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(homeBtn);
            this.MinimumSize = new System.Drawing.Size(1271, 726);
            this.Name = "AddUserPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUserPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesclosedicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EchoPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox eyesclosedicon;
        private System.Windows.Forms.PictureBox EchoPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox UserType;
    }
}