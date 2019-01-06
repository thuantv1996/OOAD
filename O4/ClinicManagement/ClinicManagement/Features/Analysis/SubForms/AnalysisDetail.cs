using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Analysis.SubForms
{
    public partial class AnalysisDetail : UserControl
    {
        private DTO.HoSoBenhAnDTO hoso;
        private Bus.AnalysisBus bus = Bus.AnalysisBus.SharedInstance;
        private DTO.KetQuaXetNghiemDTO ketQuaXetNghiem;

        public event EventHandler<DTO.KetQuaXetNghiemDTO> WillConfirm;

        public AnalysisDetail(DTO.HoSoBenhAnDTO hoso, DTO.KetQuaXetNghiemDTO ketQuaXetNghiem)
        {
            InitializeComponent();
            this.hoso = hoso;
            this.ketQuaXetNghiem = ketQuaXetNghiem;
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

            var xetNghiemInfor = this.bus.getXetNghiemInformation(this.ketQuaXetNghiem.MaXetNghiem);
            var phong = this.bus.getPhongInformation();

            if (xetNghiemInfor != null)
            {
                this.txtTenXetNghiem.Text = xetNghiemInfor.TenXetNghiem;
            }

            if (phong != null)
            {
                this.txtTenPhong.Text = phong.TenPhong;
            }

            this.bus.getListNhanVien((listNhanVien, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listNhanVien.ForEach(nv =>
                    {
                        this.cbChonBacSy.Properties.Items.Add(nv);
                    });
                }
            });

            this.cbChonBacSy.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.ketQuaXetNghiem.KetQua = this.txtKetQua.getText;

            this.bus.checkInput(this.ketQuaXetNghiem, (listMessageError, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    Form formContainer = (Form)this.Parent;
                    var confirmControl = new SubForms.AnalysisConfirm(this.hoso, this.txtKetQua.Text)
                    {
                        Left = Top = 0,
                        Dock = DockStyle.Fill
                    };

                    confirmControl.WillConfirm += (obj, ea) =>
                    {
                        this.WillConfirm?.Invoke(this, this.ketQuaXetNghiem);
                    };

                    confirmControl.WillBack += (obj, ea) =>
                    {
                        this.BringToFront();
                    };

                    formContainer.Controls.Add(confirmControl);
                    confirmControl.BringToFront();
                } else
                {
                    string messageError = "";
                    listMessageError.ForEach(msg => messageError += msg + "\n");
                    MessageBox.Show(messageError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });



            
        }
    }
}
