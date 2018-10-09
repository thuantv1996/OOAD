namespace ClinicManagement.Features.Examination.Home
{
    partial class ExaminationHomeControl
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
            this.tabListRecords = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabWaiting = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton8 = new DevExpress.XtraEditors.SimpleButton();
            this.listOfWaitingRecords = new ClinicManagement.Features.Common.ListOfRecord();
            this.tabDone = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.listOfDoneRecords = new ClinicManagement.Features.Common.ListOfRecord();
            ((System.ComponentModel.ISupportInitialize)(this.tabListRecords)).BeginInit();
            this.tabListRecords.SuspendLayout();
            this.tabWaiting.SuspendLayout();
            this.tabDone.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabListRecords
            // 
            this.tabListRecords.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabListRecords.Appearance.Options.UseBackColor = true;
            this.tabListRecords.Controls.Add(this.tabWaiting);
            this.tabListRecords.Controls.Add(this.tabDone);
            this.tabListRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabListRecords.Location = new System.Drawing.Point(0, 0);
            this.tabListRecords.Name = "tabListRecords";
            this.tabListRecords.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabWaiting,
            this.tabDone});
            this.tabListRecords.RegularSize = new System.Drawing.Size(704, 449);
            this.tabListRecords.SelectedPage = this.tabWaiting;
            this.tabListRecords.Size = new System.Drawing.Size(704, 449);
            this.tabListRecords.TabIndex = 1;
            this.tabListRecords.Text = "tabPane1";
            this.tabListRecords.SelectedPageChanging += new DevExpress.XtraBars.Navigation.SelectedPageChangingEventHandler(this.tabListRecords_SelectedPageChanging);
            // 
            // tabWaiting
            // 
            this.tabWaiting.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabWaiting.Appearance.Options.UseBackColor = true;
            this.tabWaiting.Caption = "Hồ sơ đang chờ";
            this.tabWaiting.Controls.Add(this.simpleButton6);
            this.tabWaiting.Controls.Add(this.simpleButton7);
            this.tabWaiting.Controls.Add(this.simpleButton8);
            this.tabWaiting.Controls.Add(this.listOfWaitingRecords);
            this.tabWaiting.Name = "tabWaiting";
            this.tabWaiting.PageText = "Hồ sơ đang chờ";
            this.tabWaiting.Size = new System.Drawing.Size(682, 392);
            // 
            // simpleButton6
            // 
            this.simpleButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton6.Location = new System.Drawing.Point(564, 131);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(102, 42);
            this.simpleButton6.TabIndex = 7;
            this.simpleButton6.Text = "Xem tiền sử";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton7.Location = new System.Drawing.Point(564, 73);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(102, 42);
            this.simpleButton7.TabIndex = 6;
            this.simpleButton7.Text = "Khám bệnh";
            // 
            // simpleButton8
            // 
            this.simpleButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton8.Location = new System.Drawing.Point(564, 15);
            this.simpleButton8.Name = "simpleButton8";
            this.simpleButton8.Size = new System.Drawing.Size(102, 42);
            this.simpleButton8.TabIndex = 5;
            this.simpleButton8.Text = "Làm mới";
            // 
            // listOfWaitingRecords
            // 
            this.listOfWaitingRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfWaitingRecords.Location = new System.Drawing.Point(0, 0);
            this.listOfWaitingRecords.Name = "listOfWaitingRecords";
            this.listOfWaitingRecords.Size = new System.Drawing.Size(550, 392);
            this.listOfWaitingRecords.TabIndex = 0;
            // 
            // tabDone
            // 
            this.tabDone.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabDone.Appearance.Options.UseBackColor = true;
            this.tabDone.Caption = "Hồ sơ đã xét nghiệm";
            this.tabDone.Controls.Add(this.simpleButton4);
            this.tabDone.Controls.Add(this.simpleButton3);
            this.tabDone.Controls.Add(this.simpleButton2);
            this.tabDone.Controls.Add(this.simpleButton1);
            this.tabDone.Controls.Add(this.listOfDoneRecords);
            this.tabDone.Name = "tabDone";
            this.tabDone.Size = new System.Drawing.Size(682, 392);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Location = new System.Drawing.Point(564, 189);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(102, 42);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "Kê đơn thuốc";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Location = new System.Drawing.Point(564, 131);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(102, 42);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "Xem tiền sử";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(564, 73);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(102, 42);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Kết quả";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(564, 15);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(102, 42);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Làm mới";
            // 
            // listOfDoneRecords
            // 
            this.listOfDoneRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfDoneRecords.Location = new System.Drawing.Point(0, 0);
            this.listOfDoneRecords.Name = "listOfDoneRecords";
            this.listOfDoneRecords.Size = new System.Drawing.Size(550, 392);
            this.listOfDoneRecords.TabIndex = 0;
            // 
            // ExaminationHomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabListRecords);
            this.Name = "ExaminationHomeControl";
            this.Size = new System.Drawing.Size(704, 449);
            ((System.ComponentModel.ISupportInitialize)(this.tabListRecords)).EndInit();
            this.tabListRecords.ResumeLayout(false);
            this.tabWaiting.ResumeLayout(false);
            this.tabDone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.ListOfRecord listOfWaitingRecords;
        private DevExpress.XtraBars.Navigation.TabPane tabListRecords;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabWaiting;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private DevExpress.XtraEditors.SimpleButton simpleButton8;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabDone;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private Common.ListOfRecord listOfDoneRecords;
    }
}
