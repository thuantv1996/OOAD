using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClinicManagement
{
    public partial class MainForm : Form
    {
        public MainForm(ClinicManagement.Common.User user)
        {
            InitializeComponent();
            this.user = user;
            this.setupView();
        }

        private void setupView()
        {
            this.panelFormControl.BackColor = Common.SourceLibrary.ClinicBackgroundColor;

            this.menuControl = new Common.ClinicComponents.MenuControl();
            this.menuControl.Dock = DockStyle.Fill;
            this.panelMenu.Controls.Add(this.menuControl);
            this.listContent = new List<UserControl>();
            switch (this.user.UserType)
            {
                case ClinicManagement.Common.UserType.reception:
                    {
                        this.updateMenuControl(new string[] { "Trang chủ", "Tiếp nhận bệnh nhân", "Hồ sơ mới", "Thanh toán"});
                        this.listContent.Clear();
                        this.listContent.AddRange(new UserControl[]
                        {
                            new ClinicManagement.Features.Reception.Main.ReceptionHome(),
                            new ClinicManagement.Features.Reception.Main.Reception(),
                            new ClinicManagement.Features.Reception.Main.ReceptionCreatePatientRecord(),
                            new ClinicManagement.Features.Payment.Main.PaymentHome()
                        });
                        break;
                    }
                case ClinicManagement.Common.UserType.examination:
                    {
                        this.updateMenuControl(new string[] { "Trang chủ", "Kết quả xét nghiệm" });
                        this.listContent.Clear();
                        this.listContent.AddRange(new UserControl[]
                        {
                            new ClinicManagement.Features.Examination.Main.ExaminationHome(),
                            new ClinicManagement.Features.Examination.Main.ExaminationAfterTests()
                        });
                        break;
                    }
                case Common.UserType.analysis:
                    {
                        this.updateMenuControl(new string[] { "Trang chủ"});
                        this.listContent.Clear();
                        this.listContent.AddRange(new UserControl[]
                        {
                            new ClinicManagement.Features.Analysis.Main.AnalysisHome()
                        });
                        break;
                    }
            }

            var vitri = user.RoomId.Equals(COM.Constant.ID_LNV_BS) ? "Bác sĩ khám" : user.RoomId.Equals(COM.Constant.ID_LNV_TN) ? "Nhân viên tiếp nhận" : "Bác sĩ xét nghiệm";
            this.menuControl.updateUserInformation(user.UserName, vitri);
            this.listContent.ForEach(control =>
            {
                control.Dock = DockStyle.Fill;
                this.panelContent.Controls.Add(control);
                this.menuControl.listAction.Add((sender, e) => { control.BringToFront(); });
            });

            this.menuControl.LogOut += MenuControl_LogOut;
        }

        private void MenuControl_LogOut(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateMenuControl(string[] items)
        {
            this.menuControl.Items = items;
            this.menuControl.ShowSelectedItem = false;
        }

        private void btnExitForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private ClinicManagement.Common.User user;
        private Common.ClinicComponents.MenuControl menuControl;
        private List<UserControl> listContent;
    }
}
