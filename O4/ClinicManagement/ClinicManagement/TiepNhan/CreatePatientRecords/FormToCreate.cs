using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.Model;

namespace ClinicManagement.TiepNhan.CreatePatientRecords
{
    public partial class FormToCreate : UserControl
    {
        public FormToCreate(System.EventHandler buttonClick)
        {
            InitializeComponent();
            this.btnCreate.Click += new System.EventHandler(buttonClick);
        }

        public BenhNhan getTypingInfo()
        {
            string name = txtName.Text;
            string birthDay = pickBirthDay.Text;
            string identityCardNumber= txtIdentityNumber.Text;
            BenhNhan.Sex sex = cbSex.Text == "Nam" ? BenhNhan.Sex.MALE : (cbSex.Text == "Nữ" ? BenhNhan.Sex.FEMALE : BenhNhan.Sex.UNKNOWN);
            string address = txtAddress.Text;
            string note = txtNote.Text;
            return new BenhNhan(name, birthDay, identityCardNumber, sex, address, note);
        }
    }
}
