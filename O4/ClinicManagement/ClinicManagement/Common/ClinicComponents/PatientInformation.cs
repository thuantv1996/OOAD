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

        public void fillData(DTO.BenhNhanDTO patient)
        {
            this.txtName.Text = patient.HoTen;
            int year = int.Parse(patient.NgaySinh.Substring(0, 4));
            int month = int.Parse(patient.NgaySinh.Substring(4, 2));
            int day = int.Parse(patient.NgaySinh.Substring(6, 2));

            this.txtBirthDay.Text = string.Format("{0}/{1}/{2}", day, month, year);
            this.txtPhoneNumber.Text = patient.SoDienThoai;
            this.txtCMND.Text = patient.CMND;
            this.txtGender.Text = patient.GioiTinh == true ? "Nam" : "Nữ";
            this.txtAddress.Text = patient.DiaChi;
            this.txtNote.Text = patient.GhiChu;
            this.idNumber = patient.MaBenhNhan;
        }

        public DTO.BenhNhanDTO getData()
        {
            var list = this.txtBirthDay.Text.Split('/');
            var year = int.Parse(list.Last());
            var month = int.Parse(list[1]);
            var day = int.Parse(list.First());

            var patient = new DTO.BenhNhanDTO() {
                HoTen = this.txtName.Text,
                GioiTinh = this.txtGender.Text.Equals("Nam") ? true : false,
                MaBenhNhan = this.idNumber,
                NgaySinh = string.Format("{0}{1}{2}", year, month >= 10 ? month.ToString(): "0" + month, day >= 10 ? day.ToString() : "0" + day),
                SoDienThoai = this.txtPhoneNumber.Text,
                GhiChu = this.txtNote.Text,
                DiaChi = this.txtAddress.Text,
                CMND = this.txtCMND.Text };
            return patient;
        }

        public void clearData()
        {
            this.txtName.Text = "";
            this.txtGender.Text = "";
            this.txtNote.Text = "";
            this.txtAddress.Text = "";
            this.txtCMND.Text = "";
            this.txtPhoneNumber.Text = "";
            this.txtBirthDay.Text = "";
        }

        private string idNumber = "";
    }
}
