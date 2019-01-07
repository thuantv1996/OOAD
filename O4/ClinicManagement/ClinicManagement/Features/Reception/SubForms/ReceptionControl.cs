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
            this.patient = patient;
            this.patientMainInformation1.binding(patient);
            this.fillMainInformation();
        }

        private void fillMainInformation() {
            var toDay = DateTime.Today;

            this.txtNgayTiepNhan.Text = toDay.ToString("dd/MM/yyyy");
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
                NgayTiepNhan = DateTime.Now.ToString("yyyyMMdd"),
                YeuCauKham = this.txtYeuCauKham.Text,
                MaPhongKham = phongKham != null ? phongKham.MaPhong : ""
            };
            var thanhToan = new DTO.ThanhToanDTO() { ChiPhiKham = ClinicManagement.Common.SourceLibrary.PhiKhamTiepNhan };

            this.bus.confirmReception(hoso, thanhToan,(stt, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    DevExpress.Utils.WaitDialogForm f = new DevExpress.Utils.WaitDialogForm();
                    f.Show();

                    Report.FormSoThuTu soThuTuForm = new Report.FormSoThuTu()
                    {
                        AutoSize = true,
                        StartPosition = FormStartPosition.CenterParent,
                        DataReport = new Report.DataReportSoThuTu()
                        {
                            MaHoSo = hoso.MaHoSo,
                            TenBenhNhan = patient.HoTen,
                            DiaChi = patient.DiaChi,
                            NgayKham = DateTime.Now.ToString("dd/MM/yyyy"),
                            SoThuTu = hoso.SoThuTu.ToString(),
                            TenPhong = phongKham?.TenPhong
                        }
                    };

                    soThuTuForm.FormClosed += (obj, er) =>
                    {
                        if (this.Parent is Form)
                        {
                            var formParent = (Form)this.Parent;
                            formParent.Close();
                        }
                    };


                    f.Close();
                    soThuTuForm.ShowDialog();
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
                NgayTiepNhan = DateTime.Now.ToString("yyyyMMdd"),
                YeuCauKham = this.txtYeuCauKham.getText,
                MaPhongKham = phongKham != null ? phongKham.MaPhong : ""
            };
            var thanhToan = new DTO.ThanhToanDTO() { ChiPhiKham = ClinicManagement.Common.SourceLibrary.PhiKhamTiepNhan };


            this.bus.TiepNhanInputCheck(hoso, thanhToan, (result, listMessageError) =>
            {
                if (result.Equals(COM.Constant.RES_FAI))
                {
                    var msg = "";
                    listMessageError.ForEach(m => msg += String.Format("{0}\n", m));
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.btnConfirm.BringToFront();
                this.btnBack.Visible = true;
                this.cbLoaiHoSo.Enabled
                    = this.cbMaHoSoTruoc.Enabled
                    = this.cbNguoiTiepNhan.Enabled
                    = this.cbPhong.Enabled
                    = this.txtYeuCauKham.Enabled
                    = false;
            });
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
                this.btnSearch.Enabled = false;
            } else
            {
                this.cbMaHoSoTruoc.Enabled = true;
                this.btnSearch.Enabled = true;
            }
        }
    }
}
