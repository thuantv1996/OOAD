namespace ClinicManagement.Features.Analysis.Main
{
    partial class AnalysisHome
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
            this.col_MaHoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaBenhNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CMND = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(798, 616);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaHoSo,
            this.col_MaBenhNhan,
            this.col_HoTen,
            this.col_CMND});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaHoSo
            // 
            this.col_MaHoSo.Caption = "gridColumn1";
            this.col_MaHoSo.FieldName = "MaHoSo";
            this.col_MaHoSo.Name = "col_MaHoSo";
            // 
            // col_HoTen
            // 
            this.col_HoTen.Caption = "Họ tên";
            this.col_HoTen.FieldName = "HoTen";
            this.col_HoTen.Name = "col_HoTen";
            this.col_HoTen.Visible = true;
            this.col_HoTen.VisibleIndex = 0;
            // 
            // col_MaBenhNhan
            // 
            this.col_MaBenhNhan.Caption = "Mã bệnh nhân";
            this.col_MaBenhNhan.FieldName = "MaBenhNhan";
            this.col_MaBenhNhan.Name = "col_MaBenhNhan";
            this.col_MaBenhNhan.Visible = true;
            this.col_MaBenhNhan.VisibleIndex = 1;
            // 
            // col_CMND
            // 
            this.col_CMND.Caption = "CMND";
            this.col_CMND.FieldName = "CMND";
            this.col_CMND.Name = "col_CMND";
            this.col_CMND.Visible = true;
            this.col_CMND.VisibleIndex = 2;
            // 
            // AnalysisHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "AnalysisHome";
            this.Size = new System.Drawing.Size(801, 619);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaBenhNhan;
        private DevExpress.XtraGrid.Columns.GridColumn col_HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn col_CMND;
    }
}
