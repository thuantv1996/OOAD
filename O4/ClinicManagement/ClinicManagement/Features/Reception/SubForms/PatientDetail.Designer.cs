using ClinicManagement.Common.ClinicComponents;

namespace ClinicManagement.Features.Reception.SubForms
{
    partial class PatientDetail
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.patientInformation = new ClinicManagement.Common.ClinicComponents.PatientInformation();
            this.patientEdit = new ClinicManagement.Common.ClinicComponents.PatientEdit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(278, 459);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(404, 459);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(118, 35);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Tạo bệnh án";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(278, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // patientInformation
            // 
            this.patientInformation.Location = new System.Drawing.Point(250, 55);
            this.patientInformation.Name = "patientInformation";
            this.patientInformation.Size = new System.Drawing.Size(479, 398);
            this.patientInformation.TabIndex = 0;
            // 
            // patientEdit
            // 
            this.patientEdit.Location = new System.Drawing.Point(250, 55);
            this.patientEdit.Name = "patientEdit";
            this.patientEdit.Size = new System.Drawing.Size(479, 398);
            this.patientEdit.TabIndex = 0;
            // 
            // PatientDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.patientInformation);
            this.Controls.Add(this.patientEdit);
            this.Name = "PatientDetail";
            this.Size = new System.Drawing.Size(801, 548);
            this.ResumeLayout(false);

        }

        #endregion

        private PatientInformation patientInformation;
        private PatientEdit patientEdit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreate;
    }
}
