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

        public void fillData(DTO.BenhNhanEnity patient)
        {
            this.txtName.Text = patient.HoTen;
            this.txtBirthDay.Text = patient.NgaySinh;
            this.txtPhoneNumber.Text = patient.SoDienThoai;
            this.txtCMND.Text = patient.CMND;
            this.txtSex.Text = patient.GioiTinh == true ? "Nam" : "Nữ";
            this.txtAddress.Text = patient.DiaChi;
            this.txtNote.Text = patient.GhiChu;
            this.idNumber = patient.MaBenhNhan;
        }

        public DTO.BenhNhanEnity getData()
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
                return new DTO.BenhNhanEnity();
            }

            var patient = new DTO.BenhNhanEnity();
            patient.HoTen = this.txtName.Text;
            patient.GioiTinh = this.txtSex.Equals("Nam") ? true : false;
            patient.MaBenhNhan = this.idNumber;
            patient.NgaySinh = this.txtBirthDay.Text;
            patient.SoDienThoai = this.txtPhoneNumber.Text;
            patient.GhiChu = this.txtNote.Text;
            patient.DiaChi = this.txtAddress.Text;
            patient.CMND = this.txtCMND.Text;
            return patient;
        }

        private string idNumber = "";
    }
}
