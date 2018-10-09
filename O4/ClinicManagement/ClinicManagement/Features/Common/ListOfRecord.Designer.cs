namespace ClinicManagement.Features.Common
{
    partial class ListOfRecord
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
            this.grd_ListControl = new DevExpress.XtraGrid.GridControl();
            this.grd_ListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPatientIdentity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentityCardNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ListControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ListView)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_ListControl
            // 
            this.grd_ListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_ListControl.Location = new System.Drawing.Point(0, 0);
            this.grd_ListControl.MainView = this.grd_ListView;
            this.grd_ListControl.Name = "grd_ListControl";
            this.grd_ListControl.Size = new System.Drawing.Size(580, 497);
            this.grd_ListControl.TabIndex = 0;
            this.grd_ListControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grd_ListView});
            // 
            // grd_ListView
            // 
            this.grd_ListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPatientIdentity,
            this.colName,
            this.colBirthDay,
            this.colIdentityCardNumber,
            this.colSex,
            this.colAddress,
            this.colNote});
            this.grd_ListView.GridControl = this.grd_ListControl;
            this.grd_ListView.Name = "grd_ListView";
            this.grd_ListView.OptionsFind.AlwaysVisible = true;
            this.grd_ListView.OptionsView.ShowGroupPanel = false;
            // 
            // colPatientIdentity
            // 
            this.colPatientIdentity.Caption = "Mã số";
            this.colPatientIdentity.Name = "colPatientIdentity";
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
            // colIdentityCardNumber
            // 
            this.colIdentityCardNumber.Caption = "cmnd/passport";
            this.colIdentityCardNumber.Name = "colIdentityCardNumber";
            this.colIdentityCardNumber.Visible = true;
            this.colIdentityCardNumber.VisibleIndex = 2;
            // 
            // colSex
            // 
            this.colSex.Caption = "Giới tính";
            this.colSex.Name = "colSex";
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 3;
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
            // ListOfRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grd_ListControl);
            this.Name = "ListOfRecord";
            this.Size = new System.Drawing.Size(580, 497);
            ((System.ComponentModel.ISupportInitialize)(this.grd_ListControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd_ListControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grd_ListView;
        private DevExpress.XtraGrid.Columns.GridColumn colPatientIdentity;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDay;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentityCardNumber;
    }
}
