﻿using System;
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

        public DTO.BenhNhanDTO getData()
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
                return new DTO.BenhNhanDTO();
            }

            var patient = new DTO.BenhNhanDTO() {
                HoTen = this.txtName.Text,
                GioiTinh = this.cbSex.ComboBox.Text.Equals("Nam") ? true : false,
                NgaySinh = this.cbBirthDay.DateTimePicker.Text,
                SoDienThoai = this.txtPhoneNumber.Text,
                GhiChu = this.txtNote.Text,
                DiaChi = this.txtAddress.Text,
                CMND = this.txtCMND.Text };
            return patient;
        }

        public event EventHandler CreateCompleted;
    }
}
