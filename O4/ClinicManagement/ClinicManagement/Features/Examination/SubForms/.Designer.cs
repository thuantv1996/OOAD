namespace ClinicManagement.Features.Examination.SubForms
{
    partial class MedicalExamination
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtChiPhi = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lnkDonThuocGanNhat = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtYeuCauKham = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChuanDoanBenh = new ClinicManagement.Common.ClinicComponents.RichTextBoxWithLine(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.patientMainInformation = new ClinicManagement.Common.ClinicComponents.PatientMainInformation();
            this.radioLayout = new System.Windows.Forms.TableLayoutPanel();
            this.radXetNghiem = new System.Windows.Forms.RadioButton();
            this.radKeThuoc = new System.Windows.Forms.RadioButton();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.btnXacNhan.Enabled = false;
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
            this.mainPanel.Controls.Add(this.lnkDonThuocGanNhat);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.txtChuanDoanBenh);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.patientMainInformation);
            this.mainPanel.Controls.Add(this.radioLayout);
            this.mainPanel.Location = new System.Drawing.Point(12, 17);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(802, 522);
            this.mainPanel.TabIndex = 5;
            // 
            // lnkDonThuocGanNhat
            // 
            this.lnkDonThuocGanNhat.AutoSize = true;
            this.lnkDonThuocGanNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDonThuocGanNhat.Location = new System.Drawing.Point(4, 146);
            this.lnkDonThuocGanNhat.Name = "lnkDonThuocGanNhat";
            this.lnkDonThuocGanNhat.Size = new System.Drawing.Size(154, 20);
            this.lnkDonThuocGanNhat.TabIndex = 13;
            this.lnkDonThuocGanNhat.TabStop = true;
            this.lnkDonThuocGanNhat.Text = "Đơn thuốc gần nhất";
            this.lnkDonThuocGanNhat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDonThuocGanNhat_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtYeuCauKham);
            this.panel1.Location = new System.Drawing.Point(7, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 98);
            this.panel1.TabIndex = 11;
            // 
            // txtYeuCauKham
            // 
            this.txtYeuCauKham.AutoSize = true;
            this.txtYeuCauKham.Location = new System.Drawing.Point(3, 0);
            this.txtYeuCauKham.MaximumSize = new System.Drawing.Size(780, 0);
            this.txtYeuCauKham.Name = "txtYeuCauKham";
            this.txtYeuCauKham.Size = new System.Drawing.Size(0, 17);
            this.txtYeuCauKham.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Yêu cầu khám:";
            // 
            // txtChuanDoanBenh
            // 
            this.txtChuanDoanBenh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChuanDoanBenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChuanDoanBenh.Location = new System.Drawing.Point(4, 333);
            this.txtChuanDoanBenh.Name = "txtChuanDoanBenh";
            this.txtChuanDoanBenh.Size = new System.Drawing.Size(792, 96);
            this.txtChuanDoanBenh.TabIndex = 9;
            this.txtChuanDoanBenh.Text = "-  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 313);
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
            // radioLayout
            // 
            this.radioLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioLayout.ColumnCount = 2;
            this.radioLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.radioLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.radioLayout.Controls.Add(this.radXetNghiem, 0, 0);
            this.radioLayout.Controls.Add(this.radKeThuoc, 1, 0);
            this.radioLayout.Location = new System.Drawing.Point(4, 449);
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
            // MedicalExamination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtChiPhi);
            this.Controls.Add(this.label2);
            this.Name = "MedicalExamination";
            this.Size = new System.Drawing.Size(826, 615);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ExaminationHome_ControlRemoved);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private Common.ClinicComponents.RichTextBoxWithLine txtChuanDoanBenh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtYeuCauKham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkDonThuocGanNhat;
    }
}
