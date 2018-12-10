namespace ClinicManagement.Features.Examination.SubForms
{
    partial class MedicalExaminationAfterTests
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.txtChuanDoanBenh = new ClinicManagement.Common.ClinicComponents.RichTextBoxWithLine(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.patientMainInformation = new ClinicManagement.Common.ClinicComponents.PatientMainInformation();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.txtChuanDoanBenh);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.patientMainInformation);
            this.mainPanel.Location = new System.Drawing.Point(12, 17);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(802, 522);
            this.mainPanel.TabIndex = 6;
            // 
            // txtChuanDoanBenh
            // 
            this.txtChuanDoanBenh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChuanDoanBenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChuanDoanBenh.Location = new System.Drawing.Point(5, 166);
            this.txtChuanDoanBenh.Name = "txtChuanDoanBenh";
            this.txtChuanDoanBenh.Size = new System.Drawing.Size(792, 96);
            this.txtChuanDoanBenh.TabIndex = 9;
            this.txtChuanDoanBenh.Text = "-  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chuẩn đoán:";
            // 
            // patientMainInformation
            // 
            this.patientMainInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientMainInformation.Location = new System.Drawing.Point(5, 3);
            this.patientMainInformation.Name = "patientMainInformation";
            this.patientMainInformation.Size = new System.Drawing.Size(790, 140);
            this.patientMainInformation.TabIndex = 6;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(657, 558);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(157, 40);
            this.btnXacNhan.TabIndex = 9;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // MedicalExaminationAfterTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.mainPanel);
            this.Name = "MedicalExaminationAfterTests";
            this.Size = new System.Drawing.Size(826, 615);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private Common.ClinicComponents.RichTextBoxWithLine txtChuanDoanBenh;
        private System.Windows.Forms.Label label3;
        private Common.ClinicComponents.PatientMainInformation patientMainInformation;
        private System.Windows.Forms.Button btnXacNhan;
    }
}
