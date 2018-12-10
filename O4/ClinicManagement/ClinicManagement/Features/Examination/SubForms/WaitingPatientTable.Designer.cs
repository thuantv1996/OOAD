namespace ClinicManagement.Features.Examination.SubForms
{
    partial class WaitingPatientTable
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccess = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaHoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaBenhNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Sdt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Image = global::ClinicManagement.Properties.Resources.ico_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(3, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 45);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAccess);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 74);
            this.panel1.TabIndex = 3;
            // 
            // btnAccess
            // 
            this.btnAccess.BackColor = System.Drawing.Color.White;
            this.btnAccess.Image = global::ClinicManagement.Properties.Resources.ico_edit;
            this.btnAccess.Location = new System.Drawing.Point(54, 23);
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.Size = new System.Drawing.Size(45, 45);
            this.btnAccess.TabIndex = 3;
            this.btnAccess.UseVisualStyleBackColor = false;
            this.btnAccess.Click += new System.EventHandler(this.btnAccess_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 74);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(963, 379);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_STT,
            this.col_MaHoSo,
            this.col_MaBenhNhan,
            this.col_HoTen,
            this.col_CMND,
            this.col_Sdt});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.FindFilterColumns = "MaBenhNhan";
            this.gridView1.OptionsFind.FindNullPrompt = "Nhập để tìm kiếm";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // col_STT
            // 
            this.col_STT.Caption = "STT";
            this.col_STT.FieldName = "SoThuTu";
            this.col_STT.Name = "col_STT";
            this.col_STT.Visible = true;
            this.col_STT.VisibleIndex = 0;
            this.col_STT.Width = 98;
            // 
            // col_MaHoSo
            // 
            this.col_MaHoSo.Caption = "Mã Hồ Sơ";
            this.col_MaHoSo.FieldName = "MaHoSo";
            this.col_MaHoSo.Name = "col_MaHoSo";
            // 
            // col_MaBenhNhan
            // 
            this.col_MaBenhNhan.Caption = "Mã Bệnh Nhân";
            this.col_MaBenhNhan.FieldName = "MaBenhNhan";
            this.col_MaBenhNhan.Name = "col_MaBenhNhan";
            this.col_MaBenhNhan.Visible = true;
            this.col_MaBenhNhan.VisibleIndex = 1;
            this.col_MaBenhNhan.Width = 185;
            // 
            // col_HoTen
            // 
            this.col_HoTen.Caption = "Họ Tên";
            this.col_HoTen.FieldName = "HoTen";
            this.col_HoTen.Name = "col_HoTen";
            this.col_HoTen.Visible = true;
            this.col_HoTen.VisibleIndex = 2;
            this.col_HoTen.Width = 185;
            // 
            // col_CMND
            // 
            this.col_CMND.Caption = "CMND";
            this.col_CMND.FieldName = "CMND";
            this.col_CMND.Name = "col_CMND";
            this.col_CMND.Visible = true;
            this.col_CMND.VisibleIndex = 3;
            this.col_CMND.Width = 185;
            // 
            // col_Sdt
            // 
            this.col_Sdt.Caption = "Số điện thoại";
            this.col_Sdt.FieldName = "SoDienThoai";
            this.col_Sdt.Name = "col_Sdt";
            this.col_Sdt.Visible = true;
            this.col_Sdt.VisibleIndex = 4;
            this.col_Sdt.Width = 196;
            // 
            // WaitingPatientTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "WaitingPatientTable";
            this.Size = new System.Drawing.Size(963, 453);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_STT;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaBenhNhan;
        private DevExpress.XtraGrid.Columns.GridColumn col_HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn col_CMND;
        private DevExpress.XtraGrid.Columns.GridColumn col_Sdt;
        private System.Windows.Forms.Button btnAccess;
    }
}
