using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Reception.SubForms
{
    public partial class AddPatientControl : UserControl
    {
        public AddPatientControl()
        {
            InitializeComponent();
        }

        public void refreshControl()
        {
            this.patientEdit.BringToFront();
            this.btnCreate.BringToFront();
            this.btnCreate.Visible = true;
            this.btnBack.Visible = false;
            this.btnConfirm.Visible = false;
            this.clearData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (this.checkValid())
            {
                this.patientInformation.BringToFront();
                this.btnBack.BringToFront();
                this.btnConfirm.BringToFront();
                this.btnCreate.Visible = false;
                this.btnBack.Visible = true;
                this.btnConfirm.Visible = true;

                this.patientInformation.fillData(this.patientEdit.getData());
            }
            else
                MessageBox.Show("Không được bỏ trống các trường dữ liệu quan trọng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool checkValid()
        {
            var patient = this.patientEdit.getData();
            return !(String.IsNullOrWhiteSpace(patient.HoTen) || String.IsNullOrEmpty(patient.HoTen)
                || String.IsNullOrWhiteSpace(patient.SoDienThoai) || String.IsNullOrEmpty(patient.SoDienThoai)
                || String.IsNullOrWhiteSpace(patient.CMND) || String.IsNullOrEmpty(patient.CMND)
                || String.IsNullOrWhiteSpace(patient.DiaChi) || String.IsNullOrEmpty(patient.DiaChi)
                );
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.CreateCompleted?.Invoke(this, this.patientInformation.getData());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.patientEdit.BringToFront();
            this.btnCreate.BringToFront();
            this.btnCreate.Visible = true;
            this.btnConfirm.Visible = false;
            this.btnBack.Visible = false;

            this.patientEdit.fillData(this.patientInformation.getData());
        }

        public void clearData()
        {
            this.patientInformation.clearData();
            this.patientEdit.clearData();
        }

        public event EventHandler<DTO.BenhNhanDTO> CreateCompleted;
    }
}
