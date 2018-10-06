using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.Features.Reception.Subform;

namespace ClinicManagement.Features.Reception.Subform
{
    public partial class createRecordsForm : Form
    {
        public createRecordsForm()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.setupCreateControl();
            this.setupConfirmControl();
        }

        private void setupCreateControl()
        {
            this.createRecordControl = new CreateRecordsControl();
            this.createRecordControl.Left = 0;
            this.createRecordControl.Top = 0;
            this.createRecordControl.Dock = DockStyle.Fill;
            this.Controls.Add(this.createRecordControl);
            this.createRecordControl.btnContinue_Click_Deleagete = new System.EventHandler(this.btnContinue_Click);
        }

        private void setupConfirmControl()
        {
            this.confirmControl = new ConfirmInfomationControl();
            this.confirmControl.Left = 0;
            this.confirmControl.Top = 0;
            this.confirmControl.Dock = DockStyle.Fill;
            this.Controls.Add(this.confirmControl);
            this.confirmControl.btnEdit_Click_Delegate = new System.EventHandler(this.btnEdit_Click);
            this.confirmControl.btnDone_Click_Delegate = new System.EventHandler(this.btnDone_Click);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.confirmControl.fillForm(this.createRecordControl.getInfo());
            this.createRecordControl.Visible = false;
            this.confirmControl.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.createRecordControl.fillBack(this.confirmControl.getInfo());
            this.createRecordControl.Visible = true;
            this.confirmControl.Visible = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private CreateRecordsControl createRecordControl;
        private ConfirmInfomationControl confirmControl;
    }
}
