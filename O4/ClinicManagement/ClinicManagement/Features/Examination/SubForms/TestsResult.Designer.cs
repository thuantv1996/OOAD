namespace ClinicManagement.Features.Examination.SubForms
{
    partial class TestsResult
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaBacSi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NgayXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KetQuaXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenBacSi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(821, 597);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaXetNghiem,
            this.col_MaBacSi,
            this.col_TenXetNghiem,
            this.col_NgayXetNghiem,
            this.col_KetQuaXetNghiem,
            this.col_TenBacSi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaXetNghiem
            // 
            this.col_MaXetNghiem.Caption = "Mã xét nghiệm";
            this.col_MaXetNghiem.FieldName = "MaXetNghiem";
            this.col_MaXetNghiem.Name = "col_MaXetNghiem";
            // 
            // col_MaBacSi
            // 
            this.col_MaBacSi.Caption = "Mã bác sĩ";
            this.col_MaBacSi.FieldName = "MaBacSi";
            this.col_MaBacSi.Name = "col_MaBacSi";
            // 
            // col_TenXetNghiem
            // 
            this.col_TenXetNghiem.Caption = "Tên xét nghiệm";
            this.col_TenXetNghiem.FieldName = "TenXetNghiem";
            this.col_TenXetNghiem.Name = "col_TenXetNghiem";
            this.col_TenXetNghiem.Visible = true;
            this.col_TenXetNghiem.VisibleIndex = 0;
            // 
            // col_NgayXetNghiem
            // 
            this.col_NgayXetNghiem.Caption = "Ngày xét nghiệm";
            this.col_NgayXetNghiem.FieldName = "NgayXetNghiem";
            this.col_NgayXetNghiem.Name = "col_NgayXetNghiem";
            this.col_NgayXetNghiem.Visible = true;
            this.col_NgayXetNghiem.VisibleIndex = 1;
            // 
            // col_KetQuaXetNghiem
            // 
            this.col_KetQuaXetNghiem.Caption = "Kết quả xét nghiệm";
            this.col_KetQuaXetNghiem.FieldName = "KetQuaXetNghiem";
            this.col_KetQuaXetNghiem.Name = "col_KetQuaXetNghiem";
            this.col_KetQuaXetNghiem.Visible = true;
            this.col_KetQuaXetNghiem.VisibleIndex = 2;
            // 
            // col_TenBacSi
            // 
            this.col_TenBacSi.Caption = "Tên bác sĩ";
            this.col_TenBacSi.FieldName = "TenBacSi";
            this.col_TenBacSi.Name = "col_TenBacSi";
            this.col_TenBacSi.Visible = true;
            this.col_TenBacSi.VisibleIndex = 3;
            // 
            // TestsResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "TestsResult";
            this.Size = new System.Drawing.Size(824, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaXetNghiem;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaBacSi;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenXetNghiem;
        private DevExpress.XtraGrid.Columns.GridColumn col_NgayXetNghiem;
        private DevExpress.XtraGrid.Columns.GridColumn col_KetQuaXetNghiem;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenBacSi;
    }
}
