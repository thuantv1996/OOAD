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

        public List<DTO.XetNghiemDTO> DanhSachXetNghiem
        {
            get
            {
                return this.danhSachXetNghiem;
            }
        }

        public event EventHandler ClearEvent;

        public AssignTestsConfirm(List<DTO.XetNghiemDTO> danhSachXetNghiem, bool isConfirm = false)
        {
            InitializeComponent();
            this.danhSachXetNghiem = danhSachXetNghiem;
            this.setup();
            this.btnClear.Visible = !isConfirm;
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearEvent?.Invoke(this, e);
        }

        //private void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    var listKQXN = new List<DTO.KetQuaXetNghiemDTO>();
        //    danhSachXetNghiem.ForEach(xn =>
        //    {
        //        listKQXN.Add(new DTO.KetQuaXetNghiemDTO()
        //        {
        //            MaHoSo = hoso.MaHoSo,
        //            MaXetNghiem = xn.MaXetNghiem,
        //            ThanhToan = false,
        //            TongChiPhi = chiPhi,
        //            MaBacSi = Common.User.SharedInstance.UserId
        //        });
        //    });
        //    this.bus.assignTests(listKQXN, result =>
        //    {
        //        if (result.Equals(COM.Constant.RES_SUC))
        //        {
        //            if (MessageBox.Show("Lưu thông tin khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
        //            {
        //                this.InvokeConfirm(this, e);
        //            } 
        //            else
        //            {
        //                MessageBox.Show("Lưu thông tin thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    });
        //}
    }
}
