using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report
{
    public partial class FormSoThuTu : Form
    {
        public DataReportSoThuTu DataReport { get; set; }
        public FormSoThuTu()
        {
            InitializeComponent();
        }

        private void FormSoThuTu_Load(object sender, EventArgs e)
        {
            //string connection = ConnectionDatabase.GetConnection();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", new DataTable()));
            ReportParameter[] arParam = new ReportParameter[6];
            arParam[0] = new ReportParameter("MaHoSo", DataReport.MaHoSo);
            arParam[1] = new ReportParameter("TenBenhNhan", DataReport.TenBenhNhan);
            arParam[2] = new ReportParameter("DiaChi", DataReport.DiaChi);
            arParam[3] = new ReportParameter("NgayKham", DataReport.NgayKham);
            arParam[4] = new ReportParameter("SoThuTu", DataReport.SoThuTu);
            arParam[5] = new ReportParameter("TenPhong", DataReport.TenPhong);
            reportViewer1.LocalReport.SetParameters(arParam);
            this.reportViewer1.RefreshReport();
        }
    }
}
