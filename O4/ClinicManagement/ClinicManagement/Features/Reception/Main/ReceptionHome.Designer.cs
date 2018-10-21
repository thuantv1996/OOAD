namespace ClinicManagement.Features.Reception.Main
{
    partial class ReceptionHome
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
            this.tableDataView1 = new ClinicManagement.Common.Components.TableDataView();
            this.filterUserControl1 = new ClinicManagement.Features.Reception.SubForms.FilterUserControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.filterUserControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 152);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableDataView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 501);
            this.panel2.TabIndex = 1;
            // 
            // tableDataView1
            // 
            this.tableDataView1.Columns = new ClinicManagement.Common.Components.ColumnTypes[] {
        ClinicManagement.Common.Components.ColumnTypes.Name,
        ClinicManagement.Common.Components.ColumnTypes.BirthDay,
        ClinicManagement.Common.Components.ColumnTypes.Sex,
        ClinicManagement.Common.Components.ColumnTypes.IdentifyCardNumber,
        ClinicManagement.Common.Components.ColumnTypes.Address,
        ClinicManagement.Common.Components.ColumnTypes.Note};
            this.tableDataView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDataView1.Location = new System.Drawing.Point(0, 0);
            this.tableDataView1.Name = "tableDataView1";
            this.tableDataView1.Size = new System.Drawing.Size(869, 501);
            this.tableDataView1.TabIndex = 0;
            // 
            // filterUserControl1
            // 
            this.filterUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterUserControl1.Location = new System.Drawing.Point(0, 0);
            this.filterUserControl1.Name = "filterUserControl1";
            this.filterUserControl1.Size = new System.Drawing.Size(869, 152);
            this.filterUserControl1.TabIndex = 0;
            // 
            // ReceptionHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ReceptionHome";
            this.Size = new System.Drawing.Size(869, 653);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Common.Components.TableDataView tableDataView1;
        private SubForms.FilterUserControl filterUserControl1;
    }
}
