namespace ClinicManagement.Features.Examination.SubForms
{
    partial class LatestPrescription
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
            this.col_MaThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtChuanDoan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBacSi = new System.Windows.Forms.Label();
            this.txtNgayKham = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(10, 138);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(832, 354);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaThuoc,
            this.col_TenThuoc,
            this.col_SoLuong,
            this.col_GhiChu});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaThuoc
            // 
            this.col_MaThuoc.Caption = "Mã thuốc";
            this.col_MaThuoc.FieldName = "MaThuoc";
            this.col_MaThuoc.Name = "col_MaThuoc";
            this.col_MaThuoc.Visible = true;
            this.col_MaThuoc.VisibleIndex = 0;
            // 
            // col_TenThuoc
            // 
            this.col_TenThuoc.Caption = "Tên thuốc";
            this.col_TenThuoc.FieldName = "TenThuoc";
            this.col_TenThuoc.Name = "col_TenThuoc";
            this.col_TenThuoc.Visible = true;
            this.col_TenThuoc.VisibleIndex = 1;
            // 
            // col_SoLuong
            // 
            this.col_SoLuong.Caption = "Số lượng";
            this.col_SoLuong.FieldName = "SoLuong";
            this.col_SoLuong.Name = "col_SoLuong";
            this.col_SoLuong.Visible = true;
            this.col_SoLuong.VisibleIndex = 2;
            // 
            // col_GhiChu
            // 
            this.col_GhiChu.Caption = "Ghi chú";
            this.col_GhiChu.FieldName = "GhiChu";
            this.col_GhiChu.Name = "col_GhiChu";
            this.col_GhiChu.Visible = true;
            this.col_GhiChu.VisibleIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtChuanDoan, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBacSi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNgayKham, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(830, 100);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // txtChuanDoan
            // 
            this.txtChuanDoan.AutoSize = true;
            this.txtChuanDoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChuanDoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChuanDoan.Location = new System.Drawing.Point(156, 66);
            this.txtChuanDoan.Name = "txtChuanDoan";
            this.txtChuanDoan.Size = new System.Drawing.Size(671, 34);
            this.txtChuanDoan.TabIndex = 5;
            this.txtChuanDoan.Text = "label6";
            this.txtChuanDoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 34);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chuẩn đoán:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBacSi
            // 
            this.txtBacSi.AutoSize = true;
            this.txtBacSi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBacSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBacSi.Location = new System.Drawing.Point(156, 33);
            this.txtBacSi.Name = "txtBacSi";
            this.txtBacSi.Size = new System.Drawing.Size(671, 33);
            this.txtBacSi.TabIndex = 3;
            this.txtBacSi.Text = "label4";
            this.txtBacSi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNgayKham
            // 
            this.txtNgayKham.AutoSize = true;
            this.txtNgayKham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayKham.Location = new System.Drawing.Point(156, 0);
            this.txtNgayKham.Name = "txtNgayKham";
            this.txtNgayKham.Size = new System.Drawing.Size(671, 33);
            this.txtNgayKham.TabIndex = 2;
            this.txtNgayKham.Text = "label3";
            this.txtNgayKham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày khám:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bác sĩ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(10, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 102);
            this.panel1.TabIndex = 4;
            // 
            // LatestPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.Name = "LatestPrescription";
            this.Size = new System.Drawing.Size(853, 506);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_GhiChu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtChuanDoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtBacSi;
        private System.Windows.Forms.Label txtNgayKham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
