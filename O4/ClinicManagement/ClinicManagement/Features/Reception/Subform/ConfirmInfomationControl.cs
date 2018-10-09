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
    public partial class ConfirmInfomationControl : UserControl
    {
        public ConfirmInfomationControl()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit_Click_Delegate != null)
            {
                this.btnEdit_Click_Delegate(sender, e);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (btnDone_Click_Delegate != null)
            {
                this.btnDone_Click_Delegate(sender, e);
            }
        }

        public void fillForm(Patient patient)
        {
            this.txtName.Text = patient.getName();
            this.txtBirthDay.Text = patient.getBirthDay().ToShortDateString();
            this.txtIdNumber.Text = patient.getIdentityCardNumber();
            this.txtSex.Text = patient.getSex().ToString();
            this.txtAddress.Text = patient.getAddress();
            this.txtNote.Text = patient.getNote();
        }

        public Patient getInfo()
        {
            var name = this.txtName.Text;
            var birthDay = this.txtBirthDay.Text;
            var idNumber = this.txtIdNumber.Text;
            var sex = new Patient.Sex(this.txtSex.Text);
            var address = this.txtAddress.Text;
            var note = this.txtNote.Text;
            return new Patient(name, birthDay, idNumber, sex, address, note);
        }

        public System.EventHandler btnEdit_Click_Delegate;
        public System.EventHandler btnDone_Click_Delegate;
    }
}
