using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report
{
    public partial class FormThanhToan : Form
    {
        public DataReportThanhToan DataReport { get; set; }
        public FormThanhToan()
        {
            InitializeComponent();
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            string connection = ConnectionDatabase.GetConnection();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetThanhToan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaHS", DataReport.MaHoSo));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ResultsTable = new DataTable();
            adapter.Fill(ResultsTable);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ResultsTable));
            ReportParameter[] arParam = new ReportParameter[7];
            arParam[0] = new ReportParameter("NgayKham", DataReport.NgayKham);
            arParam[1] = new ReportParameter("TenBenhNhan", DataReport.TenBenhNhan);
            arParam[2] = new ReportParameter("NgaySinh", DataReport.NgaySinh);
            arParam[3] = new ReportParameter("DiaChi", DataReport.DiaChi);
            arParam[4] = new ReportParameter("MaHoSo", DataReport.MaHoSo);
            arParam[5] = new ReportParameter("ChiPhiKham", DataReport.ChiPhiKham);
            arParam[6] = new ReportParameter("TongChiPhi", DataReport.TongChiPhi);
            reportViewer1.LocalReport.SetParameters(arParam);
            this.reportViewer1.RefreshReport();
        }
    }
}
