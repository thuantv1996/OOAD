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
    public partial class ExaminationHome : UserControl, IMessageFilter
    {

        private const int topPadding = 20;
        private AssignTests assignTest;
        private CreatePrescriptions createPrescription;
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        private DTO.BenhNhanDTO benhNhan;
        private const string MaPhong = "P000000001";

        public ExaminationHome(DTO.BenhNhanDTO benhNhan)
        {
            InitializeComponent();
            this.setupView();
            this.benhNhan = benhNhan;
            this.patientMainInformation.setup(benhNhan);
        }

        private void setupView()
        {
            this.setupAssignTests();
            this.setupCreatePrescriptions();

            this.createPrescription.Visible = false;

            Application.AddMessageFilter(this);

            this.bus.getListXetNghiem((result, listResult) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    
                }
            });
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
            this.mainPanel.Controls.Add(assignTest);
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
            this.mainPanel.Controls.Add(createPrescription);
        }

        private void radKeThuoc_CheckedChanged(object sender, EventArgs e)
        {
            this.radXetNghiem.Checked = !this.radKeThuoc.Checked;
            if (this.radKeThuoc.Checked)
            {
                this.createPrescription.Visible = true;
                this.assignTest.Visible = false;
            }
        }

        private void radXetNghiem_CheckedChanged(object sender, EventArgs e)
        {
            this.radKeThuoc.Checked = !this.radXetNghiem.Checked;
            if (this.radXetNghiem.Checked)
            {
                this.createPrescription.Visible = false;
                this.assignTest.Visible = true;
            }
        }

        private void ExaminationHome_ControlRemoved(object sender, ControlEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (radXetNghiem.Checked)
            {
                var listXetNghiem = this.assignTest.getListXetNghiem();
            }
        }
    }
}
