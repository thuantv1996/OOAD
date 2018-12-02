using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Reception.SubForms
{
    public partial class PreviousRecordsTable : UserControl
    {
        //MARK: - Properties
        private Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;
        private string maBenhNhan;
        public PreviousRecordsTable(string MaBenhNhan)
        {
            InitializeComponent();
            this.maBenhNhan = MaBenhNhan;
            this.bus.getListHoSoByBenhNhan(MaBenhNhan, (listHoSo, result) =>
            {
                this.fillData(listHoSo);
            });
            this.setupView();
        }

        private void setupView()
        {
            var enterHandler = new KeyEventHandler((sender, e) => 
            {
                if (e.KeyCode == Keys.Enter)
                    this.search();
            });
            this.txtLoaiHoSo.TextBox.KeyUp += enterHandler;
            this.txtMaHoSo.TextBox.KeyUp += enterHandler;
            this.txtNguoiTiepNhan.TextBox.KeyUp += enterHandler;

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.search();
        }

        private void search()
        {
            var hoso = new Model.HoSoTruocView()
            {
                MaHoSo = txtMaHoSo.Text,
                LoaiHoSo = txtLoaiHoSo.Text,
                NguoiTiepNhan = txtNguoiTiepNhan.Text
            };

            this.bus.searchHoSoTruoc(this.maBenhNhan, hoso, (listResult, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                    this.fillData(listResult);
            });
        }

        private void fillData(List<Model.HoSoTruocView> list)
        {
            this.grd_Table.DataSource = Common.ClinicBus.ConvertToDatatable(list);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int selectedIntexRow = this.gridView1.GetSelectedRows().First();
            DataRow row = this.gridView1.GetDataRow(selectedIntexRow);
            this.DoubleToChoose?.Invoke(this, row["MaHoSo"].ToString());
        }

        public event EventHandler<string> DoubleToChoose;
    }
}
