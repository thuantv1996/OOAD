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
    public partial class PatientDetail : UserControl
    {
        public PatientDetail()
        {
            InitializeComponent();
            this.patientInformation.BringToFront();
        }

        public PatientDetail(DTO.BenhNhanDTO patient)
        {
            InitializeComponent();
            this.patientInformation.BringToFront();
            this.fillData(patient);
        }

        public void fillData(DTO.BenhNhanDTO patient)
        {
            this.patientInformation.fillData(patient);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var patient = this.patientInformation.getData();
            this.CreateClick?.Invoke(this, patient);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.patientEdit.fillData(this.patientInformation.getData());
            this.patientEdit.BringToFront();
            this.btnSave.BringToFront();
            this.btnCreate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //update database
            var patient = this.patientEdit.getData();

            this.bus.saveBenhNhan(patient, (result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                    this.patientInformation.fillData(patient);
                else
                    MessageBox.Show("Lưu thông tin không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.patientInformation.BringToFront();
                this.btnEdit.BringToFront();
                this.btnCreate.Enabled = true;
            });
        }

        public event EventHandler<DTO.BenhNhanDTO> CreateClick;
        private Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;
    }
}
