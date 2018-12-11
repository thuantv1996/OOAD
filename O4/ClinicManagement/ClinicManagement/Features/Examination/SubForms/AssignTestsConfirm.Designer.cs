namespace ClinicManagement.Features.Examination.SubForms
{
    partial class AssignTestsConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignTestsConfirm));
            this.patientMainInformation1 = new ClinicManagement.Common.ClinicComponents.PatientMainInformation();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_MaXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TenPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChuanDoan = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChiPhi = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.panel.SuspendLayout();
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
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_MaXetNghiem,
            this.col_TenXetNghiem,
            this.col_MaPhong,
            this.col_TenPhong});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col_MaXetNghiem
            // 
            this.col_MaXetNghiem.Caption = "Mã xét nghiệm";
            this.col_MaXetNghiem.FieldName = "MaXetNghiem";
            this.col_MaXetNghiem.Name = "col_MaXetNghiem";
            // 
            // col_TenXetNghiem
            // 
            this.col_TenXetNghiem.Caption = "Tên xét nghiệm";
            this.col_TenXetNghiem.FieldName = "TenXetNghiem";
            this.col_TenXetNghiem.Name = "col_TenXetNghiem";
            this.col_TenXetNghiem.Visible = true;
            this.col_TenXetNghiem.VisibleIndex = 0;
            // 
            // col_MaPhong
            // 
            this.col_MaPhong.Caption = "Mã phòng";
            this.col_MaPhong.FieldName = "MaPhong";
            this.col_MaPhong.Name = "col_MaPhong";
            // 
            // col_TenPhong
            // 
            this.col_TenPhong.Caption = "Tên phòng";
            this.col_TenPhong.FieldName = "TenPhong";
            this.col_TenPhong.Name = "col_TenPhong";
            this.col_TenPhong.Visible = true;
            this.col_TenPhong.VisibleIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chuẩn đoán:";
            // 
            // txtChuanDoan
            // 
            this.txtChuanDoan.AutoSize = true;
            this.txtChuanDoan.Location = new System.Drawing.Point(4, 0);
            this.txtChuanDoan.MaximumSize = new System.Drawing.Size(753, 0);
            this.txtChuanDoan.Name = "txtChuanDoan";
            this.txtChuanDoan.Size = new System.Drawing.Size(738, 136);
            this.txtChuanDoan.TabIndex = 3;
            this.txtChuanDoan.Text = resources.GetString("txtChuanDoan.Text");
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.txtChuanDoan);
            this.panel.Location = new System.Drawing.Point(6, 178);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(789, 97);
            this.panel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 562);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng chi phí:";
            // 
            // txtChiPhi
            // 
            this.txtChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChiPhi.AutoSize = true;
            this.txtChiPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiPhi.Location = new System.Drawing.Point(124, 562);
            this.txtChiPhi.Name = "txtChiPhi";
            this.txtChiPhi.Size = new System.Drawing.Size(59, 20);
            this.txtChiPhi.TabIndex = 6;
            this.txtChiPhi.Text = "0 VND";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(655, 554);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 39);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // AssignTestsConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtChiPhi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.patientMainInformation1);
            this.Name = "AssignTestsConfirm";
            this.Size = new System.Drawing.Size(803, 611);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.ClinicComponents.PatientMainInformation patientMainInformation1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaXetNghiem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenXetNghiem;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtChuanDoan;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtChiPhi;
        private System.Windows.Forms.Button btnConfirm;
    }
}
