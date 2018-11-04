using System;
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
    public partial class ReceptionCreatePatientRecord : UserControl
    {
        public ReceptionCreatePatientRecord()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.setupComponent();
            this.setupEvent();
        }
        
        private void setupComponent()
        {
            this.createFormControl = new SubForms.CreateFormControl();
            this.Controls.Add(this.createFormControl);

            this.createFormControl.Left = (this.ClientSize.Width - this.createFormControl.Width) / 2;
            this.createFormControl.Top = (this.ClientSize.Height - this.createFormControl.Height) / 2;

            this.createFormControl.Anchor = AnchorStyles.None;
            this.createFormControl.BackColor = Color.FromArgb(25, 0, 0, 0);
        }

        private void setupEvent()
        {
            this.createFormControl.CreateCompleted += (sender, e) =>
            {
                var confirmControl = new SubForms.ConfirmFormControl() { Dock = DockStyle.Fill };
                var confirmForm = new Common.ClinicComponents.ClinicForm() { Size = new Size(confirmControl.Width, confirmControl.Height) };
                confirmForm.ContentControls.Add(confirmControl);
                confirmForm.StartPosition = FormStartPosition.CenterParent;
               
                confirmControl.fillData(this.createFormControl.getData());
                confirmControl.BackClick += (btn, egr) =>
                {
                    confirmForm.Close();
                };
                confirmControl.ConfirmClick += (btn, patient) => {
                    Console.WriteLine(patient.ToString());
                };

                confirmForm.ShowDialog();
            };
        }

      

        private SubForms.CreateFormControl createFormControl;
    }
}
