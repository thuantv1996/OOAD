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

        public PatientDetail(DTO.BenhNhanEnity patient)
        {
            InitializeComponent();
            this.patientInformation.BringToFront();
            this.fillData(patient);
        }

        private void setupView()
        {
            this.Controls.Remove(this.patientEdit);
        }

        public void fillData(DTO.BenhNhanEnity patient)
        {
            this.patientInformation.fillData(patient);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.CreateClick?.Invoke(this, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.patientEdit.fillData(this.patientInformation.getData());
            this.patientEdit.BringToFront();
            this.btnSave.BringToFront();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.patientInformation.fillData(this.patientEdit.getData());
            this.patientInformation.BringToFront();
            this.btnEdit.BringToFront();
        }

        public event EventHandler CreateClick;
    }
}
