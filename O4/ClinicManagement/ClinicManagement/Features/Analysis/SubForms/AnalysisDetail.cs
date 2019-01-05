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
    public partial class AnalysisDetail : UserControl
    {
        private DTO.HoSoBenhAnDTO hoso;
        private Bus.AnalysisBus bus = Bus.AnalysisBus.SharedInstance;

        public event EventHandler<DTO.KetQuaXetNghiemDTO> WillConfirm;

        public AnalysisDetail(DTO.HoSoBenhAnDTO hoso)
        {
            InitializeComponent();
            this.hoso = hoso;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DTO.KetQuaXetNghiemDTO ketquaxetnghiem = new DTO.KetQuaXetNghiemDTO();

            this.bus.checkInput(ketquaxetnghiem, (listMessageError, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    Form formContainer = (Form)this.Parent;
                    var confirmControl = new SubForms.AnalysisConfirm(this.hoso, this.txtKetQua.Text)
                    {
                        Left = Top = 0,
                        Dock = DockStyle.Fill
                    };

                    confirmControl.WillConfirm += (obj, ea) =>
                    {
                        var kqxn = new DTO.KetQuaXetNghiemDTO();
                        this.WillConfirm?.Invoke(this, kqxn);
                    };

                    confirmControl.WillBack += (obj, ea) =>
                    {
                        this.BringToFront();
                    };

                    formContainer.Controls.Add(confirmControl);
                    confirmControl.BringToFront();
                } else
                {
                    string messageError = "";
                    listMessageError.ForEach(msg => messageError += msg + "\n");
                    MessageBox.Show(messageError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });



            
        }
    }
}
