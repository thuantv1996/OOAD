namespace ClinicManagement.Features.Examination.SubForms
{
    partial class CreatePrescriptions
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
            this.btnThem = new System.Windows.Forms.Button();
            this.gridThuoc = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_TenThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_MaThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGhiChu = new ClinicManagement.Common.ClinicComponents.RichTextBoxWithLine(this.components);
            this.cbTenThuoc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnSaveChanged = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTenThuoc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Enabled = false;
            this.btnThem.Location = new System.Drawing.Point(0, 188);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 32);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // gridThuoc
            // 
            this.gridThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridThuoc.Location = new System.Drawing.Point(0, 226);
            this.gridThuoc.MainView = this.gridView1;
            this.gridThuoc.Name = "gridThuoc";
            this.gridThuoc.Size = new System.Drawing.Size(940, 331);
            this.gridThuoc.TabIndex = 4;
            this.gridThuoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_TenThuoc,
            this.col_SoLuong,
            this.col_GhiChu,
            this.col_MaThuoc});
            this.gridView1.GridControl = this.gridThuoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
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
            // col_MaThuoc
            // 
            this.col_MaThuoc.Caption = "Mã thuốc";
            this.col_MaThuoc.FieldName = "MaThuoc";
            this.col_MaThuoc.Name = "col_MaThuoc";
            this.col_MaThuoc.Visible = true;
            this.col_MaThuoc.VisibleIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(91, 188);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 32);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.cbTenThuoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 179);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kê đơn thuốc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(16, 83);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(911, 79);
            this.txtGhiChu.TabIndex = 6;
            this.txtGhiChu.Text = "-  ";
            // 
            // cbTenThuoc
            // 
            this.cbTenThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTenThuoc.Location = new System.Drawing.Point(117, 25);
            this.cbTenThuoc.Name = "cbTenThuoc";
            this.cbTenThuoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbTenThuoc.Properties.Appearance.Options.UseFont = true;
            this.cbTenThuoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTenThuoc.Size = new System.Drawing.Size(611, 28);
            this.cbTenThuoc.TabIndex = 1;
            this.cbTenThuoc.SelectedIndexChanged += new System.EventHandler(this.cbTenThuoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(734, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số lượng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên thuốc:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(839, 27);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(88, 26);
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // btnSaveChanged
            // 
            this.btnSaveChanged.BackColor = System.Drawing.Color.White;
            this.btnSaveChanged.Enabled = false;
            this.btnSaveChanged.Location = new System.Drawing.Point(182, 188);
            this.btnSaveChanged.Name = "btnSaveChanged";
            this.btnSaveChanged.Size = new System.Drawing.Size(85, 32);
            this.btnSaveChanged.TabIndex = 8;
            this.btnSaveChanged.Text = "Lưu";
            this.btnSaveChanged.UseVisualStyleBackColor = false;
            this.btnSaveChanged.Click += new System.EventHandler(this.btnSaveChanged_Click);
            // 
            // CreatePrescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveChanged);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gridThuoc);
            this.Controls.Add(this.btnThem);
            this.MinimumSize = new System.Drawing.Size(659, 348);
            this.Name = "CreatePrescriptions";
            this.Size = new System.Drawing.Size(940, 557);
            ((System.ComponentModel.ISupportInitialize)(this.gridThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTenThuoc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnThem;
        private DevExpress.XtraGrid.GridControl gridThuoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private Common.ClinicComponents.RichTextBoxWithLine txtGhiChu;
        private DevExpress.XtraEditors.ComboBoxEdit cbTenThuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_TenThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn col_SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn col_GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn col_MaThuoc;
        private System.Windows.Forms.Button btnSaveChanged;
    }
}
