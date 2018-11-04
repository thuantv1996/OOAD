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

            this.loginControl1.loginCompleted += (sender, loginInfo) =>
            {
                this.bus.Login(loginInfo, (listMessageError, idScreen, result) =>
                {
                    if (result.Equals(COM.Constant.RES_SUC))
                    {
                        var mainForm = new ClinicManagement.MainForm(new Model.User(Model.UserType.reception));
                        this.Hide();
                        mainForm.ShowDialog();
                    } else if (result.Equals(COM.Constant.RES_FAI))
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
                                    break;
                                }
                                else
                                    return;
                            default: return;
                        }
                    }
                });
            };
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
    }
}
