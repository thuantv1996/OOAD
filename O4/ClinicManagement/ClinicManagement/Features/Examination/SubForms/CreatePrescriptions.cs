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
    public partial class CreatePrescriptions : UserControl
    {
        private Bus.ExaminationBus bus = Bus.ExaminationBus.SharedInstance;
        private List<Model.ThuocView> listOfMedicineAdded = new List<Model.ThuocView>();
        private List<DTO.ThuocDTO> listOfMedicine = new List<DTO.ThuocDTO>();

        public event EventHandler<bool> ActiveConfirm;

        public CreatePrescriptions()
        {
            InitializeComponent();
            this.getData();
        }

        private void getData()
        {
            this.bus.getListThuoc((result, listResult) =>
            {
                listResult.ForEach(thuoc =>
                {
                    this.cbTenThuoc.Properties.Items.Add(thuoc);
                    this.listOfMedicine.Add(thuoc);
                });
            });
        }

        private void reloadData()
        {
            this.gridThuoc.DataSource = ClinicManagement.Common.ClinicBus.ConvertToDatatable(this.listOfMedicineAdded);
        }

        private bool checkValidToAdd()
        {
            return !(String.IsNullOrEmpty(this.txtSoLuong.Text) ||
                this.cbTenThuoc.SelectedItem == null ||
                String.IsNullOrEmpty(this.txtGhiChu.Text));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var selectedItem = (DTO.ThuocDTO)this.cbTenThuoc.SelectedItem;
            if (this.listOfMedicineAdded.Find(t => t.MaThuoc == selectedItem.MaThuoc) != null) return;

            var thuoc = new Model.ThuocView()
            {
                MaThuoc = selectedItem.MaThuoc,
                TenThuoc = selectedItem.TenThuoc,
                GhiChu = this.txtGhiChu.Text,
                SoLuong = int.Parse(this.txtSoLuong.Text)
            };


            this.listOfMedicineAdded.Add(thuoc);
            this.reloadData();
            this.activeConfirmChanged();
        }

        private void activeConfirmChanged()
        {
            this.ActiveConfirm?.Invoke(this, this.gridView1.RowCount > 0);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (this.checkValidToAdd())
                this.btnThem.Enabled = true;
        }

        private void cbTenThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.checkValidToAdd())
                this.btnThem.Enabled = true;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        public List<DTO.ChiTietDonThuocDTO> getListOfMedicine()
        {
            var list = new List<DTO.ChiTietDonThuocDTO>();
            this.listOfMedicineAdded.ForEach(thuoc =>
            {
                list.Add(new DTO.ChiTietDonThuocDTO()
                {
                    MaThuoc = thuoc.MaThuoc,
                    SoLuong = thuoc.SoLuong,
                    GhiChu = thuoc.GhiChu
                });
            });
            return list;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var index = this.gridView1.GetSelectedRows().First();
            var thuoc = this.listOfMedicineAdded[index];
            this.txtSoLuong.Text = thuoc.SoLuong.ToString();
            this.txtGhiChu.Text = thuoc.GhiChu;
            this.cbTenThuoc.SelectedItem = this.listOfMedicine.Find(t => t.MaThuoc == thuoc.MaThuoc);
            this.btnSaveChanged.Enabled = true;
            this.btnDelete.Enabled = true;
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            var index = this.gridView1.GetSelectedRows().First();
            var selectedItem = (DTO.ThuocDTO)this.cbTenThuoc.SelectedItem;

            var thuoc = new Model.ThuocView()
            {
                MaThuoc = selectedItem.MaThuoc,
                TenThuoc = selectedItem.TenThuoc,
                GhiChu = this.txtGhiChu.Text,
                SoLuong = int.Parse(this.txtSoLuong.Text)
            };

            this.listOfMedicineAdded.Insert(index, thuoc);
            this.listOfMedicineAdded.RemoveAt(index + 1);
            this.reloadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = this.gridView1.GetSelectedRows().First();
            this.listOfMedicineAdded.RemoveAt(index);
            this.reloadData();
            if (this.listOfMedicineAdded.Count == 0)
            {
                this.btnDelete.Enabled = this.btnSaveChanged.Enabled = false;
            }

            this.activeConfirmChanged();
        }
    }
}
