using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Payment.Main
{
    public partial class PaymentHome : UserControl
    {
        private Bus.PaymentBus bus = Bus.PaymentBus.SharedInstance;
        public PaymentHome()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.fetchData(null);
        }

        private void fetchData(Action<bool> completion)
        {
            this.bus.getListHoSo((listHoSo, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.gridControl1.DataSource = Common.ClinicBus.ConvertToDatatable(listHoSo);
                    completion?.Invoke(true);
                } 
                else
                {
                    completion?.Invoke(false);
                }
            });
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            this.accessCell(this.getCurrentRecord());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.fetchData(result =>
            {
                if (result)
                {
                    MessageBox.Show("Làm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Làm mới dữ liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.accessCell(this.getCurrentRecord());
        }

        private void accessCell(DTO.HoSoBenhAnDTO hoso)
        {
            var formContainer = new Form()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };

            var detailControl = new Subforms.PaymentDetail(hoso)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            formContainer.Controls.Add(detailControl);
            formContainer.ShowDialog();
        }

        private DTO.HoSoBenhAnDTO getCurrentRecord()
        {
            var selectedIndex = this.gridView1.GetSelectedRows().First();
            DataRow row = this.gridView1.GetDataRow(selectedIndex);
            var maHoSo = row[col_MaHoSo.FieldName].ToString();
            return this.bus.getHoSoBenhAnDTO(maHoSo);
        }
    }
}
