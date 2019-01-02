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
    public partial class AssignTestsConfirm : Model.ConfirmUserControl
    {
        public class XetNghiemView
        {
            public string MaXetNghiem { get; set; }
            public string TenXetNghiem { get; set; }
            public string MaPhong { get; set; }
            public string TenPhong { get; set; }
        }

        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        private List<DTO.XetNghiemDTO> danhSachXetNghiem;
        private DTO.HoSoBenhAnDTO hoso;
        private decimal chiPhi;

        public AssignTestsConfirm(DTO.HoSoBenhAnDTO hoso, List<DTO.XetNghiemDTO> danhSachXetNghiem, decimal chiPhi)
        {
            InitializeComponent();
            this.danhSachXetNghiem = danhSachXetNghiem;
            this.hoso = hoso;
            this.chiPhi = chiPhi;
            this.setup();
        }

        private void setup()
        {
            var list = new List<XetNghiemView>();
            this.danhSachXetNghiem.ForEach(xn =>
            {
                var xetNghiem = this.bus.getXetNghiem(xn.MaXetNghiem);
                var phong = this.bus.getPhong(xn.MaPhong);
                list.Add(new XetNghiemView()
                {
                    MaXetNghiem = xn.MaXetNghiem,
                    MaPhong = xn.MaPhong,
                    TenXetNghiem = xetNghiem.TenXetNghiem,
                    TenPhong = phong.TenPhong
                });
            });

            var data = Common.ClinicBus.ConvertToDatatable(list);
            this.gridControl1.DataSource = data;

            var benhNhan = this.bus.getBenhNhan(hoso.MaBenhNhan);
            this.patientMainInformation1.binding(benhNhan);

            this.txtChuanDoan.Text = this.hoso.ChuanDoan;

            this.txtChiPhi.Text = String.Format("{0} VND", this.chiPhi);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var listKQXN = new List<DTO.KetQuaXetNghiemDTO>();
            danhSachXetNghiem.ForEach(xn =>
            {
                listKQXN.Add(new DTO.KetQuaXetNghiemDTO()
                {
                    MaHoSo = hoso.MaHoSo,
                    MaXetNghiem = xn.MaXetNghiem,
                    ThanhToan = false,
                    TongChiPhi = chiPhi
                });
            });
            this.bus.assignTests(listKQXN, result =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.InvokeConfirm(this, e);
                }
            });
        }
    }
}
