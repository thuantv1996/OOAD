namespace ClinicManagement.Features.Examination.Main
{
    partial class ExaminationHome
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
            this.danhSachChoKham = new ClinicManagement.Features.Examination.SubForms.WaitingPatientTable();
            this.SuspendLayout();
            // 
            // danhSachChoKham
            // 
            this.danhSachChoKham.BackColor = System.Drawing.Color.White;
            this.danhSachChoKham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.danhSachChoKham.Location = new System.Drawing.Point(0, 0);
            this.danhSachChoKham.Name = "danhSachChoKham";
            this.danhSachChoKham.Size = new System.Drawing.Size(704, 524);
            this.danhSachChoKham.TabIndex = 1;
            // 
            // ExaminationHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.danhSachChoKham);
            this.Name = "ExaminationHome";
            this.Size = new System.Drawing.Size(704, 524);
            this.ResumeLayout(false);

        }

        #endregion

        private ClinicManagement.Features.Examination.SubForms.WaitingPatientTable danhSachChoKham;
    }
}
