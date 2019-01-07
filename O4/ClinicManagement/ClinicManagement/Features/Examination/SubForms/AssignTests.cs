using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Examination.SubForms
{
    public partial class AssignTests : UserControl
    {
        private decimal totalCharge = 0;
        public delegate void AssignTestsDelegate(decimal totalCharge, List<DTO.XetNghiemDTO> listTest);
        public event AssignTestsDelegate DidAssign;
        private List<DTO.XetNghiemDTO> listXetNghiem;

        public AssignTests(List<DTO.XetNghiemDTO> listXetNghiem)
        {
            InitializeComponent();
            this.listXetNghiem = listXetNghiem ?? new List<DTO.XetNghiemDTO>();
            this.setupView();
        }

        public void setupView()
        {
            this.bus.getListXetNghiem((result, listResult) =>
            {
                if (result.Equals(COM.Constant.RES_SUC))
                {
                    listResult.ForEach(xetnghiem =>
                    {
                        this.cbLoaiXetNghiem.Properties.Items.Add(xetnghiem);
                    });
                }
            });

            this.listXetNghiem.ForEach(xetNghiem =>
            {
                var newItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(xetNghiem, true);
                this.checkListXetNghiem.Items.Add(newItem);
            });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.cbLoaiXetNghiem.SelectedItem == null)
                return;
            var newItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(this.cbLoaiXetNghiem.SelectedItem, true);

            var foundItem = this.checkListXetNghiem.Items.ToList().Find(item =>
            {
                var xetNghiem = (DTO.XetNghiemDTO)item.Value;
                var newXetNghiem = (DTO.XetNghiemDTO)newItem.Value;
                return xetNghiem.TenXetNghiem.Equals(newXetNghiem.TenXetNghiem);
            });

            //Each item just add only one times.
            if (foundItem == null)
            {
                this.checkListXetNghiem.Items.Add(newItem);

                DTO.XetNghiemDTO xetNghiem = (DTO.XetNghiemDTO)newItem.Value;
                this.totalCharge += xetNghiem.ChiPhi;
                this.btnAssign.Enabled = true;
            }
        }

        public List<DTO.XetNghiemDTO> getListXetNghiem()
        {
            var list = new List<DTO.XetNghiemDTO>();
            this.checkListXetNghiem.Items.ToList().ForEach(item =>
            {
                if (item.CheckState == CheckState.Checked)
                {
                    list.Add((DTO.XetNghiemDTO)item.Value);
                }
            });

            return list;
        }

        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;

        private void checkListXetNghiem_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var item = this.checkListXetNghiem.Items[e.Index];
            var xetNghiem = (DTO.XetNghiemDTO)item.Value;
            var chiphi = e.State == CheckState.Unchecked ? -xetNghiem.ChiPhi : xetNghiem.ChiPhi;

            this.totalCharge += chiphi;

            var existsCheckedItem = this.checkListXetNghiem.Items.ToList().FindAll(i => i.CheckState == CheckState.Checked).Count > 0;
            this.btnAssign.Enabled = existsCheckedItem;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            this.DidAssign?.Invoke(this.totalCharge, this.getListXetNghiem());
        }
    }
}
