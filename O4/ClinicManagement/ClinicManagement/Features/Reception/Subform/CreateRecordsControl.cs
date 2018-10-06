using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.Common.Model;

namespace ClinicManagement.Features.Reception.Subform
{
    public partial class CreateRecordsControl : UserControl
    {
        public CreateRecordsControl()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (this.btnContinue_Click_Deleagete != null)
            {
                this.btnContinue_Click_Deleagete(sender, e);
            }
        }

        public void fillBack(Patient patient)
        {
            this.txtName.Text = patient.getName();
            this.cbBirthDay.DateTime = patient.getBirthDay();
            this.txtIdNumber.Text = patient.getIdentityCardNumber();
            this.cbSex.Text = patient.getSex().ToString();
            this.txtAddress.Text = patient.getAddress();
            this.txtNote.Text = patient.getNote();
        }

        public Patient getInfo()
        {
            var name = this.txtName.Text;
            var birthDay = this.cbBirthDay.DateTime;
            var idNumber = this.txtIdNumber.Text;
            var sex = new Patient.Sex(this.cbSex.Text);
            var address = this.txtAddress.Text;
            var note = this.txtNote.Text;
            return new Patient(name, birthDay, idNumber, sex, address, note);
        }

        public System.EventHandler btnContinue_Click_Deleagete;
    }
}
