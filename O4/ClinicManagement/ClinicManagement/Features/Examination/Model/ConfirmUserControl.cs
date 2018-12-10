using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Features.Examination.Model
{
    public class ConfirmUserControl: System.Windows.Forms.UserControl
    {
        public event EventHandler DidConfirm;

        protected void InvokeConfirm(object sender, EventArgs e)
        {
            this.DidConfirm?.Invoke(sender, e);
        }
    }
}
