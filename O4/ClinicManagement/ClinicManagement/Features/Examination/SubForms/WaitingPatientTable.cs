using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Examination.SubForms
{
    public partial class WaitingPatientTable : UserControl
    {
        public WaitingPatientTable()
        {
            InitializeComponent();
        }

        public void binding(List<Model.HoSoBenhAnView> list)
        {
            if (this.gridControl1.InvokeRequired)
                this.Invoke(new Action<List<Model.HoSoBenhAnView>>(binding), new object[] { list });
            else
                this.gridControl1.DataSource = Common.ClinicBus.ConvertToDatatable(list);
            
        }
    }
}
