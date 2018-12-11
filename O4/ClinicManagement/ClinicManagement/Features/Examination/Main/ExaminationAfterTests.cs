using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Examination.Main
{
    public partial class ExaminationAfterTests : UserControl
    {
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        public ExaminationAfterTests()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.danhSachChoKeDon.RefreshClick += DanhSachChoKeDon_RefreshClick;
            this.danhSachChoKeDon.AccessClick += DanhSachChoKeDon_AccessClick;
            this.fillWaitingExaminationTable(null);
        }

        private void DanhSachChoKeDon_AccessClick(object sender, Model.HoSoBenhAnView e)
        {
            var hoso = new DTO.HoSoBenhAnDTO()
            {
                MaHoSo = e.MaHoSo,
                MaBenhNhan = e.MaBenhNhan
            };

            var formContainer = new Form()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };

            var control = new SubForms.MedicalExaminationAfterTests(hoso)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            formContainer.Controls.Add(control);
            formContainer.ShowDialog();
        }

        private void DanhSachChoKeDon_RefreshClick(object sender, EventArgs e)
        {
            this.fillWaitingExaminationTable(status =>
            {
                if (status)
                    MessageBox.Show("Dữ liệu đã được làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không thể làm mới dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void fillWaitingExaminationTable(Action<bool> completion)
        {
            this.bus.getListHoSoSauXetNghiem((listHoSo, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    //dummy data
                    listHoSo.Add(new Model.HoSoBenhAnView()
                    {
                        MaBenhNhan = "BN00000001",
                        HoTen = "Nguyễn Văn A",
                        CMND = "184313135",
                        MaHoSo = "HS00000001",
                        SoDienThoai = "0968329208",
                        SoThuTu = 1

                    });
                    this.danhSachChoKeDon.binding(listHoSo);
                    completion?.Invoke(true);
                }
                else
                    completion?.Invoke(false);
            });
        }
    }
}
