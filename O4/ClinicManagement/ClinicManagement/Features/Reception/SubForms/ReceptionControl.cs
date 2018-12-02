using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Reception.SubForms
{
    public partial class ReceptionControl : UserControl
    {
        private DTO.BenhNhanDTO patient;
        private List<DTO.LoaiHoSoDTO> listLoaiHoSo = new List<DTO.LoaiHoSoDTO>();
        private List<DTO.HoSoBenhAnDTO> listHoSoTruoc = new List<DTO.HoSoBenhAnDTO>();
        private List<DTO.PhongKhamDTO> listPhongKham = new List<DTO.PhongKhamDTO>();
        private List<DTO.NhanVienDTO> listNhanVienTiepNhan = new List<DTO.NhanVienDTO>();
        private Reception.Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;

        public ReceptionControl()
        {
            InitializeComponent();
            this.btnBack.Visible = false;
            this.fillMainInformation();
        }

        public ReceptionControl(DTO.BenhNhanDTO patient)
        {
            InitializeComponent();
            this.setupView(patient);
            this.fillMainInformation();
        }

        public void setupView(DTO.BenhNhanDTO patient)
        {
            this.patient = patient;
            this.fillCoreInformation();
            this.btnBack.Visible = false;
        }

        private void fillCoreInformation()
        {
            this.txtMaBenhNhan.Text = patient?.MaBenhNhan;
            this.txtCMND.Text = patient?.CMND;
            var year = patient?.NgaySinh.Substring(0, 4);
            var month = patient?.NgaySinh.Substring(4, 2);
            var day = patient?.NgaySinh.Substring(6, 2);
            this.txtNgaySinh.Text = String.Format("{0}/{1}/{2}", day, month, year);
            if (patient != null)
                this.txtGioiTinh.Text = patient.GioiTinh ? "Nam" : "Nữ";

            this.txtHoTen.Text = patient?.HoTen;
            this.txtSoDienThoai.Text = patient?.SoDienThoai;
            this.txtDiaChi.Text = patient?.DiaChi;
            this.txtGhiChu.Text = patient?.GhiChu.Split('\n').First();
        }

        private void fillMainInformation() {
            var toDay = DateTime.Today;
            var day = toDay.Day;
            var month = toDay.Month;
            var year = toDay.Year;

            this.txtNgayTiepNhan.Text = String.Format("{0}/{1}/{2}", day, month, year);
            this.bus.getListLoaiHoSo((listResult, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listResult.ForEach((loai) =>
                    {
                        this.cbLoaiHoSo.Properties.Items.Add(loai.TenLoaiHoSo);
                    });
                    this.listLoaiHoSo.AddRange(listResult);
                }
            });

            this.bus.getListMaHoSoTruoc(this.txtMaBenhNhan.Text, (listResult, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listResult.ForEach((hoSo) =>
                    {
                        this.cbMaHoSoTruoc.Properties.Items.Add(hoSo.MaHoSo);
                    });
                    this.listHoSoTruoc.AddRange(listResult);
                }
            });

            this.bus.getListPhong((listResult, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listResult.ForEach((phong) =>
                    {
                        this.cbPhong.Properties.Items.Add(phong.TenPhong);
                    });

                    this.listPhongKham.AddRange(listResult);
                }
            });

            this.bus.getListNhanVien((listResult, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listResult.ForEach(nhanVien =>
                    {
                        this.cbNguoiTiepNhan.Properties.Items.Add(nhanVien.HoTenNV);
                    });

                    this.listNhanVienTiepNhan.AddRange(listResult);
                }
            });
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.btnCreate.BringToFront();
            this.btnBack.Visible = false;
            this.cbLoaiHoSo.Enabled
                = this.cbMaHoSoTruoc.Enabled
                = this.cbNguoiTiepNhan.Enabled
                = this.cbPhong.Enabled
                = this.txtYeuCauKham.Enabled
                = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.btnConfirm.BringToFront();
            this.btnBack.Visible = true;
            this.cbLoaiHoSo.Enabled
                = this.cbMaHoSoTruoc.Enabled
                = this.cbNguoiTiepNhan.Enabled
                = this.cbPhong.Enabled
                = this.txtYeuCauKham.Enabled
                = false;
        }

        private void btnXemThem_Click(object sender, EventArgs e)
        {
            var content = new Label() {
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                ForeColor = Color.Black,
                BackColor = Color.White,
                Font = new Font(Font.FontFamily, 10),
                MaximumSize = new Size(450,0)
            };
            var containerPanel = new Panel() { Left = Top = 0, Size = new Size(500, 500), AutoScroll = true, BackColor = Color.White };
            containerPanel.Controls.Add(content);
            content.Text = this.patient?.GhiChu;

            var formContainer = new Form() { StartPosition = FormStartPosition.CenterParent, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
            formContainer.Controls.Add(containerPanel);

            formContainer.ShowDialog();
        }

        private void btnTimHoSoTruoc_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var formContainer = new Form() {AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, StartPosition = FormStartPosition.CenterParent };
            var previousControl = new SubForms.PreviousRecordsTable(this.patient.MaBenhNhan) { Size = new Size(811, 562) };
            previousControl.DoubleToChoose += (ctrl, hoso) =>
            {
                this.cbMaHoSoTruoc.Text = hoso;
                formContainer.Close();
            };
            formContainer.Controls.Add(previousControl);
            formContainer.ShowDialog();
        }
    }
}
