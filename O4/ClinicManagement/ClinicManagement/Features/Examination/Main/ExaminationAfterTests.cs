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
            this.fetchData(null);
        }

        private void DanhSachChoKeDon_AccessClick(object sender, Model.HoSoBenhAnView e)
        {
            var hoso = this.bus.getHoSoKham(e.MaHoSo);
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

            control.reloadRequest += Control_reloadRequest;

            formContainer.Controls.Add(control);
            formContainer.ShowDialog();
        }

        private void Control_reloadRequest(object sender, EventArgs e)
        {
            this.fetchData(null);
        }

        private void DanhSachChoKeDon_RefreshClick(object sender, EventArgs e)
        {
            this.fetchData(status =>
            {
                if (status)
                    MessageBox.Show("Dữ liệu đã được làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không thể làm mới dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void fetchData(Action<bool> completion)
        {
            this.bus.getListHoSoSauXetNghiem((listHoSo, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.danhSachChoKeDon.binding(listHoSo);
                    completion?.Invoke(true);
                }
                else
                    completion?.Invoke(false);
            });
        }
    }
}
