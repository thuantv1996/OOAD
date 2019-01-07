using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClinicManagement.Features.Examination.SubForms
{
    public partial class MedicalExamination : UserControl, IMessageFilter
    {
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        private DTO.HoSoBenhAnDTO hoSoBenhAn;
        private decimal totalCharge = 0;
        private Size resultSize = new Size(1115, 280);

        private List<DTO.XetNghiemDTO> listXetNghiem;
        private List<DTO.ChiTietDonThuocDTO> listThuoc;
        private DTO.BenhNhanDTO benhNhan;

        public event EventHandler reloadRequest;

        public MedicalExamination(DTO.HoSoBenhAnDTO hoso)
        {
            InitializeComponent();
            this.hoSoBenhAn = hoso;
            this.setupView();
        }

        private void setupView()
        { 
            Application.AddMessageFilter(this);

            this.txtChiPhi.Text = totalCharge.ToString();
            this.benhNhan = this.bus.getBenhNhan(this.hoSoBenhAn.MaBenhNhan);
            this.patientMainInformation.binding(benhNhan);
            this.txtYeuCauKham.Text = this.hoSoBenhAn.YeuCauKham;
            var phong = this.bus.getPhong(Common.User.SharedInstance.RoomId);
            this.txtPhong.Text = phong != null ? phong.TenPhong : "";
            this.bus.getListNhanVien((listNhanVien, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listNhanVien.ForEach(nv =>
                    {
                        cbBacSi.Items.Add(nv);
                    });
                    this.cbBacSi.SelectedIndex = listNhanVien.FindIndex(nv => nv.MaNV.Equals(Common.User.SharedInstance.UserId));
                }
            });

            this.panelResult.Height = 0;
        }

        //==================================================================
        private bool mFiltering;
        public bool PreFilterMessage(ref Message m)
        {
            // Force WM_MOUSEWHEEL message to be processed by the panel 
            if (m.Msg == 0x020a && !mFiltering)
            {
                mFiltering = true;
                SendMessage(mainPanel.Handle, m.Msg, m.WParam, m.LParam);
                m.Result = IntPtr.Zero;  // Don't pass it to the parent window 
                mFiltering = false;
                return true;  // Don't let the focused control see it 
            }
            return false;
        }
        // P/Invoke declarations 
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        //==================================================================

        private void ExaminationHome_ControlRemoved(object sender, ControlEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.hoSoBenhAn.NgayKham = DateTime.Now.ToString("yyyyMMdd");
            this.hoSoBenhAn.ChuanDoan = this.txtChuanDoanBenh.getText;
            this.hoSoBenhAn.TrieuChung = this.txtTrieuChung.getText;

            if (this.cbBacSi.SelectedIndex >= 0)
            {
                var bacsi = (DTO.NhanVienDTO)this.cbBacSi.SelectedItem;
                this.hoSoBenhAn.MaBacSi = bacsi.MaNV;
            }
            
            if (this.listXetNghiem == null)
            {
                this.bus.checkInput(this.hoSoBenhAn, (result, listMessageError) =>
                {
                    if (result.Equals(COM.Constant.RES_FAI))
                    {
                        string msg = "";
                        listMessageError.ForEach(m => msg += m + "\n");
                        MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //If success
                    this.showConfirm();
                });
            } else
            {
                this.showConfirm();
            }

        }

        private void showConfirm()
        {
            var chiphiString = String.Format("{0} VNĐ", this.totalCharge);
            var confirmControl = new ExaminationConfirm(this.hoSoBenhAn, this.txtPhong.Text, this.benhNhan, chiphiString, this.listThuoc, this.listXetNghiem)
            {
                Left = Top = 0,
                Dock = DockStyle.Fill
            };

            confirmControl.DidBack += ConfirmControl_DidBack;
            confirmControl.DidConfirm += ConfirmControl_DidConfirm;
            this.Parent?.Controls.Add(confirmControl);
            confirmControl.BringToFront();
        }

        private void ConfirmControl_DidConfirm(UserControl control)
        {
            if (this.listThuoc != null)
            {
                this.assignMedical();
            }
            else if (this.listXetNghiem != null)
            {
                this.assignTest();
                //Save hoso not finish
            } else
            {
                this.finishHoSo();
            }
        }

        private void ConfirmControl_DidBack(UserControl control)
        {
            this.BringToFront();
            this.Parent?.Controls.Remove(control);
        }

        private void lnkDonThuocGanNhat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formContainer = new Form()
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            var hoso = this.bus.getLatestHoSo(this.hoSoBenhAn.MaBenhNhan);
            if (hoso.Equals(COM.Constant.RES_FAI) || hoso.NgayKham == null)
            {
                MessageBox.Show("Không tồn tại hồ sơ trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var ctrl = new SubForms.LatestPrescription(hoso)
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Left = Top = 0
            };

            formContainer.Load += (obj, er) =>
            {
                ctrl.loadData();
            };

            formContainer.Controls.Add(ctrl);
            formContainer.ShowDialog();
        }

        private void btnAssignTests_Click(object sender, EventArgs e)
        {
            var formContainer = new Form()
            {
                Size = new Size(850, 600),
                StartPosition = FormStartPosition.CenterParent
            };

            var assignControl = new AssignTests(this.listXetNghiem)
            {
                Dock = DockStyle.Fill
            };

            assignControl.DidAssign += (totalCharge, listTest) =>
            {
                formContainer.Close();

                this.btnCreateMedical.Enabled = false;

                this.totalCharge = totalCharge;
                this.txtChiPhi.Text = totalCharge + " VNĐ";

                this.panelResult.Height = this.resultSize.Height;

                var testResult = new AssignTestsConfirm(listTest)
                {
                    Dock = DockStyle.Fill
                };

                testResult.ClearEvent += (obj, er) =>
                {
                    this.clearResultGroup();
                };
                this.listXetNghiem = testResult.DanhSachXetNghiem;

                this.groupResult.Controls.Clear();
                this.groupResult.Controls.Add(testResult);
                this.groupResult.Text = "Danh sách xét nghiệm";
            };

            formContainer.Controls.Add(assignControl);
            formContainer.ShowDialog();
        }

        private void btnCreateMedical_Click(object sender, EventArgs e)
        {
            var formContainer = new Form()
            {
                Size = new Size(850, 600),
                StartPosition = FormStartPosition.CenterParent
            };

            var createPrescriptionControl = new CreatePrescriptions(this.listThuoc)
            {
                Dock = DockStyle.Fill
            };

            createPrescriptionControl.DidCreate += (listThuoc) =>
            {
                formContainer.Close();

                this.btnAssignTests.Enabled = false;

                this.panelResult.Height = this.resultSize.Height;

                this.listThuoc = listThuoc;
                var medicalResult = new CreatePrescriptionsConfirm(listThuoc)
                {
                    Dock = DockStyle.Fill
                };

                medicalResult.ClearEvent += (obj, er) =>
                {
                    this.clearResultGroup();
                };

                this.groupResult.Controls.Clear();
                this.groupResult.Controls.Add(medicalResult);
                this.groupResult.Text = "Đơn thuốc";
            };

            formContainer.Controls.Add(createPrescriptionControl);
            formContainer.ShowDialog();
        }

        private void clearResultGroup()
        {
            this.panelResult.Height = 0;
            this.totalCharge = 0;
            this.txtChiPhi.Text = String.Format("{0} VNĐ", this.totalCharge);
            this.groupResult.Controls.Clear();
            this.listXetNghiem?.Clear();
            this.listXetNghiem = null;
            this.listThuoc?.Clear();
            this.listThuoc = null;
            this.btnCreateMedical.Enabled = this.btnAssignTests.Enabled = true;
        }

        //MARK: - Logic
        //Chỉ định xét nghiệm
        private void assignTest()
        {
            this.bus.assignTests(this.hoSoBenhAn, this.listXetNghiem, result =>
            {
                this.checkResult(result, false);
            });
        }

        //Kê đơn thuốc
        private void assignMedical()
        {
            this.bus.keDonThuoc(this.hoSoBenhAn, this.listThuoc, result =>
            {
                this.checkResult(result);
            });
        }

        private void showReport(Form currentForm)
        {
            string tenBacSi = "";
            if (this.cbBacSi.SelectedIndex >= 0)
            {
                var bacsi = (DTO.NhanVienDTO)this.cbBacSi.SelectedItem;
                tenBacSi = bacsi.HoTenNV;
            }
            Report.FormHoSo hosoForm = new Report.FormHoSo()
            {
                StartPosition = FormStartPosition.CenterParent,
                DataReport = new Report.DataReportPhieuKhamBenh()
                {
                    TenBenhNhan = this.benhNhan.HoTen,
                    DiaChi = this.benhNhan.DiaChi,
                    TenBacSi = tenBacSi,
                    ChieuChung = this.txtTrieuChung.getText,
                    NgayKham = DateTime.Now.ToString("dd/MM/yyyy"),
                    SDTBenhNhan = this.benhNhan.SoDienThoai,
                    NgaySinh = Common.ClinicBus.convertDateToView(this.benhNhan.NgaySinh),
                    ChuanDoan = this.txtChuanDoanBenh.getText,
                    MaHoSo = this.hoSoBenhAn.MaHoSo
                }
            };

            hosoForm.FormClosed += (obj, er) =>
            {
                reloadRequest?.Invoke(this, null);
                currentForm.Close();
            };

            hosoForm.ShowDialog();
        }

        //Khám bệnh không kê đơn và không xét nghiệm
        private void finishHoSo()
        {
            this.bus.finishKham(this.hoSoBenhAn, result=>
            {
                this.checkResult(result);
            });
        }

        private void showFinalResultScreen(bool isFinish)
        {
            var parentForm = (Form)this.Parent;

            var chiphiString = String.Format("{0} VNĐ", this.totalCharge);
            var finalScreen = new ExaminationConfirm(this.hoSoBenhAn, this.txtPhong.Text, this.benhNhan, chiphiString, this.listThuoc, this.listXetNghiem, false)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            finalScreen.DidConfirm += (control) =>
            {
                if (isFinish)
                {
                    this.showReport(parentForm);
                } else
                {
                    parentForm.Close();
                    reloadRequest?.Invoke(this, null);
                }
            };


            parentForm.Controls.Clear();
            parentForm.Controls.Add(finalScreen);
        }

        private void checkResult(string result, bool isFinish = true)
        {
            if (result.Equals(COM.Constant.RES_SUC))
            {
                if (MessageBox.Show("Lưu thông tin khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.showFinalResultScreen(isFinish);
                }
            }
            else
            {
                if (MessageBox.Show("Lưu thông tin thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    this.BringToFront();
                    if (this.Parent?.Controls.Count >= 2)
                    {
                        this.Parent.Controls.RemoveAt(1);
                    }
                }
            }
        }
    }
}
