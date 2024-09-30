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
            System.Windows.Forms.Button loginButton;
            System.Windows.Forms.Button minimizeBut;
            System.Windows.Forms.Button exitBut;
            this.usernameTb = new System.Windows.Forms.TextBox();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.EchoPassword = new System.Windows.Forms.PictureBox();
            this.eyesclosedicon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            loginButton = new System.Windows.Forms.Button();
            minimizeBut = new System.Windows.Forms.Button();
            exitBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EchoPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesclosedicon)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            loginButton.BackColor = System.Drawing.Color.Plum;
            loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            loginButton.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            loginButton.ForeColor = System.Drawing.Color.Indigo;
            loginButton.Location = new System.Drawing.Point(422, 657);
            loginButton.Margin = new System.Windows.Forms.Padding(0);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(170, 40);
            loginButton.TabIndex = 4;
            loginButton.Text = "Log In";
            loginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // minimizeBut
            // 
            minimizeBut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            minimizeBut.BackColor = System.Drawing.Color.Transparent;
            minimizeBut.BackgroundImage = global::StudentInformationSheet.Properties.Resources.No_Entry_Transparent_Background;
            minimizeBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            minimizeBut.Cursor = System.Windows.Forms.Cursors.Hand;
            minimizeBut.FlatAppearance.BorderSize = 0;
            minimizeBut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            minimizeBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            minimizeBut.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            minimizeBut.ForeColor = System.Drawing.Color.Indigo;
            minimizeBut.Location = new System.Drawing.Point(1334, 30);
            minimizeBut.Margin = new System.Windows.Forms.Padding(0);
            minimizeBut.Name = "minimizeBut";
            minimizeBut.Size = new System.Drawing.Size(32, 19);
            minimizeBut.TabIndex = 7;
            minimizeBut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            minimizeBut.UseVisualStyleBackColor = false;
            // 
            // exitBut
            // 
            exitBut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            exitBut.BackColor = System.Drawing.Color.Transparent;
            exitBut.BackgroundImage = global::StudentInformationSheet.Properties.Resources.Xicon_removebg_preview;
            exitBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            exitBut.Cursor = System.Windows.Forms.Cursors.Hand;
            exitBut.FlatAppearance.BorderSize = 0;
            exitBut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            exitBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            exitBut.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exitBut.ForeColor = System.Drawing.Color.Indigo;
            exitBut.Location = new System.Drawing.Point(1421, 30);
            exitBut.Margin = new System.Windows.Forms.Padding(0);
            exitBut.Name = "exitBut";
            exitBut.Size = new System.Drawing.Size(32, 19);
            exitBut.TabIndex = 8;
            exitBut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            exitBut.UseVisualStyleBackColor = false;
            // 
            // usernameTb
            // 
            this.usernameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTb.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTb.ForeColor = System.Drawing.Color.Fuchsia;
            this.usernameTb.Location = new System.Drawing.Point(370, 422);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(277, 30);
            this.usernameTb.TabIndex = 2;
            // 
            // passwordTb
            // 
            this.passwordTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTb.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTb.ForeColor = System.Drawing.Color.Fuchsia;
            this.passwordTb.Location = new System.Drawing.Point(370, 550);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(251, 30);
            this.passwordTb.TabIndex = 3;
            this.passwordTb.TextChanged += new System.EventHandler(this.passwordTb_TextChanged);
            // 
            // EchoPassword
            // 
            this.EchoPassword.BackColor = System.Drawing.Color.Transparent;
            this.EchoPassword.BackgroundImage = global::StudentInformationSheet.Properties.Resources.eyeicon;
            this.EchoPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EchoPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EchoPassword.Location = new System.Drawing.Point(638, 539);
            this.EchoPassword.Name = "EchoPassword";
            this.EchoPassword.Size = new System.Drawing.Size(41, 41);
            this.EchoPassword.TabIndex = 5;
            this.EchoPassword.TabStop = false;
            this.EchoPassword.Visible = false;
            this.EchoPassword.Click += new System.EventHandler(this.EchoPassword_Click);
            // 
            // eyesclosedicon
            // 
            this.eyesclosedicon.BackColor = System.Drawing.Color.Transparent;
            this.eyesclosedicon.BackgroundImage = global::StudentInformationSheet.Properties.Resources.eyeclosedicon;
            this.eyesclosedicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eyesclosedicon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyesclosedicon.Location = new System.Drawing.Point(638, 539);
            this.eyesclosedicon.Name = "eyesclosedicon";
            this.eyesclosedicon.Size = new System.Drawing.Size(41, 41);
            this.eyesclosedicon.TabIndex = 6;
            this.eyesclosedicon.TabStop = false;
            this.eyesclosedicon.Click += new System.EventHandler(this.eyesclosedicon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StudentInformationSheet.Properties.Resources.LoginBackFinal;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.label1);
            this.Controls.Add(exitBut);
            this.Controls.Add(minimizeBut);
            this.Controls.Add(this.eyesclosedicon);
            this.Controls.Add(this.EchoPassword);
            this.Controls.Add(loginButton);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.usernameTb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.EchoPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesclosedicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTb;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.PictureBox EchoPassword;
        private System.Windows.Forms.PictureBox eyesclosedicon;
        private System.Windows.Forms.Label label1;
    }
}

