namespace ClinicManagement.Features.Reception.SubForms
{
    partial class PreviousRecordsTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviousRecordsTable));
            this.grd_Table = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaHoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LoaiHoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NguoiTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NgayTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtMaHoSo = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNguoiTiepNhan = new ClinicManagement.Common.ClinicComponents.NewTextField();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtLoaiHoSo = new ClinicManagement.Common.ClinicComponents.NewTextField();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grd_Table
            // 
            this.grd_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_Table.Location = new System.Drawing.Point(0, 85);
            this.grd_Table.MainView = this.gridView1;
            this.grd_Table.Name = "grd_Table";
            this.grd_Table.Size = new System.Drawing.Size(703, 406);
            this.grd_Table.TabIndex = 0;
            this.grd_Table.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaHoSo,
            this.col_LoaiHoSo,
            this.col_NguoiTiepNhan,
            this.col_NgayTiepNhan});
            this.gridView1.GridControl = this.grd_Table;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // col_MaHoSo
            // 
            this.col_MaHoSo.Caption = "Mã hồ sơ";
            this.col_MaHoSo.FieldName = "MaHoSo";
            this.col_MaHoSo.Name = "col_MaHoSo";
            this.col_MaHoSo.Visible = true;
            this.col_MaHoSo.VisibleIndex = 0;
            // 
            // col_LoaiHoSo
            // 
            this.col_LoaiHoSo.Caption = "Loại hồ sơ";
            this.col_LoaiHoSo.FieldName = "LoaiHoSo";
            this.col_LoaiHoSo.Name = "col_LoaiHoSo";
            this.col_LoaiHoSo.Visible = true;
            this.col_LoaiHoSo.VisibleIndex = 1;
            // 
            // col_NguoiTiepNhan
            // 
            this.col_NguoiTiepNhan.Caption = "Người tiếp nhận";
            this.col_NguoiTiepNhan.FieldName = "NguoiTiepNhan";
            this.col_NguoiTiepNhan.Name = "col_NguoiTiepNhan";
            this.col_NguoiTiepNhan.Visible = true;
            this.col_NguoiTiepNhan.VisibleIndex = 2;
            // 
            // col_NgayTiepNhan
            // 
            this.col_NgayTiepNhan.Caption = "Ngày tiếp nhận";
            this.col_NgayTiepNhan.FieldName = "NgayTiepNhan";
            this.col_NgayTiepNhan.Name = "col_NgayTiepNhan";
            this.col_NgayTiepNhan.Visible = true;
            this.col_NgayTiepNhan.VisibleIndex = 3;
            // 
            // txtMaHoSo
            // 
            this.txtMaHoSo.AutoSize = true;
            this.txtMaHoSo.BackColor = System.Drawing.Color.White;
            this.txtMaHoSo.enableEdit = true;
            this.txtMaHoSo.Icon = ((System.Drawing.Image)(resources.GetObject("txtMaHoSo.Icon")));
            this.txtMaHoSo.IsShowPassword = false;
            this.txtMaHoSo.Location = new System.Drawing.Point(3, 3);
            this.txtMaHoSo.Name = "txtMaHoSo";
            this.txtMaHoSo.PlaceHolder = "Mã hồ sơ";
            this.txtMaHoSo.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtMaHoSo.Radius = 1;
            this.txtMaHoSo.Size = new System.Drawing.Size(278, 35);
            this.txtMaHoSo.TabIndex = 1;
            this.txtMaHoSo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNguoiTiepNhan);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtLoaiHoSo);
            this.panel1.Controls.Add(this.grd_Table);
            this.panel1.Controls.Add(this.txtMaHoSo);
            this.panel1.Location = new System.Drawing.Point(13, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 491);
            this.panel1.TabIndex = 2;
            // 
            // txtNguoiTiepNhan
            // 
            this.txtNguoiTiepNhan.AutoSize = true;
            this.txtNguoiTiepNhan.BackColor = System.Drawing.Color.White;
            this.txtNguoiTiepNhan.enableEdit = true;
            this.txtNguoiTiepNhan.Icon = ((System.Drawing.Image)(resources.GetObject("txtNguoiTiepNhan.Icon")));
            this.txtNguoiTiepNhan.IsShowPassword = false;
            this.txtNguoiTiepNhan.Location = new System.Drawing.Point(287, 3);
            this.txtNguoiTiepNhan.Name = "txtNguoiTiepNhan";
            this.txtNguoiTiepNhan.PlaceHolder = "Người tiếp nhận";
            this.txtNguoiTiepNhan.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtNguoiTiepNhan.Radius = 1;
            this.txtNguoiTiepNhan.Size = new System.Drawing.Size(278, 35);
            this.txtNguoiTiepNhan.TabIndex = 4;
            this.txtNguoiTiepNhan.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(287, 44);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(278, 35);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtLoaiHoSo
            // 
            this.txtLoaiHoSo.AutoSize = true;
            this.txtLoaiHoSo.BackColor = System.Drawing.Color.White;
            this.txtLoaiHoSo.enableEdit = true;
            this.txtLoaiHoSo.Icon = ((System.Drawing.Image)(resources.GetObject("txtLoaiHoSo.Icon")));
            this.txtLoaiHoSo.IsShowPassword = false;
            this.txtLoaiHoSo.Location = new System.Drawing.Point(3, 44);
            this.txtLoaiHoSo.Name = "txtLoaiHoSo";
            this.txtLoaiHoSo.PlaceHolder = "Loại hồ sơ";
            this.txtLoaiHoSo.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtLoaiHoSo.Radius = 1;
            this.txtLoaiHoSo.Size = new System.Drawing.Size(278, 35);
            this.txtLoaiHoSo.TabIndex = 2;
            this.txtLoaiHoSo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // PreviousRecordsTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PreviousRecordsTable";
            this.Size = new System.Drawing.Size(731, 523);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd_Table;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Common.ClinicComponents.NewTextField txtMaHoSo;
        private System.Windows.Forms.Panel panel1;
        private Common.ClinicComponents.NewTextField txtLoaiHoSo;
        private System.Windows.Forms.Button btnTimKiem;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_LoaiHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_NguoiTiepNhan;
        private DevExpress.XtraGrid.Columns.GridColumn col_NgayTiepNhan;
        private Common.ClinicComponents.NewTextField txtNguoiTiepNhan;
    }
}
