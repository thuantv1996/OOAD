namespace ClinicManagement.TiepNhan
{
    partial class HomeReceiver
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridListRecords = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentityCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCreateMedicalRecord = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateRecord = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridListRecords);
            this.panelControl1.Controls.Add(this.btnCreateMedicalRecord);
            this.panelControl1.Controls.Add(this.btnCreateInvoice);
            this.panelControl1.Controls.Add(this.btnCreateRecord);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(590, 386);
            this.panelControl1.TabIndex = 0;
            // 
            // gridListRecords
            // 
            this.gridListRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListRecords.Location = new System.Drawing.Point(0, 42);
            this.gridListRecords.MainView = this.gridView1;
            this.gridListRecords.Name = "gridListRecords";
            this.gridListRecords.Size = new System.Drawing.Size(590, 343);
            this.gridListRecords.TabIndex = 5;
            this.gridListRecords.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colBirthDay,
            this.colIdentityCard});
            this.gridView1.GridControl = this.gridListRecords;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colId
            // 
            this.colId.Caption = "Mã số";
            this.colId.Name = "colId";
            // 
            // colName
            // 
            this.colName.Caption = "Họ tên";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colBirthDay
            // 
            this.colBirthDay.Caption = "Ngày sinh";
            this.colBirthDay.Name = "colBirthDay";
            this.colBirthDay.Visible = true;
            this.colBirthDay.VisibleIndex = 2;
            // 
            // colIdentityCard
            // 
            this.colIdentityCard.Caption = "CMT/Passport";
            this.colIdentityCard.Name = "colIdentityCard";
            this.colIdentityCard.Visible = true;
            this.colIdentityCard.VisibleIndex = 1;
            // 
            // btnCreateMedicalRecord
            // 
            this.btnCreateMedicalRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateMedicalRecord.Location = new System.Drawing.Point(345, 2);
            this.btnCreateMedicalRecord.Name = "btnCreateMedicalRecord";
            this.btnCreateMedicalRecord.Size = new System.Drawing.Size(75, 34);
            this.btnCreateMedicalRecord.TabIndex = 8;
            this.btnCreateMedicalRecord.Text = "Tạo bệnh án";
            // 
            // btnCreateInvoice
            // 
            this.btnCreateInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateInvoice.Location = new System.Drawing.Point(426, 2);
            this.btnCreateInvoice.Name = "btnCreateInvoice";
            this.btnCreateInvoice.Size = new System.Drawing.Size(75, 34);
            this.btnCreateInvoice.TabIndex = 7;
            this.btnCreateInvoice.Text = "Lập hoá đơn";
            // 
            // btnCreateRecord
            // 
            this.btnCreateRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateRecord.Location = new System.Drawing.Point(507, 2);
            this.btnCreateRecord.Name = "btnCreateRecord";
            this.btnCreateRecord.Size = new System.Drawing.Size(75, 34);
            this.btnCreateRecord.TabIndex = 6;
            this.btnCreateRecord.Text = "Tạo hồ sơ mới";
            this.btnCreateRecord.Click += new System.EventHandler(this.btnCreateRecord_Click);
            // 
            // HomeReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.MinimumSize = new System.Drawing.Size(248, 285);
            this.Name = "HomeReceiver";
            this.Size = new System.Drawing.Size(590, 386);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridListRecords;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDay;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentityCard;
        private DevExpress.XtraEditors.SimpleButton btnCreateMedicalRecord;
        private DevExpress.XtraEditors.SimpleButton btnCreateInvoice;
        private DevExpress.XtraEditors.SimpleButton btnCreateRecord;
    }
}
