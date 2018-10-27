namespace ClinicManagement.Common.ClinicComponents
{
    partial class TableDataWithSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableControl = new ClinicManagement.Common.ClinicComponents.TableDataView();
            this.filterUserControl = new ClinicManagement.Common.ClinicComponents.FilterUserControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.filterUserControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 90);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 412);
            this.panel2.TabIndex = 1;
            // 
            // tableControl
            // 
            this.tableControl.Columns = new ClinicManagement.Common.ClinicComponents.ColumnTypes[] {
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Name,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.BirthDay,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Sex,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.IdentifyCardNumber,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Address,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Note};
            this.tableControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableControl.Location = new System.Drawing.Point(0, 0);
            this.tableControl.Name = "tableControl";
            this.tableControl.Size = new System.Drawing.Size(808, 412);
            this.tableControl.TabIndex = 0;
            // 
            // filterUserControl
            // 
            this.filterUserControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.filterUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterUserControl.Location = new System.Drawing.Point(0, 0);
            this.filterUserControl.Name = "filterUserControl";
            this.filterUserControl.Size = new System.Drawing.Size(808, 90);
            this.filterUserControl.TabIndex = 0;
            // 
            // TableDataWithSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TableDataWithSearch";
            this.Size = new System.Drawing.Size(808, 502);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private TableDataView tableControl;
        private FilterUserControl filterUserControl;
    }
}
