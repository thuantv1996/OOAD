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
            this.tableDataWithSearch.SearchCompleted += new EventHandler<Common.ClinicComponents.FilterUserControl.SearchResult>((sender, e) =>
            {
                //MARK: - Dummy
                Console.WriteLine("=============================");
                Console.WriteLine(e.MaBenhNhan);
                Console.WriteLine(e.TenBenhNhan);
                Console.WriteLine(e.CMND);
            });
        }

        private Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;
    }
}
