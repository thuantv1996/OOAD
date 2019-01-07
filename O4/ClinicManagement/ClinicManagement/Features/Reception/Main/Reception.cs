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
    public partial class Reception : Common.ClinicComponents.MainUserControl
    {
        public Reception()
        {
            InitializeComponent();
            this.receptionControl.refreshEvent += ReceptionControl_refreshEvent;
        }

        private void ReceptionControl_refreshEvent(object sender, EventArgs e)
        {
            this.receptionControl.refreshData();
            this.receptionControl.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var containerForm = new Form
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };

            var tableWithSearch = new ClinicManagement.Common.ClinicComponents.PatientTableWithSearch
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            tableWithSearch.DoubleClick += (obj, benhNhan) =>
            {
                this.receptionControl.setupData(benhNhan);
                containerForm.Close();
                this.receptionControl.Enabled = true;
            };


            containerForm.Controls.Add(tableWithSearch);
            containerForm.ShowDialog();
        }

    }
}
