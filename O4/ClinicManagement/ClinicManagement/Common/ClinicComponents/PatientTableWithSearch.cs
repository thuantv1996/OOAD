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
                var entity = new BUS.Entities.BenhNhanSearchEntity() {
                    MaBenhNhan = this.txtMaBenhNhan.Text,
                    TenBenhNhan = this.txtHoTen.Text,
                    CMND = this.txtCMND.Text };
                this.SearchCompleted?.Invoke(this, entity);
            });

            this.txtMaBenhNhan.TextBox.KeyDown += enterEvent;
            this.txtHoTen.TextBox.KeyDown += enterEvent;
            this.txtCMND.TextBox.KeyDown += enterEvent;

            this.SearchCompleted += PatientTableWithSearch_SearchCompleted;
        }

        private void PatientTableWithSearch_SearchCompleted(object sender, BUS.Entities.BenhNhanSearchEntity e)
        {
            DevExpress.Utils.WaitDialogForm f = new DevExpress.Utils.WaitDialogForm();
            this.searchBenhNhan(e, (listPatients, listMessageError, result) =>
            {
                f.Close();
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.table.fetchData(listPatients);
                } else
                {
                    var msg = "";
                    listMessageError.ForEach((error) =>
                    {
                        msg += error + "\n";
                    });
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }

        private void searchBenhNhan(BUS.Entities.BenhNhanSearchEntity benhNhanEntity, Action<List<DTO.BenhNhanEnity>, List<COM.MessageError>, string> completion)
        {
            Task.Run(() =>
            {
                var listResult = new List<DTO.BenhNhanEnity>();
                var listMessageError = new List<COM.MessageError>();
                var result = this.benhNhanBus.SearchBenhNhan(benhNhanEntity, out listResult, ref listMessageError);
                completion(listResult, listMessageError, result);
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var entity = new BUS.Entities.BenhNhanSearchEntity() {
                MaBenhNhan = this.txtMaBenhNhan.Text,
                TenBenhNhan = this.txtHoTen.Text,
                CMND = this.txtCMND.Text };

            this.SearchCompleted?.Invoke(this, entity);
        }

        private event EventHandler<BUS.Entities.BenhNhanSearchEntity> SearchCompleted;
        private BUS.Imp.BenhNhanImplement benhNhanBus = new BUS.Imp.BenhNhanImplement();
    }
}
