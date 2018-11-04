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
    public partial class PatientInformation : UserControl
    {
        public PatientInformation()
        {
            InitializeComponent();
        }

        public void fillData(Model.Patient patient)
        {
            this.txtName.Text = patient.Name;
            this.txtBirthDay.Text = patient.BirthDay.ToShortDateString();
            this.txtPhoneNumber.Text = patient.PhoneNumber;
            this.txtCMND.Text = patient.IdentityCardNumber;
            this.txtSex.Text = patient.Sex.ToString();
            this.txtAddress.Text = patient.Address;
            this.txtNote.Text = patient.Note;
            this.idNumber = patient.IdNumber;
        }

        public Model.Patient getData()
        {
            DateTime birthDay;
            try
            {
                var dateListString = this.txtBirthDay.Text.Split('/');
                int day = int.Parse(dateListString.First());
                int month = int.Parse(dateListString[1]);
                int year = int.Parse(dateListString.Last());
                birthDay = new DateTime(year, month, day);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Model.Patient();
            }

            return new Model.Patient(this.txtName.Text, birthDay, this.idNumber, new Model.StructSex(this.txtSex.Text), this.txtAddress.Text, this.txtNote.Text);
        }

        private string idNumber = "";
    }
}
