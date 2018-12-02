namespace ClinicManagement.Features.Login.SubForms
{
    partial class LoginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new ClinicManagement.Common.ClinicComponents.NewButton(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.userNameTextField = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.passwordTextField = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhập thông tin để truy cập";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(33, 266);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Radius = 10;
            this.btnLogin.Size = new System.Drawing.Size(108, 47);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.3493F));
            this.tableLayoutPanel1.Controls.Add(this.userNameTextField, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.passwordTextField, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 137);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(501, 73);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // userNameTextField
            // 
            this.userNameTextField.AutoSize = true;
            this.userNameTextField.BackColor = System.Drawing.Color.White;
            this.userNameTextField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userNameTextField.enableEdit = true;
            this.userNameTextField.Icon = global::ClinicManagement.Properties.Resources.ico_user;
            this.userNameTextField.IsShowPassword = false;
            this.userNameTextField.Location = new System.Drawing.Point(3, 3);
            this.userNameTextField.Name = "userNameTextField";
            this.userNameTextField.PlaceHolder = "Place Holder";
            this.userNameTextField.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.userNameTextField.Radius = 5;
            this.userNameTextField.Size = new System.Drawing.Size(495, 30);
            this.userNameTextField.TabIndex = 0;
            this.userNameTextField.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // passwordTextField
            // 
            this.passwordTextField.AutoSize = true;
            this.passwordTextField.BackColor = System.Drawing.Color.White;
            this.passwordTextField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordTextField.enableEdit = true;
            this.passwordTextField.Icon = global::ClinicManagement.Properties.Resources.ico_key_24;
            this.passwordTextField.IsShowPassword = true;
            this.passwordTextField.Location = new System.Drawing.Point(3, 39);
            this.passwordTextField.Name = "passwordTextField";
            this.passwordTextField.PlaceHolder = "Place Holder";
            this.passwordTextField.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.passwordTextField.Radius = 5;
            this.passwordTextField.Size = new System.Drawing.Size(495, 31);
            this.passwordTextField.TabIndex = 1;
            this.passwordTextField.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(460, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 76);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(562, 347);
            this.MinimumSize = new System.Drawing.Size(562, 347);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(562, 347);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ClinicManagement.Common.ClinicComponents.NewButton btnLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClinicManagement.Common.ClinicComponents.NewTextField userNameTextField;
        private ClinicManagement.Common.ClinicComponents.NewTextField passwordTextField;
    }
}
