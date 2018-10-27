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
            this.tableDataWithSearch.searchCompleted = new Action<Common.ClinicComponents.FilterUserControl.SearchResult>((result) =>
            {
                //MARK: - Dummy
                Console.WriteLine("=============================");
                Console.WriteLine(result.maBenhNhan);
                Console.WriteLine(result.tenBenhNhan);
                Console.WriteLine(result.cmnd);
            });
        }

        private Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;
    }
}
