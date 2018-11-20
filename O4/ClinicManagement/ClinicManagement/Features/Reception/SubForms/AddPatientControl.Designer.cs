namespace ClinicManagement.Features.Reception.SubForms
{
    partial class AddPatientControl
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.patientEdit = new ClinicManagement.Common.ClinicComponents.PatientEdit();
            this.patientInformation = new ClinicManagement.Common.ClinicComponents.PatientInformation();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnCreate.BackColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(235, 475);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(331, 42);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Tạo hồ sơ";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(406, 475);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(160, 42);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(235, 475);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 42);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // patientEdit
            // 
            this.patientEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.patientEdit.Location = new System.Drawing.Point(161, 50);
            this.patientEdit.Name = "patientEdit";
            this.patientEdit.Size = new System.Drawing.Size(479, 398);
            this.patientEdit.TabIndex = 0;
            // 
            // patientInformation
            // 
            this.patientInformation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.patientInformation.Location = new System.Drawing.Point(161, 50);
            this.patientInformation.Name = "patientInformation";
            this.patientInformation.Size = new System.Drawing.Size(479, 398);
            this.patientInformation.TabIndex = 1;
            // 
            // AddPatientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.patientEdit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.patientInformation);
            this.Name = "AddPatientControl";
            this.Size = new System.Drawing.Size(801, 548);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.ClinicComponents.PatientEdit patientEdit;
        private System.Windows.Forms.Button btnCreate;
        private Common.ClinicComponents.PatientInformation patientInformation;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
    }
}
