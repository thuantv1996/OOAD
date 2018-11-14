using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Common.ClinicComponents
{
    public partial class PatientDetail : UserControl
    {
        public PatientDetail()
        {
            InitializeComponent();
        }

        public void fillData(DTO.BenhNhanEnity patient)
        {
            this.patientInformation.fillData(patient);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Hiển thị màn hình tạo hồ sơ bệnh án
        }
    }
}
