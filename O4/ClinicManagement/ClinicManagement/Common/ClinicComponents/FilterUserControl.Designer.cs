﻿using Components.NewControl;

namespace ClinicManagement.Common.ClinicComponents
{
    partial class FilterUserControl
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
            this.txtMaBenh = new Components.NewControl.NewTextField();
            this.txtHoTen = new Components.NewControl.NewTextField();
            this.txtCMND = new Components.NewControl.NewTextField();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMaBenh
            // 
            this.txtMaBenh.AutoSize = true;
            this.txtMaBenh.BackColor = System.Drawing.Color.White;
            this.txtMaBenh.Icon = global::ClinicManagement.Properties.Resources.ico_search_24;
            this.txtMaBenh.Location = new System.Drawing.Point(17, 23);
            this.txtMaBenh.Name = "txtMaBenh";
            this.txtMaBenh.PlaceHolder = "Mã bệnh nhân";
            this.txtMaBenh.PlaceHolderColor = System.Drawing.Color.Silver;
            this.txtMaBenh.Radius = 3;
            this.txtMaBenh.Size = new System.Drawing.Size(209, 35);
            this.txtMaBenh.TabIndex = 0;
            this.txtMaBenh.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtHoTen
            // 
            this.txtHoTen.AutoSize = true;
            this.txtHoTen.BackColor = System.Drawing.Color.White;
            this.txtHoTen.Icon = null;
            this.txtHoTen.Location = new System.Drawing.Point(234, 23);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.PlaceHolder = "Tên bệnh nhân";
            this.txtHoTen.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtHoTen.Radius = 3;
            this.txtHoTen.Size = new System.Drawing.Size(209, 35);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtCMND
            // 
            this.txtCMND.AutoSize = true;
            this.txtCMND.BackColor = System.Drawing.Color.White;
            this.txtCMND.Icon = null;
            this.txtCMND.Location = new System.Drawing.Point(451, 23);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.PlaceHolder = "CMND/Passport";
            this.txtCMND.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.txtCMND.Radius = 3;
            this.txtCMND.Size = new System.Drawing.Size(209, 35);
            this.txtCMND.TabIndex = 2;
            this.txtCMND.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(668, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // FilterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMaBenh);
            this.Name = "FilterUserControl";
            this.Size = new System.Drawing.Size(785, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NewTextField txtMaBenh;
        private NewTextField txtHoTen;
        private NewTextField txtCMND;
        private System.Windows.Forms.Button btnSearch;
    }
}