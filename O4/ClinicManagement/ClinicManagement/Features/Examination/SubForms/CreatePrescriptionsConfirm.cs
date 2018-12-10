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
    public partial class CreatePrescriptionsConfirm : Model.ConfirmUserControl
    {
        private DTO.HoSoBenhAnDTO hoso;
        private List<DTO.ChiTietDonThuocDTO> danhSachThuoc;
        private decimal chiPhi;
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;


        public CreatePrescriptionsConfirm(DTO.HoSoBenhAnDTO benhAn, List<DTO.ChiTietDonThuocDTO> danhSachThuoc, decimal chiPhi)
        {
            InitializeComponent();
            this.hoso = benhAn;
            this.danhSachThuoc = danhSachThuoc;
            this.chiPhi = chiPhi;
            this.setup();
        }

        private void setup()
        {
            var list = new List<Model.ThuocView>();
            
            danhSachThuoc.ForEach(thuoc =>
            {
                var medicine = this.bus.getThuoc(thuoc.MaThuoc);
                list.Add(new Model.ThuocView()
                {
                    MaThuoc = thuoc.MaThuoc,
                    SoLuong = thuoc.SoLuong,
                    TenThuoc = medicine != null ? medicine.TenThuoc : "",
                    GhiChu = thuoc.GhiChu
                });
            });

            this.gridControl1.DataSource = Common.ClinicBus.ConvertToDatatable(list);

            var benhNhan = this.bus.getBenhNhan(hoso.MaBenhNhan);
            this.patientMainInformation1.binding(benhNhan);

            this.txtChuanDoan.Text = this.hoso.ChuanDoan;
            this.txtChiPhi.Text = string.Format("{0} VND", this.chiPhi);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.bus.confirmExaminationWithoutAssignTests(this.hoso, danhSachThuoc, result =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                    this.InvokeConfirm(this, e);
            });
        }
    }
}
