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
    public partial class MedicalExaminationAfterTests : UserControl, IMessageFilter
    {
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        private DTO.HoSoBenhAnDTO hoSoBenhAn;
        private Size resultSize = new Size(1115, 280);

        private List<DTO.ChiTietDonThuocDTO> listThuoc;
        private DTO.BenhNhanDTO benhNhan;

        public event EventHandler reloadRequest;

        public MedicalExaminationAfterTests(DTO.HoSoBenhAnDTO hoso)
        {
            InitializeComponent();
            this.hoSoBenhAn = hoso;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.fetchData();
        }

        //MARK: Load data
        private void fetchData()
        {
            Application.AddMessageFilter(this);

            this.benhNhan = this.bus.getBenhNhan(this.hoSoBenhAn.MaBenhNhan);
            this.patientMainInformation.binding(benhNhan);
            this.txtYeuCauKham.Text = this.hoSoBenhAn.YeuCauKham;
            var phong = this.bus.getPhong(Common.User.SharedInstance.RoomId);
            this.txtPhong.Text = phong != null ? phong.TenPhong : "";

            this.txtChuanDoanBenh.Text = this.hoSoBenhAn.ChuanDoan;
            this.txtTrieuChung.Text = this.hoSoBenhAn.TrieuChung;

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

            this.bus.getListKetQuaXetNghiem(this.hoSoBenhAn.MaHoSo, (listKQXNView, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.grdKetQuaXetNghiem.DataSource = Common.ClinicBus.ConvertToDatatable(listKQXNView);
                }
            });
            this.panelResult.Height = 0;
        }
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

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.hoSoBenhAn.TrieuChung = this.txtTrieuChung.getText;
            this.hoSoBenhAn.ChuanDoan = this.txtChuanDoanBenh.getText;
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
        }

        private void clearResultGroup()
        {
            this.panelResult.Height = 0;
            this.groupResult.Controls.Clear();
            this.listThuoc?.Clear();
            this.listThuoc = null;
        }

        private void showConfirm()
        {
            var confirmControl = new ExaminationConfirm(this.hoSoBenhAn, this.txtPhong.Text, this.benhNhan, null, this.listThuoc)
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
        }

        private void assignMedical()
        {
            this.bus.keDonThuoc(this.hoSoBenhAn, this.listThuoc, result =>
            {
                this.checkResult(result);
            });
        }

        private void checkResult(string result)
        {
            if (result.Equals(COM.Constant.RES_SUC))
            {
                if (MessageBox.Show("Lưu thông tin khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.showFinalResultScreen();
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

        private void showFinalResultScreen()
        {
            var parentForm = (Form)this.Parent;

            var finalScreen = new ExaminationConfirm(this.hoSoBenhAn, this.txtPhong.Text, this.benhNhan, null, this.listThuoc, null, false)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            finalScreen.DidConfirm += (control) =>
            {
                reloadRequest?.Invoke(this, null);
                parentForm.Close();
            };


            parentForm.Controls.Clear();
            parentForm.Controls.Add(finalScreen);
        }

        private void ConfirmControl_DidBack(UserControl control)
        {
            this.BringToFront();
            this.Parent?.Controls.Remove(control);
        }
    }
}
