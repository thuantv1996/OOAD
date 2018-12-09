using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Reception.Main
{
    public partial class ReceptionHome : UserControl
    {
        private Bus.ReceptionBus bus = Bus.ReceptionBus.SharedInstance;

        public ReceptionHome()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.tableDataView1.RowClick += (sender, e) =>
            {
                this.btnDetail.Enabled = true;
            };
        }

        private void ReceptionHome_Load(object sender, EventArgs e)
        {
            this.fetchData((msg, result) =>
            {
                if (!result)
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.fetchData((msg, result) =>
            {
                if (result)
                {
                    MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void fetchData(Action<String, bool> completion)
        {
            this.bus.fetchListBenhNhan((listBenhNhan, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.tableDataView1.fetchData(listBenhNhan);
                    completion("Load dữ liệu thành công", true);
                }
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClinicManagement.Common.ClinicComponents.FilterUserControl filterControl = new Common.ClinicComponents.FilterUserControl();
            Form formContainer = new Form() {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent };

            filterControl.Left = 0;
            filterControl.Top = 0;
            filterControl.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            filterControl.SearchCompleted += FilterControl_SearchCompleted;
            
            formContainer.Controls.Add(filterControl);
            formContainer.ShowDialog();
        }

        private void FilterControl_SearchCompleted(object sender, DTO.BenhNhanDTO e)
        {
            var filterControl = (ClinicManagement.Common.ClinicComponents.FilterUserControl)sender;
            var formContainer = (Form)(filterControl.Parent);
            this.bus.searchBenhNhan(e, (listResult, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.tableDataView1.fetchData(listResult);
                    formContainer.Close();
                } else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            var currentPatient = this.tableDataView1.PatientSelected;
            Form formContainer = new Form() {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent };

            var detailControl = new SubForms.PatientDetail(currentPatient);
            detailControl.Left = detailControl.Top = 0;
            detailControl.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            detailControl.CreateClick += DetailControl_CreateClick;
            detailControl.SaveSuccessful += DetailControl_SaveSuccessful;

            formContainer.Controls.Add(detailControl);
            formContainer.ShowDialog();
        }

        private void DetailControl_SaveSuccessful(object sender, EventArgs e)
        {
            this.fetchData((msg, rslt) => { });
        }

        private void DetailControl_CreateClick(object sender, DTO.BenhNhanDTO patient)
        {
            var formContainer = (sender as UserControl).Parent;
            var receptionControl = new SubForms.ReceptionControl(patient);
            receptionControl.Left = receptionControl.Top = 0;
            receptionControl.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            formContainer.Controls.Add(receptionControl);
            receptionControl.BringToFront();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form formContainer = new Form()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };

            var addPatientControl = new SubForms.AddPatientControl();
            addPatientControl.Left = addPatientControl.Top = 0;
            addPatientControl.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            addPatientControl.CreateCompleted += AddPatientControl_CreateCompleted;

            formContainer.Controls.Add(addPatientControl);
            formContainer.ShowDialog();
        }

        private void AddPatientControl_CreateCompleted(object sender, DTO.BenhNhanDTO e)
        {
            this.bus.insertBenhNhan(e, (result, listMessageError) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var parentForm = (Form)((Control)sender).Parent;
                    parentForm.Close();
                    this.fetchData((msg, rslt) => { });
                }
                else
                {
                    var msg = "";
                    listMessageError.ForEach(error =>
                    {
                        msg += error + "\n";
                    });
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }

        private void tableDataView1_DoubleClick(object sender, DTO.BenhNhanDTO e)
        {
            btnDetail_Click(null, null);
        }
    }
}
