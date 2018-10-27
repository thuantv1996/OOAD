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
            this.tableDataWithSearch = new ClinicManagement.Common.ClinicComponents.TableDataWithSearch();
            this.SuspendLayout();
            // 
            // tableDataWithSearch
            // 
            this.tableDataWithSearch.Columns = new ClinicManagement.Common.ClinicComponents.ColumnTypes[] {
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Name,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.BirthDay,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Sex,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.IdentifyCardNumber,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Address,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Note};
            this.tableDataWithSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDataWithSearch.Location = new System.Drawing.Point(0, 0);
            this.tableDataWithSearch.Name = "tableDataWithSearch";
            this.tableDataWithSearch.Size = new System.Drawing.Size(869, 653);
            this.tableDataWithSearch.TabIndex = 0;
            // 
            // ReceptionHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableDataWithSearch);
            this.Name = "ReceptionHome";
            this.Size = new System.Drawing.Size(869, 653);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.ClinicComponents.TableDataWithSearch tableDataWithSearch;
    }
}
