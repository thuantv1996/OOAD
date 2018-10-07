using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.Features.Reception.Subform;

namespace ClinicManagement.Features.Reception.Home
{
    public partial class ReceptionHomeControl : UserControl
    {
        public ReceptionHomeControl()
        {
            InitializeComponent();
        }

        private void btnCreateRecords_Click(object sender, EventArgs e)
        {
            this.createRecordForm = new CreateRecordsForm();
            this.createRecordForm.StartPosition = FormStartPosition.CenterParent;
            this.createRecordForm.ShowDialog();
        }

        private void btnCreateCaseRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {

        }

        private CreateRecordsForm createRecordForm;
    }
}
