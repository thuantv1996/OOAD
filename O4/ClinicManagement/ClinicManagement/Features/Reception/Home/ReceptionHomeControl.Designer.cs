namespace ClinicManagement.Features.Reception.Home
{
    partial class ReceptionHomeControl
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
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentityNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(751, 537);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colBirthDay,
            this.colSex,
            this.colIdentityNumber,
            this.colAddress,
            this.colNote});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.colBirthDay.VisibleIndex = 1;
            // 
            // colSex
            // 
            this.colSex.Caption = "Giới tính";
            this.colSex.Name = "colSex";
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 2;
            // 
            // colIdentityNumber
            // 
            this.colIdentityNumber.Caption = "cmnd/passport";
            this.colIdentityNumber.Name = "colIdentityNumber";
            this.colIdentityNumber.Visible = true;
            this.colIdentityNumber.VisibleIndex = 3;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "Địa chỉ";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 5;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(766, 19);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(102, 42);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(766, 83);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(102, 42);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(766, 152);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(102, 42);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "simpleButton3";
            // 
            // ReceptionHomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Name = "ReceptionHomeControl";
            this.Size = new System.Drawing.Size(886, 537);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDay;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentityNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}
