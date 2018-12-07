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
        public AssignTests()
        {
            InitializeComponent();
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            DevExpress.XtraEditors.Controls.CheckedListBoxItem newItem = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(this.cbLoaiXetNghiem.SelectedItem, true);
            var foundItem = this.checkListXetNghiem.Items.ToList().Find(item =>
            {
                var xetNghiem = (DTO.XetNghiemDTO)item.Value;
                var newXetNghiem = (DTO.XetNghiemDTO)newItem.Value;
                return xetNghiem.TenXetNghiem.Equals(newXetNghiem.TenXetNghiem);
            });

            if (foundItem == null)
            {
                this.checkListXetNghiem.Items.Add(newItem);
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
    }
}
