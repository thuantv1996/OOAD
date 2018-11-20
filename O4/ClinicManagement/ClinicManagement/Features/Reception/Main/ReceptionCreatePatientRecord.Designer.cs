namespace ClinicManagement.Features.Reception.Main
{
    partial class ReceptionCreatePatientRecord
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
            this.addPatientControl1 = new ClinicManagement.Features.Reception.SubForms.AddPatientControl();
            this.SuspendLayout();
            // 
            // addPatientControl1
            // 
            this.addPatientControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addPatientControl1.BackColor = System.Drawing.Color.White;
            this.addPatientControl1.Location = new System.Drawing.Point(0, 0);
            this.addPatientControl1.Name = "addPatientControl1";
            this.addPatientControl1.Size = new System.Drawing.Size(802, 543);
            this.addPatientControl1.TabIndex = 0;
            // 
            // ReceptionCreatePatientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.addPatientControl1);
            this.DoubleBuffered = true;
            this.Name = "ReceptionCreatePatientRecord";
            this.Size = new System.Drawing.Size(802, 543);
            this.ResumeLayout(false);

        }

        #endregion

        private SubForms.AddPatientControl addPatientControl1;
    }
}
