namespace ClinicManagement.Features.Reception.SubForms
{
    partial class ConfirmFormControl
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.patientInformation1 = new ClinicManagement.Common.ClinicComponents.PatientInformation();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBack.Location = new System.Drawing.Point(120, 647);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 44);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.Location = new System.Drawing.Point(268, 647);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(137, 44);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // patientInformation1
            // 
            this.patientInformation1.Location = new System.Drawing.Point(23, 30);
            this.patientInformation1.Name = "patientInformation1";
            this.patientInformation1.Size = new System.Drawing.Size(479, 398);
            this.patientInformation1.TabIndex = 0;
            // 
            // ConfirmFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.patientInformation1);
            this.Name = "ConfirmFormControl";
            this.Size = new System.Drawing.Size(524, 706);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.ClinicComponents.PatientInformation patientInformation1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirm;
    }
}
