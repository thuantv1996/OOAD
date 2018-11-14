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
    public partial class ReceptionHome : UserControl
    {
        public ReceptionHome()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
        }

        private void ReceptionHome_Load(object sender, EventArgs e)
        {
            this.bus.fetchListBenhNhan((listBenhNhan, listMessageError, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.tableDataView1.fetchData(listBenhNhan);
                } else
                {
                    var msg = "";
                    listMessageError.ForEach((error) =>
                    {
                        msg += error.Message + "\n";
                    });
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }

        private Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;
    }
}
