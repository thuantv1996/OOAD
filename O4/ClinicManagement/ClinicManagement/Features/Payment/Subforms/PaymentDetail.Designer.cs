namespace ClinicManagement.Features.Payment.Subforms
{
    partial class PaymentDetail
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSTT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkLstChuaThanhToan = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDaThanhToanControl = new DevExpress.XtraGrid.GridControl();
            this.grdDaThanhToanView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_MaHoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ChiPhi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongSoTien = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstChuaThanhToan)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaThanhToanControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaThanhToanView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(896, 602);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cơ bản";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtSTT, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtHoTen, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(884, 71);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtSTT
            // 
            this.txtSTT.AutoSize = true;
            this.txtSTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTT.Location = new System.Drawing.Point(241, 35);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(640, 36);
            this.txtSTT.TabIndex = 3;
            this.txtSTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "STT:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoTen
            // 
            this.txtHoTen.AutoSize = true;
            this.txtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(241, 0);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(640, 35);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 101);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(890, 498);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkLstChuaThanhToan);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(884, 243);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách chưa thanh toán";
            // 
            // chkLstChuaThanhToan
            // 
            this.chkLstChuaThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstChuaThanhToan.Location = new System.Drawing.Point(3, 18);
            this.chkLstChuaThanhToan.Name = "chkLstChuaThanhToan";
            this.chkLstChuaThanhToan.Size = new System.Drawing.Size(878, 222);
            this.chkLstChuaThanhToan.TabIndex = 0;
            this.chkLstChuaThanhToan.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkLstChuaThanhToan_ItemCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdDaThanhToanControl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(884, 243);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách đã thanh toán";
            // 
            // grdDaThanhToanControl
            // 
            this.grdDaThanhToanControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDaThanhToanControl.Location = new System.Drawing.Point(3, 18);
            this.grdDaThanhToanControl.MainView = this.grdDaThanhToanView;
            this.grdDaThanhToanControl.Name = "grdDaThanhToanControl";
            this.grdDaThanhToanControl.Size = new System.Drawing.Size(878, 222);
            this.grdDaThanhToanControl.TabIndex = 0;
            this.grdDaThanhToanControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDaThanhToanView});
            // 
            // grdDaThanhToanView
            // 
            this.grdDaThanhToanView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_MaHoSo,
            this.col_MaXetNghiem,
            this.col_TenThanhToan,
            this.col_ChiPhi});
            this.grdDaThanhToanView.GridControl = this.grdDaThanhToanControl;
            this.grdDaThanhToanView.Name = "grdDaThanhToanView";
            this.grdDaThanhToanView.OptionsBehavior.Editable = false;
            this.grdDaThanhToanView.OptionsBehavior.ReadOnly = true;
            this.grdDaThanhToanView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdDaThanhToanView.OptionsView.ShowGroupPanel = false;
            // 
            // Col_MaHoSo
            // 
            this.Col_MaHoSo.Caption = "gridColumn1";
            this.Col_MaHoSo.FieldName = "MaHoSo";
            this.Col_MaHoSo.Name = "Col_MaHoSo";
            // 
            // col_MaXetNghiem
            // 
            this.col_MaXetNghiem.Caption = "gridColumn2";
            this.col_MaXetNghiem.FieldName = "MaXetNghiem";
            this.col_MaXetNghiem.Name = "col_MaXetNghiem";
            // 
            // col_TenThanhToan
            // 
            this.col_TenThanhToan.Caption = "Tên thanh toán";
            this.col_TenThanhToan.FieldName = "TenThanhToan";
            this.col_TenThanhToan.Name = "col_TenThanhToan";
            this.col_TenThanhToan.Visible = true;
            this.col_TenThanhToan.VisibleIndex = 0;
            // 
            // col_ChiPhi
            // 
            this.col_ChiPhi.Caption = "Chi phí";
            this.col_ChiPhi.FieldName = "ChiPhi";
            this.col_ChiPhi.Name = "col_ChiPhi";
            this.col_ChiPhi.Visible = true;
            this.col_ChiPhi.VisibleIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(773, 625);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 39);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Thanh toán";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 633);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tổng số tiền:";
            // 
            // txtTongSoTien
            // 
            this.txtTongSoTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTongSoTien.AutoSize = true;
            this.txtTongSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoTien.Location = new System.Drawing.Point(111, 633);
            this.txtTongSoTien.Name = "txtTongSoTien";
            this.txtTongSoTien.Size = new System.Drawing.Size(59, 20);
            this.txtTongSoTien.TabIndex = 3;
            this.txtTongSoTien.Text = "0 VND";
            // 
            // PaymentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTongSoTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PaymentDetail";
            this.Size = new System.Drawing.Size(899, 676);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstChuaThanhToan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDaThanhToanControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDaThanhToanView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label txtSTT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtTongSoTien;
        private DevExpress.XtraGrid.GridControl grdDaThanhToanControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDaThanhToanView;
        private DevExpress.XtraGrid.Columns.GridColumn Col_MaHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaXetNghiem;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn col_ChiPhi;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstChuaThanhToan;
    }
}
