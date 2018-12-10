using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Examination.SubForms
{
    public partial class WaitingPatientTable : UserControl
    {
        public WaitingPatientTable()
        {
            InitializeComponent();
        }

        public void binding(List<Model.HoSoBenhAnView> list)
        {
            if (this.gridControl1.InvokeRequired)
                this.Invoke(new Action<List<Model.HoSoBenhAnView>>(binding), new object[] { list });
            else
                this.gridControl1.DataSource = Common.ClinicBus.ConvertToDatatable(list);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshClick?.Invoke(this, e);
        }


        private void btnAccess_Click(object sender, EventArgs e)
        {
            int selectedIntexRow = this.gridView1.GetSelectedRows().First();
            DataRow row = this.gridView1.GetDataRow(selectedIntexRow);
            var hoso = new Model.HoSoBenhAnView()
            {
                MaHoSo = row[col_MaHoSo.FieldName].ToString(),
                MaBenhNhan = row[col_MaBenhNhan.FieldName].ToString(),
                HoTen = row[col_HoTen.FieldName].ToString(),
                CMND = row[col_CMND.FieldName].ToString(),
                SoDienThoai = row[col_Sdt.FieldName].ToString(),
                SoThuTu = (int)row[col_STT.FieldName]
            };
            this.AccessClick?.Invoke(this, hoso);
        }
        

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int selectedIntexRow = this.gridView1.GetSelectedRows().First();
            DataRow row = this.gridView1.GetDataRow(selectedIntexRow);
            var hoso = new Model.HoSoBenhAnView()
            {
                MaHoSo = row[col_MaHoSo.FieldName].ToString(),
                MaBenhNhan = row[col_MaBenhNhan.FieldName].ToString(),
                HoTen = row[col_HoTen.FieldName].ToString(),
                CMND = row[col_CMND.FieldName].ToString(),
                SoDienThoai = row[col_Sdt.FieldName].ToString(),
                SoThuTu = (int)row[col_STT.FieldName]
            };
            this.AccessClick?.Invoke(this, hoso);
        }

        public event EventHandler RefreshClick;
        public event EventHandler<Model.HoSoBenhAnView> AccessClick;

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
