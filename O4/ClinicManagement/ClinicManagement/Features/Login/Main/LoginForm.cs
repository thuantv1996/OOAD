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

        private void setupChangePassword(string userName, string password)
        {
            var account = new DTO.TaiKhoanEnity() {
                TenDangNhap = userName,
                MatKhau = password };
            this.changePasswordControl = new SubForms.ChangePasswordControl(account);
            var initX = (this.Size.Width - this.changePasswordControl.Size.Width) / 2;
            var initY = (this.Size.Height - this.changePasswordControl.Size.Height) / 2;
            this.changePasswordControl.Location = new Point(initX, initY);
            this.changePasswordControl.Anchor = AnchorStyles.None;
            this.backgroundImage.Controls.Add(this.changePasswordControl);
            this.changePasswordControl.changeCompletion += ChangePasswordControl_changeCompletion;
        }

        private void ChangePasswordControl_changeCompletion(object sender, DTO.TaiKhoanEnity e)
        {
            this.bus.ChangePassword(e, (listMessageError, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.loginSuccessful(e);
                } else if (result.Equals(COM.Constant.RES_FAI)) {
                    var messageError = "";
                    listMessageError.ForEach((error) =>
                    {
                        if (error.IdError.Equals(COM.Constant.MES_PRE))
                        {
                            messageError += error.Message + "\n";
                        }
                    });
                    MessageBox.Show(messageError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }

        private void LoginControl_loginCompleted(object sender, DTO.TaiKhoanEnity loginInfo)
        {
            this.bus.Login(loginInfo, (listMessageError, idScreen, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.loginSuccessful(loginInfo);
                }
                else if (result.Equals(COM.Constant.RES_FAI))
                {
                    var messageError = "";
                    listMessageError.ForEach((error) =>
                    {
                        if (error.IdError.Equals(COM.Constant.MES_PRE))
                        {
                            messageError += error.Message + "\n";
                        }
                    });

                    switch (idScreen)
                    {
                        case Bus.LoginBus.ID_ERROR_BACK_LOGIN:
                            MessageBox.Show(messageError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        case Bus.LoginBus.ID_ERROR_CHANGE_PASSWORD:
                            var resultMessageBox = MessageBox.Show(messageError, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            if (resultMessageBox == DialogResult.OK)
                            {
                                //Show change passwordscreen
                                this.backgroundImage.Controls.Remove(this.loginControl);
                                this.setupChangePassword(loginInfo.TenDangNhap, loginInfo.MatKhau);
                                break;
                            }
                            else
                                return;
                        default: return;
                    }
                }
            });
        }


        private void loginSuccessful(DTO.TaiKhoanEnity account)
        {
            var mainForm = new ClinicManagement.MainForm(new Model.User(Model.UserType.reception));
            this.Hide();
            mainForm.ShowDialog();
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
        private SubForms.ChangePasswordControl changePasswordControl;
    }
}
