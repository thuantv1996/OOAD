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
            this.panelResult = new System.Windows.Forms.Panel();
            this.groupResult = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtYeuCauKham = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPhong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkDonThuocGanNhat = new System.Windows.Forms.LinkLabel();
            this.btnCreateMedical = new System.Windows.Forms.Button();
            this.btnAssignTests = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtTrieuChung = new ClinicManagement.Common.ClinicComponents.RichTextBoxWithLine(this.components);
            this.txtChuanDoanBenh = new ClinicManagement.Common.ClinicComponents.RichTextBoxWithLine(this.components);
            this.patientMainInformation = new ClinicManagement.Common.ClinicComponents.PatientMainInformation();
            this.cbBacSi = new System.Windows.Forms.ComboBox();
            this.mainPanel.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 686);
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
            this.txtChiPhi.Location = new System.Drawing.Point(164, 686);
            this.txtChiPhi.Name = "txtChiPhi";
            this.txtChiPhi.Size = new System.Drawing.Size(59, 20);
            this.txtChiPhi.TabIndex = 3;
            this.txtChiPhi.Text = "0 VND";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(802, 677);
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
            this.mainPanel.Controls.Add(this.groupBox5);
            this.mainPanel.Controls.Add(this.panelResult);
            this.mainPanel.Controls.Add(this.groupBox4);
            this.mainPanel.Controls.Add(this.groupBox3);
            this.mainPanel.Controls.Add(this.groupBox2);
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Controls.Add(this.lnkDonThuocGanNhat);
            this.mainPanel.Location = new System.Drawing.Point(12, 17);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(947, 641);
            this.mainPanel.TabIndex = 5;
            // 
            // panelResult
            // 
            this.panelResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelResult.Controls.Add(this.groupResult);
            this.panelResult.Location = new System.Drawing.Point(11, 677);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(903, 280);
            this.panelResult.TabIndex = 19;
            // 
            // groupResult
            // 
            this.groupResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupResult.Location = new System.Drawing.Point(1, 3);
            this.groupResult.Name = "groupResult";
            this.groupResult.Size = new System.Drawing.Size(899, 250);
            this.groupResult.TabIndex = 18;
            this.groupResult.TabStop = false;
            this.groupResult.Text = "Xét nghiệm";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Location = new System.Drawing.Point(12, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(903, 111);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Yêu cầu khám:";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtYeuCauKham);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 90);
            this.panel2.TabIndex = 0;
            // 
            // txtYeuCauKham
            // 
            this.txtYeuCauKham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYeuCauKham.AutoSize = true;
            this.txtYeuCauKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYeuCauKham.Location = new System.Drawing.Point(2, 0);
            this.txtYeuCauKham.MaximumSize = new System.Drawing.Size(1004, 0);
            this.txtYeuCauKham.Name = "txtYeuCauKham";
            this.txtYeuCauKham.Size = new System.Drawing.Size(0, 18);
            this.txtYeuCauKham.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtChuanDoanBenh);
            this.groupBox3.Location = new System.Drawing.Point(12, 541);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(902, 114);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chuẩn đoán:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(9, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(906, 85);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phòng";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 64);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.1F));
            this.tableLayoutPanel1.Controls.Add(this.txtPhong, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbBacSi, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(898, 62);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtPhong
            // 
            this.txtPhong.AutoSize = true;
            this.txtPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhong.Location = new System.Drawing.Point(136, 31);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(759, 31);
            this.txtPhong.TabIndex = 3;
            this.txtPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phòng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bác sĩ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.patientMainInformation);
            this.groupBox1.Location = new System.Drawing.Point(9, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 128);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bệnh nhân";
            // 
            // lnkDonThuocGanNhat
            // 
            this.lnkDonThuocGanNhat.AutoSize = true;
            this.lnkDonThuocGanNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDonThuocGanNhat.Location = new System.Drawing.Point(9, 146);
            this.lnkDonThuocGanNhat.Name = "lnkDonThuocGanNhat";
            this.lnkDonThuocGanNhat.Size = new System.Drawing.Size(154, 20);
            this.lnkDonThuocGanNhat.TabIndex = 13;
            this.lnkDonThuocGanNhat.TabStop = true;
            this.lnkDonThuocGanNhat.Text = "Đơn thuốc gần nhất";
            this.lnkDonThuocGanNhat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDonThuocGanNhat_LinkClicked);
            // 
            // btnCreateMedical
            // 
            this.btnCreateMedical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateMedical.BackColor = System.Drawing.Color.White;
            this.btnCreateMedical.Location = new System.Drawing.Point(639, 677);
            this.btnCreateMedical.Name = "btnCreateMedical";
            this.btnCreateMedical.Size = new System.Drawing.Size(157, 40);
            this.btnCreateMedical.TabIndex = 6;
            this.btnCreateMedical.Text = "Kê thuốc";
            this.btnCreateMedical.UseVisualStyleBackColor = false;
            this.btnCreateMedical.Click += new System.EventHandler(this.btnCreateMedical_Click);
            // 
            // btnAssignTests
            // 
            this.btnAssignTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignTests.BackColor = System.Drawing.Color.White;
            this.btnAssignTests.Location = new System.Drawing.Point(476, 677);
            this.btnAssignTests.Name = "btnAssignTests";
            this.btnAssignTests.Size = new System.Drawing.Size(157, 40);
            this.btnAssignTests.TabIndex = 7;
            this.btnAssignTests.Text = "Chỉ định xét nghiệm";
            this.btnAssignTests.UseVisualStyleBackColor = false;
            this.btnAssignTests.Click += new System.EventHandler(this.btnAssignTests_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtTrieuChung);
            this.groupBox5.Location = new System.Drawing.Point(13, 405);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(902, 114);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Triệu chứng:";
            // 
            // txtTrieuChung
            // 
            this.txtTrieuChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrieuChung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrieuChung.Location = new System.Drawing.Point(3, 18);
            this.txtTrieuChung.Name = "txtTrieuChung";
            this.txtTrieuChung.Size = new System.Drawing.Size(896, 93);
            this.txtTrieuChung.TabIndex = 9;
            this.txtTrieuChung.Text = "-  ";
            // 
            // txtChuanDoanBenh
            // 
            this.txtChuanDoanBenh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChuanDoanBenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChuanDoanBenh.Location = new System.Drawing.Point(3, 18);
            this.txtChuanDoanBenh.Name = "txtChuanDoanBenh";
            this.txtChuanDoanBenh.Size = new System.Drawing.Size(896, 93);
            this.txtChuanDoanBenh.TabIndex = 9;
            this.txtChuanDoanBenh.Text = "-  ";
            // 
            // patientMainInformation
            // 
            this.patientMainInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientMainInformation.Location = new System.Drawing.Point(3, 18);
            this.patientMainInformation.Name = "patientMainInformation";
            this.patientMainInformation.Size = new System.Drawing.Size(900, 107);
            this.patientMainInformation.TabIndex = 6;
            // 
            // cbBacSi
            // 
            this.cbBacSi.FormattingEnabled = true;
            this.cbBacSi.Location = new System.Drawing.Point(136, 3);
            this.cbBacSi.Name = "cbBacSi";
            this.cbBacSi.Size = new System.Drawing.Size(759, 24);
            this.cbBacSi.TabIndex = 4;
            // 
            // MedicalExamination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAssignTests);
            this.Controls.Add(this.btnCreateMedical);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtChiPhi);
            this.Controls.Add(this.label2);
            this.Name = "MedicalExamination";
            this.Size = new System.Drawing.Size(971, 734);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ExaminationHome_ControlRemoved);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtChiPhi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Panel mainPanel;
        private Common.ClinicComponents.PatientMainInformation patientMainInformation;
        private Common.ClinicComponents.RichTextBoxWithLine txtChuanDoanBenh;
        private System.Windows.Forms.LinkLabel lnkDonThuocGanNhat;
        private System.Windows.Forms.Button btnCreateMedical;
        private System.Windows.Forms.Button btnAssignTests;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtYeuCauKham;
        private System.Windows.Forms.GroupBox groupResult;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.GroupBox groupBox5;
        private Common.ClinicComponents.RichTextBoxWithLine txtTrieuChung;
        private System.Windows.Forms.ComboBox cbBacSi;
    }
}
