using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace ClinicManagement.Features.Payment.Subforms
{
    public partial class PaymentDetail : UserControl
    {
        private Bus.PaymentBus bus = Bus.PaymentBus.SharedInstance;
        private DTO.HoSoBenhAnDTO hoso;
        private List<DTO.KetQuaXetNghiemDTO> danhSachChonThanhToan = new List<DTO.KetQuaXetNghiemDTO>();
        private decimal tongChiPhi = 0;
        private BenhNhanDTO benhNhan;

        public PaymentDetail(DTO.HoSoBenhAnDTO hoso)
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
            this.chkLstChuaThanhToan.Items.Clear();
            this.danhSachChonThanhToan.Clear();
            this.btnSave.Enabled = false;
            this.tongChiPhi = 0;
            this.txtTongSoTien.Text = String.Format("{0} VNĐ", this.tongChiPhi);

            this.benhNhan = this.bus.getBenhNhan(this.hoso.MaBenhNhan);
            this.txtHoTen.Text = benhNhan.HoTen;
            this.txtSTT.Text = this.hoso.SoThuTu.ToString();

            this.bus.getListXetNghiemByHoSo(this.hoso.MaHoSo, (listKQXN, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    var danhSachDaThanhToan = new List<Model.ThanhToanView>();
                    danhSachDaThanhToan.Add(new Model.ThanhToanView()
                    {
                        TenThanhToan = "Chi phí khám",
                        ChiPhi = Common.SourceLibrary.PhiKhamTiepNhan
                    });

                    listKQXN.ForEach(kqxn =>
                    {
                        var xetNghiem = this.bus.getXetNghiemInformation(kqxn.MaXetNghiem);
                        if (xetNghiem != null)
                        {
                            if (kqxn.ThanhToan)
                            {
                                danhSachDaThanhToan.Add(new Model.ThanhToanView()
                                {
                                    TenThanhToan = xetNghiem.TenXetNghiem,
                                    ChiPhi = xetNghiem.ChiPhi
                                });
                            } else
                            {
                                DevExpress.XtraEditors.Controls.CheckedListBoxItem newItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(xetNghiem, true) { Description = xetNghiem.TenXetNghiem };
                                this.danhSachChonThanhToan.Add(kqxn);
                                this.chkLstChuaThanhToan.Items.Add(newItem);
                                this.tongChiPhi += xetNghiem.ChiPhi;
                                this.btnSave.Enabled = true;
                            }
                        }
                    });

                    this.txtTongSoTien.Text = this.tongChiPhi.ToString();
                    this.grdDaThanhToanControl.DataSource = Common.ClinicBus.ConvertToDatatable(danhSachDaThanhToan);
                }
            });

        }

        private void chkLstChuaThanhToan_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var item = this.chkLstChuaThanhToan.Items[e.Index];
            var xetNghiem = (DTO.XetNghiemDTO)item.Value;
            this.tongChiPhi += e.State == CheckState.Unchecked ? -xetNghiem.ChiPhi : xetNghiem.ChiPhi;
            this.txtTongSoTien.Text = this.tongChiPhi.ToString();

            var maHoSo = this.hoso.MaHoSo;
            var maXetNghiem = xetNghiem.MaXetNghiem;


            if (e.State == CheckState.Checked)
            {
                var kqXN = this.bus.getKetQuaXetNghiem(maHoSo, maXetNghiem);
                this.danhSachChonThanhToan.Add(kqXN);
            } else
            {
                this.danhSachChonThanhToan.RemoveAll(kqxn => kqxn.MaHoSo.Equals(maHoSo) && kqxn.MaXetNghiem.Equals(maXetNghiem));
            }

            var existsChecked = this.chkLstChuaThanhToan.Items.ToList().FindAll(it => it.CheckState == CheckState.Checked).Count > 0;
            this.btnSave.Enabled = existsChecked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var formContainer = new Form()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };

            danhSachChonThanhToan.ForEach(kqxn =>
            {
                var xetNghiem = this.bus.getXetNghiemInformation(kqxn.MaXetNghiem);
                kqxn.TongChiPhi = xetNghiem.ChiPhi;
            });

            var confirmControl = new Subforms.PaymentConfirm(this.hoso, this.danhSachChonThanhToan)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            confirmControl.DidConfirm += (obj, ea) =>
            {
                this.bus.thanhToanProcessing(danhSachChonThanhToan, result =>
                {
                    if (result.Equals(COM.Constant.RES_SUC))
                    {
                        if (MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Report.FormThanhToan thanhToanReport = new Report.FormThanhToan()
                            {
                                DataReport = new Report.DataReportThanhToan()
                                {
                                    NgayKham = Common.ClinicBus.convertDateToView(hoso.NgayKham),
                                    TenBenhNhan = this.benhNhan.HoTen,
                                    NgaySinh = Common.ClinicBus.convertDateToView(this.benhNhan.NgaySinh),
                                    DiaChi = this.benhNhan.DiaChi,
                                    MaHoSo = hoso.MaHoSo,
                                    ChiPhiKham = String.Format("{0} VNĐ", Common.SourceLibrary.PhiKhamTiepNhan),
                                    TongChiPhi = String.Format("{0} VNĐ", this.tongChiPhi)
                                }
                            };


                            thanhToanReport.FormClosed += (objt, er) =>
                            {
                                formContainer.Close();
                                this.fetchData();
                            };
                            thanhToanReport.ShowDialog();
                        }
                    } else
                    {
                        MessageBox.Show("Thanh toán thất bại, vui lòng kiểm tra lại hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            };

            formContainer.Controls.Add(confirmControl);
            formContainer.ShowDialog();
        }
    }
}
