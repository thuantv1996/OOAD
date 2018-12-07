namespace ClinicManagement.Features.Examination.SubForms
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtChiPhi = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.patientMainInformation = new ClinicManagement.Common.ClinicComponents.PatientMainInformation();
            this.radioLayout = new System.Windows.Forms.TableLayoutPanel();
            this.radXetNghiem = new System.Windows.Forms.RadioButton();
            this.radKeThuoc = new System.Windows.Forms.RadioButton();
            this.mainPanel.SuspendLayout();
            this.radioLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 567);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tổng chi phí khám:";
            // 
            // txtChiPhi
            // 
            this.txtChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChiPhi.AutoSize = true;
            this.txtChiPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiPhi.Location = new System.Drawing.Point(164, 567);
            this.txtChiPhi.Name = "txtChiPhi";
            this.txtChiPhi.Size = new System.Drawing.Size(108, 20);
            this.txtChiPhi.TabIndex = 3;
            this.txtChiPhi.Text = "120.000 VND";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(657, 558);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(157, 40);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.patientMainInformation);
            this.mainPanel.Controls.Add(this.radioLayout);
            this.mainPanel.Location = new System.Drawing.Point(12, 17);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(802, 522);
            this.mainPanel.TabIndex = 5;
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
            // radioLayout
            // 
            this.radioLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioLayout.ColumnCount = 2;
            this.radioLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.radioLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.radioLayout.Controls.Add(this.radXetNghiem, 0, 0);
            this.radioLayout.Controls.Add(this.radKeThuoc, 1, 0);
            this.radioLayout.Location = new System.Drawing.Point(5, 149);
            this.radioLayout.Name = "radioLayout";
            this.radioLayout.RowCount = 1;
            this.radioLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.radioLayout.Size = new System.Drawing.Size(790, 36);
            this.radioLayout.TabIndex = 5;
            // 
            // radXetNghiem
            // 
            this.radXetNghiem.AutoSize = true;
            this.radXetNghiem.Checked = true;
            this.radXetNghiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radXetNghiem.Location = new System.Drawing.Point(3, 3);
            this.radXetNghiem.Name = "radXetNghiem";
            this.radXetNghiem.Size = new System.Drawing.Size(389, 30);
            this.radXetNghiem.TabIndex = 3;
            this.radXetNghiem.TabStop = true;
            this.radXetNghiem.Text = "Xét nghiệm";
            this.radXetNghiem.UseVisualStyleBackColor = true;
            this.radXetNghiem.CheckedChanged += new System.EventHandler(this.radXetNghiem_CheckedChanged);
            // 
            // radKeThuoc
            // 
            this.radKeThuoc.AutoSize = true;
            this.radKeThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radKeThuoc.Location = new System.Drawing.Point(398, 3);
            this.radKeThuoc.Name = "radKeThuoc";
            this.radKeThuoc.Size = new System.Drawing.Size(389, 30);
            this.radKeThuoc.TabIndex = 4;
            this.radKeThuoc.Text = "Kê thuốc";
            this.radKeThuoc.UseVisualStyleBackColor = true;
            this.radKeThuoc.CheckedChanged += new System.EventHandler(this.radKeThuoc_CheckedChanged);
            // 
            // ExaminationHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtChiPhi);
            this.Controls.Add(this.label2);
            this.Name = "ExaminationHome";
            this.Size = new System.Drawing.Size(826, 615);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ExaminationHome_ControlRemoved);
            this.mainPanel.ResumeLayout(false);
            this.radioLayout.ResumeLayout(false);
            this.radioLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtChiPhi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel radioLayout;
        private System.Windows.Forms.RadioButton radXetNghiem;
        private System.Windows.Forms.RadioButton radKeThuoc;
        private Common.ClinicComponents.PatientMainInformation patientMainInformation;
    }
}
