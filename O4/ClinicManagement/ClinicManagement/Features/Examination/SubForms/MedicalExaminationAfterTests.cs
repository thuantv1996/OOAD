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
        private SubForms.CreatePrescriptions createPrescription;
        private DTO.HoSoBenhAnDTO hoSoBenhAn;
        public MedicalExaminationAfterTests(DTO.HoSoBenhAnDTO hoso)
        {
            InitializeComponent();
            this.hoSoBenhAn = hoso;
            this.setupView();
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

        private void setupView()
        {
            Application.AddMessageFilter(this);
            var benhNhan = this.bus.getBenhNhan(this.hoSoBenhAn.MaBenhNhan);
            this.patientMainInformation.binding(benhNhan);

            var location = new Point(this.txtChuanDoanBenh.Location.X, this.txtChuanDoanBenh.Location.Y + this.txtChuanDoanBenh.Height + 20);
            this.createPrescription = new SubForms.CreatePrescriptions()
            {
                Location = location,
                Width = this.txtChuanDoanBenh.Width,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            this.mainPanel.Controls.Add(createPrescription);
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
            var listOfMedicine = this.createPrescription.getListOfMedicine();
            control = new SubForms.CreatePrescriptionsConfirm(this.hoSoBenhAn, listOfMedicine, 0)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            control.DidConfirm += (obj, eag) =>
            {
                formContainer.Close();
                var parent = (Form)this.Parent;
                parent.Close();
            };
            formContainer.Controls.Add(control);
            formContainer.ShowDialog();
        }
    }
}
