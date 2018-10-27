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
            this.createFormControl1 = new ClinicManagement.Features.Reception.SubForms.CreateFormControl();
            this.SuspendLayout();
            // 
            // createFormControl1
            // 
            this.createFormControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createFormControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.createFormControl1.Location = new System.Drawing.Point(99, 26);
            this.createFormControl1.Name = "createFormControl1";
            this.createFormControl1.Size = new System.Drawing.Size(524, 618);
            this.createFormControl1.TabIndex = 0;
            // 
            // ReceptionCreatePatientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::ClinicManagement.Properties.Resources.ico_closeform_24;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.createFormControl1);
            this.Name = "ReceptionCreatePatientRecord";
            this.Size = new System.Drawing.Size(723, 670);
            this.ResumeLayout(false);

        }

        #endregion

        private SubForms.CreateFormControl createFormControl1;
    }
}
