using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.TiepNhan.CreatePatientRecords;

namespace ClinicManagement.TiepNhan
{
    public partial class HomeReceiver : UserControl
    {
        public HomeReceiver()
        {
            InitializeComponent();
        }

        public HomeReceiver(System.EventHandler createMedicalRecordsClick, System.EventHandler createInvoiceClick, System.EventHandler createRecordsClick)
        {
            this.btnCreateMedicalRecord.Click += new System.EventHandler(createMedicalRecordsClick);
            this.btnCreateInvoice.Click += new System.EventHandler(createInvoiceClick);
            this.btnCreateRecord.Click += new System.EventHandler(createRecordsClick);
            this.InitializeComponent();
        }

        private void btnCreateRecord_Click(object sender, EventArgs e)
        {
            var form = new CreatePatientRecordsForm();
            form.reloadCallBack = new Action(this.reload);
            form.ShowDialog();
        }

        private void reload()
        {
            //Reload data
        }
    }
}
