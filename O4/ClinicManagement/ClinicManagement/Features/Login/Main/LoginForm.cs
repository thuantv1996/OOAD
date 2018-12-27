using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagement.Features.Login.Main;
using BUS;

namespace ClinicManagement.Features.Login.Main
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.setupLogin();
        }

        private void setupLogin()
        {
            this.loginControl = new SubForms.LoginControl();
            var initX = (this.Size.Width - this.loginControl.Size.Width) / 2;
            var initY = (this.Size.Height - this.loginControl.Size.Height) / 2;
            this.loginControl.Location = new Point(initX, initY);
            this.loginControl.Anchor = AnchorStyles.None;
            this.backgroundImage.Controls.Add(this.loginControl);

            this.loginControl.loginCompleted += LoginControl_loginCompleted;
        }

        private void LoginControl_loginCompleted(object sender, DTO.TaiKhoanDTO loginInfo)
        {
            DevExpress.Utils.WaitDialogForm f = new DevExpress.Utils.WaitDialogForm();

            this.bus.Login(loginInfo, (listMessageError, result, MaNV) =>
            {
                f.Close();
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.loginSuccessful(MaNV);
                } else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }


        private void loginSuccessful(string MaNV)
        {
            var user = Common.User.SharedInstance;
            user.UserId = MaNV;

            var nhanVienDTO = this.bus.getNhanVienInformation(MaNV);
            if (nhanVienDTO == null)
            {
                MessageBox.Show("Nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var maLoaiNV = nhanVienDTO.MaLoaiNV;
                user.RoomId = nhanVienDTO.MaPhong;
                if (maLoaiNV.Equals(COM.Constant.ID_LNV_TN))
                    user.UserType = Common.UserType.reception;
                else if (maLoaiNV.Equals(COM.Constant.ID_LNV_BS))
                    user.UserType = Common.UserType.examination;
                else if (maLoaiNV.Equals(COM.Constant.ID_LNV_XN))
                    user.UserType = Common.UserType.analysis;
            }
            user.UserName = nhanVienDTO.HoTenNV;

            var mainForm = new ClinicManagement.MainForm(user);
            this.Hide();

            mainForm.FormClosed += MainForm_FormClosed;
            mainForm.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void backgroundImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private Bus.LoginBus bus = Bus.LoginBus.Instance;
        private SubForms.LoginControl loginControl;
    }
}
