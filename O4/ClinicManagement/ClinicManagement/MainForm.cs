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
        public MainForm(Model.User user)
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
                case Model.UserType.reception:
                    {
                        this.updateMenuControl(new string[] { "Trang chủ", "Tiếp nhận bệnh nhân", "Hồ sơ mới"});
                        this.listContent.Clear();
                        this.listContent.AddRange(new UserControl[]
                        {
                            new ClinicManagement.Features.Reception.Main.ReceptionHome(),
                            new ClinicManagement.Features.Reception.Main.Reception(),
                            new ClinicManagement.Features.Reception.Main.ReceptionCreatePatientRecord()
                        });
                        break;
                    }
                case Model.UserType.examination:
                    {
                        this.updateMenuControl(new string[] { "Trang chủ" });
                        this.listContent.Clear();
                        this.listContent.AddRange(new UserControl[]
                        {
                            new ClinicManagement.Features.Examination.SubForms.ExaminationHome()
                        });
                        break;
                    }
                default: break;
            }

            this.listContent.ForEach(control =>
            {
                control.Dock = DockStyle.Fill;
                this.panelContent.Controls.Add(control);
                this.menuControl.listAction.Add((sender, e) => { control.BringToFront(); });
            });
            
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

        private Model.User user;
        private Common.ClinicComponents.MenuControl menuControl;
        private List<UserControl> listContent;
    }
}
