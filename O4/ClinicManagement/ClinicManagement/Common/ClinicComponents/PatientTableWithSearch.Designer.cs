namespace ClinicManagement.Common.ClinicComponents
{
    partial class PatientTableWithSearch
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
            this.txtHoTen = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.txtMaBenhNhan = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.txtCMND = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.table = new ClinicManagement.Common.ClinicComponents.PatientTable();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHoTen
            // 
            this.txtHoTen.AutoSize = true;
            this.txtHoTen.BackColor = System.Drawing.Color.White;
            this.txtHoTen.enableEdit = true;
            this.txtHoTen.Icon = global::ClinicManagement.Properties.Resources.ico_card;
            this.txtHoTen.IsShowPassword = false;
            this.txtHoTen.Location = new System.Drawing.Point(0, 42);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.PlaceHolder = "Họ tên";
            this.txtHoTen.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtHoTen.Radius = 3;
            this.txtHoTen.Size = new System.Drawing.Size(278, 35);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtMaBenhNhan
            // 
            this.txtMaBenhNhan.AutoSize = true;
            this.txtMaBenhNhan.BackColor = System.Drawing.Color.White;
            this.txtMaBenhNhan.enableEdit = true;
            this.txtMaBenhNhan.Icon = global::ClinicManagement.Properties.Resources.ico_card;
            this.txtMaBenhNhan.IsShowPassword = false;
            this.txtMaBenhNhan.Location = new System.Drawing.Point(0, 1);
            this.txtMaBenhNhan.Name = "txtMaBenhNhan";
            this.txtMaBenhNhan.PlaceHolder = "Mã bệnh nhân";
            this.txtMaBenhNhan.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtMaBenhNhan.Radius = 3;
            this.txtMaBenhNhan.Size = new System.Drawing.Size(278, 35);
            this.txtMaBenhNhan.TabIndex = 2;
            this.txtMaBenhNhan.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtCMND
            // 
            this.txtCMND.AutoSize = true;
            this.txtCMND.BackColor = System.Drawing.Color.White;
            this.txtCMND.enableEdit = true;
            this.txtCMND.Icon = global::ClinicManagement.Properties.Resources.ico_card;
            this.txtCMND.IsShowPassword = false;
            this.txtCMND.Location = new System.Drawing.Point(284, 1);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.PlaceHolder = "CMND";
            this.txtCMND.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtCMND.Radius = 3;
            this.txtCMND.Size = new System.Drawing.Size(278, 35);
            this.txtCMND.TabIndex = 3;
            this.txtCMND.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(284, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(278, 35);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.table);
            this.panel1.Controls.Add(this.txtCMND);
            this.panel1.Controls.Add(this.txtMaBenhNhan);
            this.panel1.Location = new System.Drawing.Point(12, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 562);
            this.panel1.TabIndex = 5;
            // 
            // table
            // 
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table.Columns = new ClinicManagement.Common.ClinicComponents.ColumnTypes[] {
        ClinicManagement.Common.ClinicComponents.ColumnTypes.HoTen,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.CMND,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.NgaySinh,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.GioiTinh,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.SoDienThoai,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.DiaChi};
            this.table.Location = new System.Drawing.Point(0, 83);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(806, 479);
            this.table.TabIndex = 0;
            // 
            // PatientTableWithSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PatientTableWithSearch";
            this.Size = new System.Drawing.Size(835, 596);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PatientTable table;
        private ClinicManagement.Common.ClinicComponents.NewTextField txtHoTen;
        private ClinicManagement.Common.ClinicComponents.NewTextField txtMaBenhNhan;
        private ClinicManagement.Common.ClinicComponents.NewTextField txtCMND;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}
