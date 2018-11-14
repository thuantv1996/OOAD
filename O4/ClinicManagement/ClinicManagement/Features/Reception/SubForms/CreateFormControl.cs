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
    public partial class CreateFormControl : UserControl
    {
        public CreateFormControl()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.btnCreate.Click += new EventHandler((sender, e) =>
            {
                this.CreateCompleted?.Invoke(sender, e);
            });
        }

        public DTO.BenhNhanEnity getData()
        {
            DateTime birthDay;
            try
            {
                var dateListString = this.cbBirthDay.DateTimePicker.Text.Split('/');
                int day = int.Parse(dateListString.First());
                int month = int.Parse(dateListString[1]);
                int year = int.Parse(dateListString.Last());
                birthDay = new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DTO.BenhNhanEnity();
            }

            var patient = new DTO.BenhNhanEnity();
            patient.HoTen = this.txtName.Text;
            patient.GioiTinh = this.cbSex.ComboBox.Text.Equals("Nam") ? true : false;
            
            patient.NgaySinh = this.cbBirthDay.DateTimePicker.Text;
            patient.SoDienThoai = this.txtPhoneNumber.Text;
            patient.GhiChu = this.txtNote.Text;
            patient.DiaChi = this.txtAddress.Text;
            patient.CMND = this.txtCMND.Text;
            return patient;
        }

        public event EventHandler CreateCompleted;
    }
}
