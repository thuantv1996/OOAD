using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Common.ClinicComponents
{
    public partial class UserInformation : UserControl
    {
        public UserInformation(string HoTen, string ViTri)
        {
            InitializeComponent();
            this.txtTenNhanVien.Text = HoTen;
            this.txtViTri.Text = ViTri;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.LogOut?.Invoke(this, e);
        }

        public void updateData(string HoTen, string ViTri)
        {
            this.txtTenNhanVien.Text = HoTen;
            this.txtViTri.Text = ViTri;
        }

        public event EventHandler LogOut;
    }
}
