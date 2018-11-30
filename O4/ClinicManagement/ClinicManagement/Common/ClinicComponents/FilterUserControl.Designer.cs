
namespace ClinicManagement.Common.ClinicComponents
{
    partial class FilterUserControl
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
            this.txtCMND = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtHoTen = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.txtMaBenh = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.SuspendLayout();
            // 
            // txtCMND
            // 
            this.txtCMND.AutoSize = true;
            this.txtCMND.BackColor = System.Drawing.Color.White;
            this.txtCMND.enableEdit = true;
            this.txtCMND.Icon = global::ClinicManagement.Properties.Resources.ico_cmnd;
            this.txtCMND.IsShowPassword = false;
            this.txtCMND.Location = new System.Drawing.Point(18, 123);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.PlaceHolder = "CMND/Passport";
            this.txtCMND.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtCMND.Radius = 5;
            this.txtCMND.Size = new System.Drawing.Size(404, 35);
            this.txtCMND.TabIndex = 2;
            this.txtCMND.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(331, 200);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.AutoSize = true;
            this.txtHoTen.BackColor = System.Drawing.Color.White;
            this.txtHoTen.enableEdit = true;
            this.txtHoTen.Icon = global::ClinicManagement.Properties.Resources.ico_cmnd;
            this.txtHoTen.IsShowPassword = false;
            this.txtHoTen.Location = new System.Drawing.Point(18, 73);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.PlaceHolder = "Tên bệnh nhân";
            this.txtHoTen.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtHoTen.Radius = 5;
            this.txtHoTen.Size = new System.Drawing.Size(404, 35);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtMaBenh
            // 
            this.txtMaBenh.AutoSize = true;
            this.txtMaBenh.BackColor = System.Drawing.Color.White;
            this.txtMaBenh.enableEdit = true;
            this.txtMaBenh.Icon = global::ClinicManagement.Properties.Resources.ico_card;
            this.txtMaBenh.IsShowPassword = false;
            this.txtMaBenh.Location = new System.Drawing.Point(18, 23);
            this.txtMaBenh.Name = "txtMaBenh";
            this.txtMaBenh.PlaceHolder = "Mã bệnh nhân";
            this.txtMaBenh.PlaceHolderColor = System.Drawing.Color.Silver;
            this.txtMaBenh.Radius = 5;
            this.txtMaBenh.Size = new System.Drawing.Size(404, 35);
            this.txtMaBenh.TabIndex = 0;
            this.txtMaBenh.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // FilterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMaBenh);
            this.MaximumSize = new System.Drawing.Size(440, 251);
            this.MinimumSize = new System.Drawing.Size(440, 251);
            this.Name = "FilterUserControl";
            this.Size = new System.Drawing.Size(440, 251);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ClinicManagement.Common.ClinicComponents.NewTextField txtMaBenh;
        private ClinicManagement.Common.ClinicComponents.NewTextField txtHoTen;
        private ClinicManagement.Common.ClinicComponents.NewTextField txtCMND;
        private System.Windows.Forms.Button btnSearch;
    }
}
