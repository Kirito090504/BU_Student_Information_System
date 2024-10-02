namespace StudentInformationSheet
{
    partial class LoginPage
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
            System.Windows.Forms.Button loginBtn;
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.EchoPassword = new System.Windows.Forms.PictureBox();
            this.eyesclosedicon = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            loginBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EchoPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesclosedicon)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            loginBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            loginBtn.BackColor = System.Drawing.Color.Plum;
            loginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            loginBtn.FlatAppearance.BorderSize = 0;
            loginBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            loginBtn.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            loginBtn.ForeColor = System.Drawing.Color.Indigo;
            loginBtn.Location = new System.Drawing.Point(241, 485);
            loginBtn.Margin = new System.Windows.Forms.Padding(0);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new System.Drawing.Size(130, 49);
            loginBtn.TabIndex = 4;
            loginBtn.Text = "Log In";
            loginBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Fuchsia;
            this.txtUsername.Location = new System.Drawing.Point(94, 237);
            this.txtUsername.MaxLength = 25;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(417, 36);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Fuchsia;
            this.txtPassword.Location = new System.Drawing.Point(94, 366);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(370, 36);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // EchoPassword
            // 
            this.EchoPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EchoPassword.BackColor = System.Drawing.Color.Transparent;
            this.EchoPassword.BackgroundImage = global::StudentInformationSheet.Properties.Resources.eyeicon;
            this.EchoPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EchoPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EchoPassword.Location = new System.Drawing.Point(470, 365);
            this.EchoPassword.Name = "EchoPassword";
            this.EchoPassword.Size = new System.Drawing.Size(37, 37);
            this.EchoPassword.TabIndex = 5;
            this.EchoPassword.TabStop = false;
            this.EchoPassword.Visible = false;
            this.EchoPassword.Click += new System.EventHandler(this.EchoPassword_Click);
            // 
            // eyesclosedicon
            // 
            this.eyesclosedicon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eyesclosedicon.BackColor = System.Drawing.Color.Transparent;
            this.eyesclosedicon.BackgroundImage = global::StudentInformationSheet.Properties.Resources.eyeclosedicon;
            this.eyesclosedicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eyesclosedicon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyesclosedicon.Location = new System.Drawing.Point(470, 365);
            this.eyesclosedicon.Name = "eyesclosedicon";
            this.eyesclosedicon.Size = new System.Drawing.Size(37, 37);
            this.eyesclosedicon.TabIndex = 6;
            this.eyesclosedicon.TabStop = false;
            this.eyesclosedicon.Click += new System.EventHandler(this.eyesclosedicon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = global::StudentInformationSheet.Properties.Resources.framebgfinal;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(loginBtn);
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
            this.groupBox1.Location = new System.Drawing.Point(89, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 629);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::StudentInformationSheet.Properties.Resources.linephoto;
            this.pictureBox3.Location = new System.Drawing.Point(94, 412);
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
            this.pictureBox2.Location = new System.Drawing.Point(94, 282);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(417, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
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
            this.label3.Location = new System.Drawing.Point(89, 328);
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
            this.label2.Location = new System.Drawing.Point(89, 200);
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
            this.label1.Location = new System.Drawing.Point(253, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log In";
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StudentInformationSheet.Properties.Resources.BackgroundForAll;
            this.ClientSize = new System.Drawing.Size(1255, 721);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(1271, 726);
            this.Name = "LoginPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.EchoPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesclosedicon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox EchoPassword;
        private System.Windows.Forms.PictureBox eyesclosedicon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

