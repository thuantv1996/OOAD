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
    public partial class Reception : UserControl
    {
        public Reception()
        {
            InitializeComponent();
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
