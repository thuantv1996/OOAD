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
    public partial class LatestPrescription : UserControl
    {
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        private DTO.HoSoBenhAnDTO hoso;
        public LatestPrescription(DTO.HoSoBenhAnDTO hoso)
        {
            InitializeComponent();
            this.hoso = hoso;
        }

        public void loadData()
        {
            this.bus.getInformationToShowLatestRecord(this.hoso, (ngayTN, bacSi, chuanDoan, listThuoc, result) =>
            {
                if (result.Equals(COM.Constant.RES_FAI))
                {
                    var rsMsg = MessageBox.Show("Không tồn tại hồ sơ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (rsMsg == DialogResult.OK)
                    {
                        var parentForm = (Form)this.Parent;
                        parentForm.Close();
                        return;
                    }
                }
                this.txtNgayKham.Text = ngayTN;
                this.txtBacSi.Text = bacSi;
                this.txtChuanDoan.Text = chuanDoan;
                this.gridControl1.DataSource = Common.ClinicBus.ConvertToDatatable(listThuoc);
            });
        }
    }
}
