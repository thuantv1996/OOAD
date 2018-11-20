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
    public partial class ReceptionControl : UserControl
    {
        private DTO.BenhNhanEnity patient;
        public ReceptionControl()
        {
            InitializeComponent();
        }

        public ReceptionControl(DTO.BenhNhanEnity patient)
        {
            InitializeComponent();
            this.patient = patient;
            this.fillCoreInformation();
            this.fillMainInformation();
        }

        private void fillCoreInformation()
        {
            this.txtMaBenhNhan.Text = patient.MaBenhNhan;
            this.txtCMND.Text = patient.CMND;
            var year = patient.NgaySinh.Substring(0, 4);
            var month = patient.NgaySinh.Substring(4, 2);
            var day = patient.NgaySinh.Substring(6, 2);
            this.txtNgaySinh.Text = String.Format("{0}/{1}/{2}", day, month, year);
            this.txtGioiTinh.Text = patient.GioiTinh ? "Nam" : "Nữ";
            this.txtHoTen.Text = patient.HoTen;
            this.txtSoDienThoai.Text = patient.SoDienThoai;
            this.txtDiaChi.Text = patient.DiaChi;
            this.txtGhiChu.Text = patient.GhiChu.Split('\n').First();
        }

        private void fillMainInformation() {
            var toDay = DateTime.Today;
            var day = toDay.Day;
            var month = toDay.Month;
            var year = toDay.Year;

            this.txtNgayTiepNhan.Text = String.Format("{0}/{1}/{2}", day, month, year);

        }
    }
}
