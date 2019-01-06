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
        private List<DTO.ChiTietDonThuocDTO> danhSachThuoc;
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;

        public List<DTO.ChiTietDonThuocDTO> DanhSachThuoc
        {
            get
            {
                return this.danhSachThuoc;
            }
        }

        public event EventHandler ClearEvent;

        public CreatePrescriptionsConfirm(List<DTO.ChiTietDonThuocDTO> danhSachThuoc, bool isConfirm = false)
        {
            InitializeComponent();
            this.danhSachThuoc = danhSachThuoc;
            this.setup();
            this.btnClear.Visible = !isConfirm;
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearEvent?.Invoke(this, e);
        }

        //private void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    var donThuoc = new DTO.DonThuocDTO()
        //    {
        //        MaHoSo = hoso.MaHoSo
        //    };
        //    this.bus.khamProcessing(hoso, donThuoc, danhSachThuoc, result =>
        //    {
        //        if (result.Equals(COM.Constant.RES_SUC))
        //            this.InvokeConfirm(this, e);
        //    });
        //}
    }
}
