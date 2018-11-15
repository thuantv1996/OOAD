using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ClinicManagement.Common.ClinicComponents
{
    public partial class PatientEdit : UserControl
    {
        public PatientEdit()
        {
            InitializeComponent();
        }

        public bool fillCompleted()
        {
            return !(String.IsNullOrEmpty(this.name.Text) ||
                String.IsNullOrEmpty(this.birthDay.Text) ||
                String.IsNullOrEmpty(this.phoneNumber.Text) ||
                String.IsNullOrEmpty(this.identify.Text) ||
                String.IsNullOrEmpty(this.gender.Text) ||
                String.IsNullOrEmpty(this.address.Text));
        }

        public void fillData(DTO.BenhNhanEnity patient)
        {
            

            this.name.Text = patient.HoTen;
            this.birthDay.DateTime = DateTime.ParseExact(patient.NgaySinh, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.phoneNumber.Text = patient.SoDienThoai;
            this.identify.Text = patient.CMND;
            this.gender.Text = patient.GioiTinh == true ? "Nam" : "Nữ";
            this.address.Text = patient.DiaChi;
            this.note.Text = patient.GhiChu;
            this.maBenhNhan = patient.MaBenhNhan;
        }

        public DTO.BenhNhanEnity getData()
        {
            var patient = new DTO.BenhNhanEnity();
            DateTime birthDay = this.birthDay.DateTime;
            patient.HoTen = this.name.Text;
            patient.GioiTinh = this.gender.Text.Equals("Nam") ? true : false;
            patient.MaBenhNhan = this.maBenhNhan;
            var birthDayString = birthDay.ToShortDateString();
            var year = birthDay.Year;
            var month = birthDay.Month;
            var day = birthDay.Day;
            patient.NgaySinh = string.Format("{0}{1}{2}", year, month > 10 ? month.ToString() : "0" + month, day > 10 ? day.ToString() : "0" + day);
            patient.SoDienThoai = this.phoneNumber.Text;
            patient.GhiChu = this.note.Text;
            patient.DiaChi = this.address.Text;
            patient.CMND = this.identify.Text;
            return patient;
        }

        private string maBenhNhan;
    }
}
