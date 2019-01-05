using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Analysis.SubForms
{
    public partial class AnalysisConfirm : UserControl
    {
        private DTO.HoSoBenhAnDTO hoso;
        private string ketQuaXetNghiem;
        private Bus.AnalysisBus bus = Bus.AnalysisBus.SharedInstance;

        public event EventHandler WillConfirm;
        public event EventHandler WillBack;

        public AnalysisConfirm(DTO.HoSoBenhAnDTO hoso, string ketQuaXetNghiem)
        {
            InitializeComponent();
            this.hoso = hoso;
            this.ketQuaXetNghiem = ketQuaXetNghiem;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.fetchData();
        }

        private void fetchData()
        {
            var benhNhan = this.bus.getBenhNhan(this.hoso.MaBenhNhan);
            this.txtHoTen.Text = benhNhan.HoTen;
            this.txtSTT.Text = this.hoso.SoThuTu.ToString();

            this.txtKetQua.Text = this.ketQuaXetNghiem;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.WillConfirm?.Invoke(this, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.WillBack?.Invoke(this, e);
        }
    }
}
