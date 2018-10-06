namespace ClinicManagement.Features.Reception.Subform
{
    partial class CreateRecordsControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContinue = new DevExpress.XtraEditors.SimpleButton();
            this.cbSex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbBirthDay = new DevExpress.XtraEditors.DateEdit();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtIdNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBirthDay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBirthDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Họ tên";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(433, 22);
            this.txtName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.cbSex);
            this.panel1.Controls.Add(this.cbBirthDay);
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.txtIdNumber);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(25, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 411);
            this.panel1.TabIndex = 2;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnContinue.Location = new System.Drawing.Point(159, 445);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(190, 34);
            this.btnContinue.TabIndex = 69;
            this.btnContinue.Text = "Tiếp tục";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // cbSex
            // 
            this.cbSex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSex.Location = new System.Drawing.Point(12, 187);
            this.cbSex.Name = "cbSex";
            this.cbSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSex.Size = new System.Drawing.Size(433, 22);
            this.cbSex.TabIndex = 15;
            // 
            // cbBirthDay
            // 
            this.cbBirthDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBirthDay.EditValue = null;
            this.cbBirthDay.Location = new System.Drawing.Point(12, 83);
            this.cbBirthDay.Name = "cbBirthDay";
            this.cbBirthDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBirthDay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBirthDay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.cbBirthDay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cbBirthDay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.cbBirthDay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cbBirthDay.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBirthDay.Size = new System.Drawing.Size(433, 22);
            this.cbBirthDay.TabIndex = 14;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(12, 291);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(433, 96);
            this.txtNote.TabIndex = 12;
            this.txtNote.Text = "";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 269);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 16);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Ghi chú";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(12, 238);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(433, 22);
            this.txtAddress.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 216);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(40, 17);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Địa chỉ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 165);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 17);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Giới tính";
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdNumber.Location = new System.Drawing.Point(12, 135);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.Size = new System.Drawing.Size(433, 22);
            this.txtIdNumber.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 113);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(95, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Cmnd/passport..";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ngày sinh";
            // 
            // CreateRecordsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.panel1);
            this.Name = "CreateRecordsControl";
            this.Size = new System.Drawing.Size(509, 500);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBirthDay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBirthDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdNumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtIdNumber;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.RichTextBox txtNote;
        private DevExpress.XtraEditors.DateEdit cbBirthDay;
        private DevExpress.XtraEditors.ComboBoxEdit cbSex;
        private DevExpress.XtraEditors.SimpleButton btnContinue;
    }
}
