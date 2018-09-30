using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.TiepNhan.CreatePatientRecords
{
    public partial class FormToCreate : UserControl
    {
        public FormToCreate(System.EventHandler buttonClick)
        {
            InitializeComponent();
            this.btnCreate.Click += new System.EventHandler(buttonClick);
        }
    }
}
