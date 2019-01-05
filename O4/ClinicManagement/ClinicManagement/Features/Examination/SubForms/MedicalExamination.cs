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
        private const int topPadding = 20;
        private AssignTests assignTest;
        private CreatePrescriptions createPrescription;
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        private DTO.HoSoBenhAnDTO hoSoBenhAn;
        private decimal tongChiPhi = 0;

        public event EventHandler reloadRequest;

        public MedicalExamination(DTO.HoSoBenhAnDTO hoso)
        {
            InitializeComponent();
            this.hoSoBenhAn = hoso;
            this.setupView();
        }

        private void setupView()
        {
            this.setupAssignTests();
            this.setupCreatePrescriptions();

            this.createPrescription.Visible = false;

            Application.AddMessageFilter(this);

            this.txtChiPhi.Text = tongChiPhi.ToString();

            var benhNhan = this.bus.getBenhNhan(this.hoSoBenhAn.MaBenhNhan);
            this.patientMainInformation.binding(benhNhan);
            this.txtYeuCauKham.Text = this.hoSoBenhAn.YeuCauKham;
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

        private void setupAssignTests()
        {
            var location = new Point(this.radioLayout.Location.X, this.radioLayout.Location.Y + this.radioLayout.Height + topPadding);
            this.assignTest = new SubForms.AssignTests()
            {
                Location = location,
                Width = this.radioLayout.Width,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            this.assignTest.ChiPhiChanged += AssignTest_AddAssign;
            this.assignTest.ActiveConfirm += AssignTest_CheckedListControlChanged;
            this.mainPanel.Controls.Add(assignTest);
        }

        private void AssignTest_CheckedListControlChanged(object sender, bool e)
        {
            this.btnXacNhan.Enabled = e;
        }

        private void AssignTest_AddAssign(object sender, decimal e)
        {
            this.tongChiPhi += e;
            this.txtChiPhi.Text = this.tongChiPhi.ToString();
        }

        private void setupCreatePrescriptions()
        {
            var location = new Point(this.radioLayout.Location.X, this.radioLayout.Location.Y + this.radioLayout.Height + topPadding);
            this.createPrescription = new SubForms.CreatePrescriptions()
            {
                Location = location,
                Width = this.radioLayout.Width,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            this.createPrescription.ActiveConfirm += (obj, isActive) =>
            {
                this.btnXacNhan.Enabled = isActive;
            };

            this.mainPanel.Controls.Add(createPrescription);
        }

        private void radKeThuoc_CheckedChanged(object sender, EventArgs e)
        {
            this.radXetNghiem.Checked = !this.radKeThuoc.Checked;
            if (this.radKeThuoc.Checked)
            {
                this.createPrescription.Visible = true;
                this.assignTest.Visible = false;
                this.assignTest.refresh();
                this.tongChiPhi = 0;
                this.txtChiPhi.Text = this.tongChiPhi.ToString();
                this.btnXacNhan.Enabled = false;
            }
        }

        private void radXetNghiem_CheckedChanged(object sender, EventArgs e)
        {
            this.radKeThuoc.Checked = !this.radXetNghiem.Checked;
            if (this.radXetNghiem.Checked)
            {
                this.createPrescription.Visible = false;
                this.assignTest.Visible = true;
                this.btnXacNhan.Enabled = false;
            }
        }

        private void ExaminationHome_ControlRemoved(object sender, ControlEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.hoSoBenhAn.ChuanDoan = this.txtChuanDoanBenh.Text;
            Model.ConfirmUserControl control = null;
            var formContainer = new Form()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };


            if (radXetNghiem.Checked)
            {
                var listXetNghiem = this.assignTest.getListXetNghiem();
                control = new SubForms.AssignTestsConfirm(this.hoSoBenhAn, listXetNghiem, this.tongChiPhi)
                {
                    Left = Top = 0,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top
                };
            }
            else
            {
                var listOfMedicine = this.createPrescription.getListOfMedicine();
                control = new SubForms.CreatePrescriptionsConfirm(this.hoSoBenhAn, listOfMedicine, this.tongChiPhi)
                {
                    Left = Top = 0,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top
                };
            }
            control.DidConfirm += (obj, eag) =>
            {
                formContainer.Close();
                var parent = (Form)this.Parent;
                parent.Close();
                this.reloadRequest?.Invoke(this, e);
            };
            formContainer.Controls.Add(control);
            formContainer.ShowDialog();
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
    }
}
