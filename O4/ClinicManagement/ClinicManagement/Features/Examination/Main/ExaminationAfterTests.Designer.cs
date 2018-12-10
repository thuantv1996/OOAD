namespace ClinicManagement.Features.Examination.Main
{
    partial class ExaminationAfterTests
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
            this.danhSachChoKeDon = new ClinicManagement.Features.Examination.SubForms.WaitingPatientTable();
            this.SuspendLayout();
            // 
            // danhSachChoKeDon
            // 
            this.danhSachChoKeDon.BackColor = System.Drawing.Color.White;
            this.danhSachChoKeDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.danhSachChoKeDon.Location = new System.Drawing.Point(0, 0);
            this.danhSachChoKeDon.Name = "danhSachChoKeDon";
            this.danhSachChoKeDon.Size = new System.Drawing.Size(791, 525);
            this.danhSachChoKeDon.TabIndex = 0;
            // 
            // ExaminationAfterTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.danhSachChoKeDon);
            this.Name = "ExaminationAfterTests";
            this.Size = new System.Drawing.Size(791, 525);
            this.ResumeLayout(false);

        }

        #endregion

        private SubForms.WaitingPatientTable danhSachChoKeDon;
    }
}
