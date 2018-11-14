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
            this.tableDataView1 = new ClinicManagement.Common.ClinicComponents.TableDataView();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableDataView1
            // 
            this.tableDataView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableDataView1.Columns = new ClinicManagement.Common.ClinicComponents.ColumnTypes[] {
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Name,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.BirthDay,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Sex,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.IdentifyCardNumber,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Address,
        ClinicManagement.Common.ClinicComponents.ColumnTypes.Note};
            this.tableDataView1.Location = new System.Drawing.Point(0, 81);
            this.tableDataView1.Name = "tableDataView1";
            this.tableDataView1.Size = new System.Drawing.Size(869, 572);
            this.tableDataView1.TabIndex = 0;
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.White;
            this.btnDetail.Image = global::ClinicManagement.Properties.Resources.ico_detail;
            this.btnDetail.Location = new System.Drawing.Point(124, 30);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(45, 45);
            this.btnDetail.TabIndex = 3;
            this.btnDetail.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Image = global::ClinicManagement.Properties.Resources.ico_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(186, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(45, 45);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::ClinicManagement.Properties.Resources.ico_add_24;
            this.btnAdd.Location = new System.Drawing.Point(64, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 45);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::ClinicManagement.Properties.Resources.ico_search_24;
            this.btnSearch.Location = new System.Drawing.Point(3, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(45, 45);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // ReceptionHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tableDataView1);
            this.Name = "ReceptionHome";
            this.Size = new System.Drawing.Size(869, 653);
            this.Load += new System.EventHandler(this.ReceptionHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.ClinicComponents.TableDataView tableDataView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnRefresh;
    }
}
