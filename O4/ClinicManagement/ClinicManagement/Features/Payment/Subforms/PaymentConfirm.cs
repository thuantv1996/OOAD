using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Payment.Subforms
{
    public partial class PaymentConfirm : UserControl
    {
        private DTO.HoSoBenhAnDTO hoso;
        private List<DTO.KetQuaXetNghiemDTO> danhSachCanThanhToan = new List<DTO.KetQuaXetNghiemDTO>();
        private Bus.PaymentBus bus = Bus.PaymentBus.SharedInstance;

        public event EventHandler DidConfirm;

        public PaymentConfirm(DTO.HoSoBenhAnDTO hoso, List<DTO.KetQuaXetNghiemDTO> danhSachCanThanhToan)
        {
            InitializeComponent();
            this.hoso = hoso;
            this.danhSachCanThanhToan = danhSachCanThanhToan;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.fetchData();
        }

        private void fetchData()
        {
            var benhNhan = this.bus.getBenhNhan(this.hoso.MaBenhNhan);
            this.txtHoTen.Text = benhNhan.HoTen;
            this.txtSTT.Text = this.hoso.SoThuTu.ToString();

            var listView = this.bus.convertThanhToanToView(this.danhSachCanThanhToan);
            this.grdCanThanhToanControl.DataSource = Common.ClinicBus.ConvertToDatatable(listView);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DidConfirm?.Invoke(this, e);
        }
    }
}
