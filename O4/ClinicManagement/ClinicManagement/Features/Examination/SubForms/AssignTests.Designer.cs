namespace ClinicManagement.Features.Examination.SubForms
{
    partial class AssignTests
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbLoaiXetNghiem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkListXetNghiem = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiXetNghiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkListXetNghiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại xét nghiệm:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(571, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbLoaiXetNghiem
            // 
            this.cbLoaiXetNghiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLoaiXetNghiem.Location = new System.Drawing.Point(147, 21);
            this.cbLoaiXetNghiem.Name = "cbLoaiXetNghiem";
            this.cbLoaiXetNghiem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbLoaiXetNghiem.Properties.Appearance.Options.UseFont = true;
            this.cbLoaiXetNghiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLoaiXetNghiem.Size = new System.Drawing.Size(410, 28);
            this.cbLoaiXetNghiem.TabIndex = 2;
            // 
            // checkListXetNghiem
            // 
            this.checkListXetNghiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkListXetNghiem.Location = new System.Drawing.Point(0, 65);
            this.checkListXetNghiem.Name = "checkListXetNghiem";
            this.checkListXetNghiem.Size = new System.Drawing.Size(659, 423);
            this.checkListXetNghiem.TabIndex = 3;
            // 
            // AssignTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkListXetNghiem);
            this.Controls.Add(this.cbLoaiXetNghiem);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(539, 283);
            this.Name = "AssignTests";
            this.Size = new System.Drawing.Size(659, 488);
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiXetNghiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkListXetNghiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private DevExpress.XtraEditors.ComboBoxEdit cbLoaiXetNghiem;
        private DevExpress.XtraEditors.CheckedListBoxControl checkListXetNghiem;
    }
}
