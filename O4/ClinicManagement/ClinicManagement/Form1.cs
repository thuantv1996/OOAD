using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicManagement.Features.Reception.Home;
using ClinicManagement.Features.Examination.Home;

namespace ClinicManagement
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        enum ClinicFeatures
        {
            reception,      //Tiếp nhận
            examination,    //Khám bệnh
            analysis        //Xét nghiệm
        }

        public Form1()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.setupSubControl(ClinicFeatures.examination);
        }

        private void setupSubControl(ClinicFeatures feature) 
        {
            switch (feature)
            {
                case ClinicFeatures.reception: this.control = new ReceptionHomeControl(); break;
                case ClinicFeatures.examination: this.control = new ExaminationHomeControl(); break;
                default: return;
            }
            this.control.Left = 0;
            this.control.Top = 0;
            this.control.Dock = DockStyle.Fill;
            this.Controls.Add(this.control);
        }

        private UserControl control;
    }
}
