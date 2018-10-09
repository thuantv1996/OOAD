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
            this.btnCreateRecords = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateCaseRecord = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateBill = new DevExpress.XtraEditors.SimpleButton();
            this.listOfPatientRecords = new ClinicManagement.Features.Common.ListOfRecord();
            this.SuspendLayout();
            // 
            // btnCreateRecords
            // 
            this.btnCreateRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateRecords.Location = new System.Drawing.Point(623, 15);
            this.btnCreateRecords.Name = "btnCreateRecords";
            this.btnCreateRecords.Size = new System.Drawing.Size(102, 42);
            this.btnCreateRecords.TabIndex = 1;
            this.btnCreateRecords.Text = "Tạo hồ sơ";
            this.btnCreateRecords.Click += new System.EventHandler(this.btnCreateRecords_Click);
            // 
            // btnCreateCaseRecord
            // 
            this.btnCreateCaseRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCaseRecord.Location = new System.Drawing.Point(623, 73);
            this.btnCreateCaseRecord.Name = "btnCreateCaseRecord";
            this.btnCreateCaseRecord.Size = new System.Drawing.Size(102, 42);
            this.btnCreateCaseRecord.TabIndex = 2;
            this.btnCreateCaseRecord.Text = "Tạo bệnh án";
            this.btnCreateCaseRecord.Click += new System.EventHandler(this.btnCreateCaseRecord_Click);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateBill.Location = new System.Drawing.Point(623, 131);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(102, 42);
            this.btnCreateBill.TabIndex = 3;
            this.btnCreateBill.Text = "Lập hóa đơn";
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // listOfPatientRecords
            // 
            this.listOfPatientRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfPatientRecords.Location = new System.Drawing.Point(0, 0);
            this.listOfPatientRecords.Name = "listOfPatientRecords";
            this.listOfPatientRecords.Size = new System.Drawing.Size(606, 537);
            this.listOfPatientRecords.TabIndex = 4;
            // 
            // ReceptionHomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.listOfPatientRecords);
            this.Controls.Add(this.btnCreateBill);
            this.Controls.Add(this.btnCreateCaseRecord);
            this.Controls.Add(this.btnCreateRecords);
            this.Name = "ReceptionHomeControl";
            this.Size = new System.Drawing.Size(742, 537);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCreateRecords;
        private DevExpress.XtraEditors.SimpleButton btnCreateCaseRecord;
        private DevExpress.XtraEditors.SimpleButton btnCreateBill;
        private Common.ListOfRecord listOfPatientRecords;
    }
}
