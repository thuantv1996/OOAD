namespace ClinicManagement.Features.Examination.SubForms
{
    partial class CreatePrescriptionsConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePrescriptionsConfirm));
            this.patientMainInformation1 = new ClinicManagement.Common.ClinicComponents.PatientMainInformation();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChiPhi = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtChuanDoan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientMainInformation1
            // 
            this.patientMainInformation1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientMainInformation1.Location = new System.Drawing.Point(6, 3);
            this.patientMainInformation1.Name = "patientMainInformation1";
            this.patientMainInformation1.Size = new System.Drawing.Size(791, 140);
            this.patientMainInformation1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 304);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(789, 235);
            this.gridControl1.TabIndex = 1;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 562);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tổng số tiền:";
            // 
            // txtChiPhi
            // 
            this.txtChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChiPhi.AutoSize = true;
            this.txtChiPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiPhi.Location = new System.Drawing.Point(124, 562);
            this.txtChiPhi.Name = "txtChiPhi";
            this.txtChiPhi.Size = new System.Drawing.Size(59, 20);
            this.txtChiPhi.TabIndex = 3;
            this.txtChiPhi.Text = "0 VND";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(655, 554);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 39);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtChuanDoan);
            this.panel1.Location = new System.Drawing.Point(6, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 97);
            this.panel1.TabIndex = 5;
            // 
            // txtChuanDoan
            // 
            this.txtChuanDoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChuanDoan.AutoSize = true;
            this.txtChuanDoan.Location = new System.Drawing.Point(3, 0);
            this.txtChuanDoan.MaximumSize = new System.Drawing.Size(765, 0);
            this.txtChuanDoan.Name = "txtChuanDoan";
            this.txtChuanDoan.Size = new System.Drawing.Size(763, 323);
            this.txtChuanDoan.TabIndex = 7;
            this.txtChuanDoan.Text = resources.GetString("txtChuanDoan.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chuẩn đoán:";
            // 
            // CreatePrescriptionsConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtChiPhi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.patientMainInformation1);
            this.Name = "CreatePrescriptionsConfirm";
            this.Size = new System.Drawing.Size(803, 611);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.ClinicComponents.PatientMainInformation patientMainInformation1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_GhiChu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtChiPhi;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtChuanDoan;
        private System.Windows.Forms.Label label2;
    }
}
