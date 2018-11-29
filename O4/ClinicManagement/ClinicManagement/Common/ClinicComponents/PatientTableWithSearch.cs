using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Common.ClinicComponents
{
    public partial class PatientTableWithSearch : UserControl
    {
        public PatientTableWithSearch()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            var enterEvent = new KeyEventHandler((sender, e) =>
            {
                if (e.KeyCode != Keys.Enter)
                    return;
                var entity = new DTO.BenhNhanDTO() {
                    MaBenhNhan = this.txtMaBenhNhan.Text,
                    HoTen = this.txtHoTen.Text,
                    CMND = this.txtCMND.Text };
                this.SearchCompleted?.Invoke(this, entity);
            });

            this.txtMaBenhNhan.TextBox.KeyDown += enterEvent;
            this.txtHoTen.TextBox.KeyDown += enterEvent;
            this.txtCMND.TextBox.KeyDown += enterEvent;

            this.SearchCompleted += PatientTableWithSearch_SearchCompleted;
            this.table.DoubleClick += Table_DoubleClick;
        }

        private void Table_DoubleClick(object sender, DTO.BenhNhanDTO e)
        {
            this.DoubleClick?.Invoke(this, e);
        }

        private void PatientTableWithSearch_SearchCompleted(object sender, DTO.BenhNhanDTO e)
        {
            DevExpress.Utils.WaitDialogForm f = new DevExpress.Utils.WaitDialogForm();
            this.timer1.Tick += new EventHandler((s, er) =>
            {
                var interval = (DateTime.Now - this.time).TotalSeconds;
                if (!f.IsDisposed && interval > 5)
                {
                    this.timer1.Stop();
                    f.Close();
                    MessageBox.Show("Không thể load dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            this.timer1.Interval = 1000;
            this.time = DateTime.Now;
            this.timer1.Start();
            this.searchBenhNhan(e, (listPatients, result) =>
            {
                f.Close();
                this.timer1.Stop();
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.table.fetchData(listPatients);
                } else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }

        public void searchBenhNhan(DTO.BenhNhanDTO benhNhanEntity, Action<List<DTO.BenhNhanDTO>, string> completion)
        {
            var listResult = new List<DTO.BenhNhanDTO>();
            var bus = new BUS.Mdl.TiepNhanModule();
            var result = bus.SearchBenhNhan(benhNhanEntity, out listResult, 0);
            completion(listResult, result);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var entity = new DTO.BenhNhanDTO {
                MaBenhNhan = this.txtMaBenhNhan.Text,
                HoTen = this.txtHoTen.Text,
                CMND = this.txtCMND.Text };

            this.SearchCompleted?.Invoke(this, entity);
        }

        private event EventHandler<DTO.BenhNhanDTO> SearchCompleted;
        private BUS.Imp.BenhNhanBUS benhNhanBus = new BUS.Imp.BenhNhanBUS();

        

        private DateTime time;
        public event EventHandler<DTO.BenhNhanDTO> DoubleClick;
    }
}
