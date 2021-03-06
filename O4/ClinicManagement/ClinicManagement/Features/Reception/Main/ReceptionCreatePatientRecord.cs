﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Reception.Main
{
    public partial class ReceptionCreatePatientRecord : Common.ClinicComponents.MainUserControl
    {
        private Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;
        public ReceptionCreatePatientRecord()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.addPatientControl1.CreateCompleted += AddPatientControl1_CreateCompleted;
        }

        private void AddPatientControl1_CreateCompleted(object sender, DTO.BenhNhanDTO e)
        {
            this.bus.insertBenhNhan(e, result =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.addPatientControl1.refreshControl();
                }
            });
        }
    }
}
