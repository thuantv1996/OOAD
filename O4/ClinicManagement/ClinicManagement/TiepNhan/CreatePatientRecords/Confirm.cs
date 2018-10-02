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
    public partial class Confirm : UserControl
    {
        public Confirm(System.EventHandler editClick, System.EventHandler doneClick)
        {
            InitializeComponent();
            this.btnEdit.Click += new System.EventHandler(editClick);
            this.btnDone.Click += new System.EventHandler(doneClick);
        }

        public void fillInfo(BenhNhan info)
        {
            this.txtName.Text = info.getName();
            this.txtBirthDay.Text = info.getBirthDay();
            this.txtIdentityNumber.Text = info.getIdentityCardNumber();
            this.txtSex.Text = info.getSex();
            this.txtNote.Text = info.getNote();
        }

        private bool validateInfo()
        {
            return true;
        }
    }
}
