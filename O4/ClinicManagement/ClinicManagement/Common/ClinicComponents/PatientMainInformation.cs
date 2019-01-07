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
    public partial class PatientMainInformation : UserControl
    {
        private DTO.BenhNhanDTO patient;
        public PatientMainInformation()
        {
            InitializeComponent();
        }

        public PatientMainInformation(DTO.BenhNhanDTO patient)
        {
            InitializeComponent();
            this.patient = patient;
            this.fillCoreInformation(patient);
        }

        public void binding(DTO.BenhNhanDTO patient)
        {
            this.patient = patient;
            this.fillCoreInformation(patient);
        }

        private void btnXemThem_Click(object sender, EventArgs e)
        {
            var content = new Label()
            {
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                ForeColor = Color.Black,
                BackColor = Color.White,
                Font = new Font(Font.FontFamily, 10),
                MaximumSize = new Size(450, 0)
            };
            var containerPanel = new Panel() { Left = Top = 0, Size = new Size(500, 500), AutoScroll = true, BackColor = Color.White };
            containerPanel.Controls.Add(content);
            content.Text = this.patient?.GhiChu;

            var formContainer = new Form() { StartPosition = FormStartPosition.CenterParent, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
            formContainer.Controls.Add(containerPanel);

            formContainer.ShowDialog();
        }

        private void fillCoreInformation(DTO.BenhNhanDTO patient)
        {
            this.txtMaBenhNhan.Text = patient.MaBenhNhan;
            this.txtCMND.Text = patient.CMND;
            var date = patient.NgaySinh;
            this.txtNgaySinh.Text = ClinicManagement.Common.ClinicBus.convertDateToView(date);
            this.txtGioiTinh.Text = patient.GioiTinh ? "Nam" : "Nữ";
            this.txtHoTen.Text = patient.HoTen;
            this.txtSoDienThoai.Text = patient.SoDienThoai;
            this.txtDiaChi.Text = patient.DiaChi;
            this.txtGhiChu.Text = patient.GhiChu.Split('\n').First();
        }

        public void refreshData()
        {
            this.txtMaBenhNhan.Text = "";
            this.txtCMND.Text = "";
            this.txtNgaySinh.Text = "";
            this.txtGioiTinh.Text = "";
            this.txtHoTen.Text = "";
            this.txtSoDienThoai.Text = "";
            this.txtDiaChi.Text = "";
            this.txtGhiChu.Text = "";
        }
    }
}
