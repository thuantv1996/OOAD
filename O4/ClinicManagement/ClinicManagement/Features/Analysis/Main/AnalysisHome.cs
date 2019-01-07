using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Analysis.Main
{
    public partial class AnalysisHome : Common.ClinicComponents.MainUserControl
    {
        private Bus.AnalysisBus bus = Bus.AnalysisBus.SharedInstance;

        public AnalysisHome()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.fetchData(null);
        }

        private void fetchData(Action<bool> completion)
        {
            this.bus.getListHoSoXetNghiem((listHoSoView, result) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    this.gridControl1.DataSource = Common.ClinicBus.ConvertToDatatable(listHoSoView);
                    completion?.Invoke(true);
                }
                else
                {
                    completion?.Invoke(false);
                }
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.fetchData(result =>
            {
                if (result)
                {
                    MessageBox.Show("Dữ liệu đã được làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Làm mới dữ liệu thất bại, vui lòng kiểm tra lại hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            this.accessCell(this.getCurrentRecord());
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.accessCell(this.getCurrentRecord());
        }

        private DTO.HoSoBenhAnDTO getCurrentRecord()
        {
            var selectedIndex = this.gridView1.GetSelectedRows().First();
            DataRow row = this.gridView1.GetDataRow(selectedIndex);
            var maHoSo = row[col_MaHoSo.FieldName].ToString();
            return this.bus.getHoSoBenhAnDTO(maHoSo);
        }

        private void accessCell(DTO.HoSoBenhAnDTO hoso)
        {
            var ketquaxetnghiem = this.bus.getKetQuaXetNghiem(hoso.MaHoSo);
            if (ketquaxetnghiem == null)
            {
                MessageBox.Show("Không thể lấy kết quả xét nghiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var formContainer = new Form()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                StartPosition = FormStartPosition.CenterParent
            };

            var detailControl = new SubForms.AnalysisDetail(hoso, ketquaxetnghiem)
            {
                Left = Top = 0,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };

            detailControl.WillConfirm += (childForm, ketQuaXetNghiem) =>
            {
                var toDay = DateTime.Now;

                ketQuaXetNghiem.NgayXetNghiem = toDay.ToString("yyyyMMdd");
                this.bus.xetNghiemProcessing(ketQuaXetNghiem, result =>
                {
                    if (result.Equals(COM.Constant.RES_SUC))
                    {
                        MessageBox.Show("Ghi kết quả xét nghiệm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Show final result screen.
                        var finalControl = new SubForms.AnalysisConfirm(hoso, ketQuaXetNghiem.KetQua, false)
                        {
                            Left = Top = 0,
                            Anchor = AnchorStyles.Left | AnchorStyles.Top
                        };

                        finalControl.WillConfirm += (obj, er) =>
                        {
                            formContainer.Close();
                            this.fetchData(null);
                        };

                        formContainer.Controls.Clear();
                        formContainer.Controls.Add(finalControl);
                    }
                    else
                    {
                        MessageBox.Show("Ghi kết quả xét nghiệm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            };

            formContainer.Controls.Add(detailControl);
            formContainer.ShowDialog();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.btnAccess.Enabled = true;
        }
    }
}
