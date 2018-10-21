namespace ClinicManagement.Features.Reception.SubForms
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
            this.components = new System.ComponentModel.Container();
            this.newTextField1 = new Components.Common.NewTextField();
            this.newButton1 = new Components.Common.NewButton(this.components);
            this.SuspendLayout();
            // 
            // newTextField1
            // 
            this.newTextField1.AutoSize = true;
            this.newTextField1.BackColor = System.Drawing.Color.White;
            this.newTextField1.Icon = global::ClinicManagement.Properties.Resources.ico_key_24;
            this.newTextField1.Location = new System.Drawing.Point(14, 14);
            this.newTextField1.Name = "newTextField1";
            this.newTextField1.PlaceHolder = "Place Holder";
            this.newTextField1.PlaceHolderColor = System.Drawing.Color.LightGray;
            this.newTextField1.Radius = 16;
            this.newTextField1.Size = new System.Drawing.Size(340, 33);
            this.newTextField1.TabIndex = 0;
            this.newTextField1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // newButton1
            // 
            this.newButton1.FlatAppearance.BorderSize = 0;
            this.newButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newButton1.Location = new System.Drawing.Point(369, 14);
            this.newButton1.Name = "newButton1";
            this.newButton1.Radius = 20;
            this.newButton1.Size = new System.Drawing.Size(81, 33);
            this.newButton1.TabIndex = 1;
            this.newButton1.Text = "newButton1";
            this.newButton1.UseVisualStyleBackColor = true;
            // 
            // FilterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newButton1);
            this.Controls.Add(this.newTextField1);
            this.Name = "FilterUserControl";
            this.Size = new System.Drawing.Size(630, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Common.NewTextField newTextField1;
        private Components.Common.NewButton newButton1;
    }
}
