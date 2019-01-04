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
        private List<DTO.HoSoBenhAnDTO> listHoSoTruoc = new List<DTO.HoSoBenhAnDTO>();
        private Reception.Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;
        public event EventHandler Recepted;

        public ReceptionControl()
        {
            InitializeComponent();
            this.setupView();
        }

        public ReceptionControl(DTO.BenhNhanDTO patient)
        {
            InitializeComponent();
            this.setupView();
            this.patient = patient;
            this.setupData(patient);
            this.fillMainInformation();
        }

        private void setupView()
        {
            this.btnBack.Visible = false;
            var size = groupBox1.Size;
            this.patientMainInformation1 = new Common.ClinicComponents.PatientMainInformation()
            {
                Location = new Point(13, 6),
                Size = new Size(size.Width, this.groupBox1.Location.Y - 6),
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            this.Controls.Add(this.patientMainInformation1);
        }

        public void setupData(DTO.BenhNhanDTO patient)
        {
            this.patientMainInformation1.binding(patient);
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
                        this.cbLoaiHoSo.Properties.Items.Add(loai);
                    });
                }
            });

            this.bus.getListMaHoSoTruoc(this.patient.MaBenhNhan, (listResult, result) =>
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
                        this.cbPhong.Properties.Items.Add(phong);
                    });

                }
            });

            this.bus.getListNhanVien((listResult, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listResult.ForEach(nhanVien =>
                    {
                        this.cbNguoiTiepNhan.Properties.Items.Add(nhanVien);
                    });

                }
            });
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var loaiHoSo = (DTO.LoaiHoSoDTO)this.cbLoaiHoSo.SelectedItem;
            var nguoiTiepNhan = (DTO.NhanVienDTO)this.cbNguoiTiepNhan.SelectedItem;
            var phongKham = (DTO.PhongKhamDTO)this.cbPhong.SelectedItem;

            if (this.patient == null) return;

            var hoso = new DTO.HoSoBenhAnDTO()
            {
                MaBenhNhan = this.patient.MaBenhNhan,
                MaHoSoTruoc = this.cbMaHoSoTruoc.Text,
                MaLoaiHoSo = loaiHoSo != null ? loaiHoSo.MaLoaiHoSo : "",
                MaNguoiTN = nguoiTiepNhan != null ? nguoiTiepNhan.MaNV : "",
                NgayTiepNhan = ClinicManagement.Common.ClinicBus.convertViewToDate(this.txtNgayTiepNhan.Text),
                YeuCauKham = this.txtYeuCauKham.Text,
                MaPhongKham = phongKham != null ? phongKham.MaPhong : ""
            };
            var thanhToan = new DTO.ThanhToanDTO() { ChiPhiKham = ClinicManagement.Common.SourceLibrary.PhiKhamTiepNhan };

            this.bus.confirmReception(hoso, thanhToan,(stt, result, listMessageError) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    MessageBox.Show(String.Format("Tiếp nhận thành công!\nSố thứ tự là: {0}", stt), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Recepted?.Invoke(this, e);
                    if (this.Parent is Form) {
                        var formParent = (Form)this.Parent;
                        formParent.Close();
                    }
                }
                else
                {
                    var msg = "";
                    listMessageError.ForEach(error =>
                    {
                        msg += error + "\n";
                    });
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
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

        private Common.ClinicComponents.PatientMainInformation patientMainInformation1;

        private void cbLoaiHoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loaiHoSo = (DTO.LoaiHoSoDTO)this.cbLoaiHoSo.SelectedItem;
            if (loaiHoSo.MaLoaiHoSo.Equals(BUS.Com.BusConstant.HS_KHAMMOI))
            {
                this.cbMaHoSoTruoc.Text = "";
                this.cbMaHoSoTruoc.Enabled = false;
            } else
            {
                this.cbMaHoSoTruoc.Enabled = true;
            }
        }
    }
}
