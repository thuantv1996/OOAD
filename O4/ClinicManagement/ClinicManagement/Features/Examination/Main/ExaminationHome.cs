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
    public partial class ExaminationHome : UserControl
    {
        private const string maPhongDummyData = "P000000001";
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        public ExaminationHome()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            //MARK: - Danh sách chờ khám
            this.danhSachChoKham.RefreshClick += WaitingPatientTable1_RefreshClick;
            this.danhSachChoKham.AccessClick += DanhSachChoKham_AccessClick;

            this.fillWaitingExaminationTable(null);
            //MARK: - Danh sách đã xét nghiệm chờ bốc thuốc

        }

        private void DanhSachChoKham_AccessClick(object sender, Model.HoSoBenhAnView e)
        {
            var benhNhan = this.bus.getBenhNhan(e.MaBenhNhan);
            if (benhNhan == null) return;
            var formContainer = new Form()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };


            var control = new SubForms.ExaminationHome(benhNhan)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            formContainer.Controls.Add(control);
            formContainer.ShowDialog();
        }

        private void WaitingPatientTable1_RefreshClick(object sender, EventArgs e)
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
            this.bus.getListHoSo(maPhongDummyData, (listHoSo, result) =>
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
                    this.danhSachChoKham.binding(listHoSo);
                    completion?.Invoke(true);
                }
                else
                    completion?.Invoke(false);
            });
        }
    }
}
