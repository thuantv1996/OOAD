namespace Components.Common
{
    partial class NewTextField
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
            this.panelIcon = new System.Windows.Forms.Panel();
            this.icon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panelIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIcon
            // 
            this.panelIcon.Controls.Add(this.icon);
            this.panelIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIcon.Location = new System.Drawing.Point(0, 0);
            this.panelIcon.Name = "panelIcon";
            this.panelIcon.Size = new System.Drawing.Size(37, 37);
            this.panelIcon.TabIndex = 0;
            // 
            // icon
            // 
            this.icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icon.Location = new System.Drawing.Point(0, 0);
            this.icon.Name = "icon";
            this.icon.Padding = new System.Windows.Forms.Padding(5);
            this.icon.Size = new System.Drawing.Size(37, 37);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(37, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 37);
            this.panel1.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(0, 8);
            this.textBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(267, 21);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "test";
            // 
            // NewTextField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelIcon);
            this.Name = "NewTextField";
            this.Size = new System.Drawing.Size(304, 37);
            this.panelIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelIcon;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox;
    }
}
