﻿using System;
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
            this.bus.fetchListBenhNhan((listBenhNhan, listMessageError, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.tableDataView1.fetchData(listBenhNhan);
                    completion("Load dữ liệu thành công", true);
                }
                else
                {
                    var msg = "";
                    listMessageError.ForEach((error) =>
                    {
                        msg += error.Message + "\n";
                    });
                    completion(msg, false);
                    return;
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

        private void FilterControl_SearchCompleted(object sender, BUS.Entities.BenhNhanSearchEntity e)
        {
            var filterControl = (ClinicManagement.Common.ClinicComponents.FilterUserControl)sender;
            var formContainer = (Form)(filterControl.Parent);
            this.bus.searchBenhNhan(e, (listResult, listMessageError, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.tableDataView1.fetchData(listResult);
                    formContainer.Close();
                } else
                {
                    var msg = "";
                    listMessageError.ForEach((error) =>
                    {
                        msg += error.Message + "\n";
                    });
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            formContainer.Controls.Add(detailControl);
            formContainer.ShowDialog();
        }

        private void DetailControl_CreateClick(object sender, EventArgs e)
        {
            var formContainer = (sender as UserControl).Parent;
            var receptionControl = new SubForms.ReceptionControl();
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

        private void AddPatientControl_CreateCompleted(object sender, DTO.BenhNhanEnity e)
        {
            this.bus.insertBenhNhan(e, (listMessageError, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fetchData((msg, rslt) =>
                    {
                    });
                } else
                {
                    var msg = "";
                    listMessageError.ForEach((error) =>
                    {
                        msg += error.Message + "\n";
                    });
                    MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            });
        }
    }
}
