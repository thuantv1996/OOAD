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
    public partial class FormHoSo : Form
    {
        public DataReportPhieuKhamBenh DataReport { get; set; }
        public FormHoSo()
        {
            InitializeComponent();
        }

        private void FormHoSo_Load(object sender, EventArgs e)
        {
            string connection = ConnectionDatabase.GetConnection();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetDonThuoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ResultsTable = new DataTable();
            adapter.Fill(ResultsTable);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ResultsTable));


            ReportParameter[] arParam = new ReportParameter[9];
            arParam[0] = new ReportParameter("TenBenhNhan", DataReport.TenBenhNhan);
            arParam[1] = new ReportParameter("DiaChi", DataReport.DiaChi);
            arParam[2] = new ReportParameter("TenBacSi", DataReport.TenBacSi);
            arParam[3] = new ReportParameter("ChieuChung", DataReport.ChieuChung);
            arParam[4] = new ReportParameter("NgayKham", DataReport.NgayKham);
            arParam[5] = new ReportParameter("SDTBenhNhan", DataReport.SDTBenhNhan);
            arParam[6] = new ReportParameter("NgaySinh", DataReport.NgaySinh);
            arParam[7] = new ReportParameter("ChuanDoan", DataReport.ChuanDoan);
            arParam[8] = new ReportParameter("MaHoSo", DataReport.MaHoSo);
            reportViewer1.LocalReport.SetParameters(arParam);


            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
