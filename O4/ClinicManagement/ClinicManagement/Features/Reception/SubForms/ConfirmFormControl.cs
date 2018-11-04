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
    public partial class ConfirmFormControl : UserControl
    {
        public ConfirmFormControl()
        {
            InitializeComponent();
            this.setupEvent();
        }

        private void setupEvent()
        {
            this.btnBack.Click += (sender, e) =>
            {
                this.BackClick?.Invoke(sender, e);
            };
            this.btnConfirm.Click += (sender, e) =>
            {
                this.ConfirmClick?.Invoke(sender, this.patientInformation1.getData());
            };
        }

        public void fillData(Model.Patient patient)
        {
            this.patientInformation1.fillData(patient);
        }

        public event EventHandler BackClick;
        public event EventHandler<Model.Patient> ConfirmClick;
    }
}
