using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Report.Windows
{
    public partial class ThanhToanReport : Form
    {
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        public ThanhToanReport()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // ThanhToanReport
            // 
            this.ClientSize = new System.Drawing.Size(739, 337);
            this.Name = "ThanhToanReport";
            this.ResumeLayout(false);

        }
    }
}
