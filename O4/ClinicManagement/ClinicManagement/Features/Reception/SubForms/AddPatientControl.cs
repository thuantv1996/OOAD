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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.patientInformation.BringToFront();
            this.btnBack.BringToFront();
            this.btnConfirm.BringToFront();
            this.btnCreate.Visible = false;
            this.btnBack.Visible = true;
            this.btnConfirm.Visible = true;

            this.patientInformation.fillData(this.patientEdit.getData());
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var patient = this.patientInformation.getData();
            var msgError = "";
            if (String.IsNullOrWhiteSpace(patient.HoTen) || String.IsNullOrEmpty(patient.HoTen))
                msgError += "Họ Tên không được để trống" + "\n";
            if (String.IsNullOrWhiteSpace(patient.SoDienThoai) || String.IsNullOrEmpty(patient.SoDienThoai))
                msgError += "Số điện thoại không được để trống" + "\n";
            if (String.IsNullOrWhiteSpace(patient.DiaChi) || String.IsNullOrEmpty(patient.DiaChi))
                msgError += "Địa chỉ không được để trống" + "\n";
            if (String.IsNullOrWhiteSpace(patient.CMND) || String.IsNullOrEmpty(patient.CMND))
                msgError += "CMND không được để trống" + "\n";

            if (!String.IsNullOrEmpty(msgError))
            {
                MessageBox.Show(msgError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.CreateCompleted?.Invoke(this, patient);
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

        public event EventHandler<DTO.BenhNhanEnity> CreateCompleted;
    }
}
