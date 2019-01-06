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
    public partial class ExaminationConfirm : UserControl, IMessageFilter
    {
        private DTO.HoSoBenhAnDTO hoso;
        private string tenPhong;
        private DTO.BenhNhanDTO benhNhan;
        public List<DTO.ChiTietDonThuocDTO> danhSachThuoc;
        public List<DTO.XetNghiemDTO> danhSachXetNghiem;
        private Size resultSize = new Size(1115, 280);

        public delegate void ActionConfirmDelegate(UserControl control);

        public event ActionConfirmDelegate DidConfirm;
        public event ActionConfirmDelegate DidBack;

        public ExaminationConfirm(DTO.HoSoBenhAnDTO hoso, string tenPhong, DTO.BenhNhanDTO benhNhan, string chiphi = null, List<DTO.ChiTietDonThuocDTO> danhSachThuoc = null, List<DTO.XetNghiemDTO> danhSachXetNghiem = null, bool isConfirm = true)
        {
            InitializeComponent();
            this.hoso = hoso;
            this.tenPhong = tenPhong;
            this.benhNhan = benhNhan;
            this.danhSachThuoc = danhSachThuoc;
            this.danhSachXetNghiem = danhSachXetNghiem;
            this.btnXacNhan.Text = isConfirm ? "Xác nhận" : "OK";
            this.btnBack.Visible = isConfirm;
            if (chiphi != null)
            {
                this.txtChiPhi.Text = chiphi;
            } else
            {
                this.txtChiPhi.Visible = false;
            }

            this.ControlRemoved += ControlRemovedEvent;
            Application.AddMessageFilter(this);
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

        private void ControlRemovedEvent(object sender, ControlEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.fetchData();
        }

        private void fetchData()
        {
            this.txtYeuCauKham.Text = this.hoso.YeuCauKham;
            this.txtChuanDoan.Text = this.hoso.ChuanDoan;
            this.txtTrieuChung.Text = this.hoso.TrieuChung;
            this.txtPhong.Text = this.tenPhong;
            this.txtBacSi.Text = Common.User.SharedInstance.UserName;

            this.patientMainInformation.binding(this.benhNhan);

            if (danhSachThuoc != null)
            {
                var thuocConfirm = new CreatePrescriptionsConfirm(this.danhSachThuoc, true)
                {
                    Dock = DockStyle.Fill
                };

                this.panelResult.Height = this.resultSize.Height;

                this.groupResult.Controls.Clear();
                this.groupResult.Controls.Add(thuocConfirm);
            }
            else if (danhSachXetNghiem != null)
            {
                var xetNghiemConfirm = new AssignTestsConfirm(this.danhSachXetNghiem, true)
                {
                    Dock = DockStyle.Fill
                };

                this.panelResult.Height = this.resultSize.Height;

                this.groupResult.Controls.Clear();
                this.groupResult.Controls.Add(xetNghiemConfirm);
            }
            else
            {
                this.panelResult.Height = 0;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.DidConfirm?.Invoke(this);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DidBack?.Invoke(this);
        }
    }
}
