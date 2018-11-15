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
    public enum ColumnTypes
    {
        MaBenhNhan,
        HoTen,
        CMND,
        NgaySinh,
        GioiTinh,
        SoDienThoai,
        DiaChi,
        GhiChu
}

    public partial class TableDataView : UserControl
    {
        public TableDataView()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.columns.ToList().ForEach(type =>
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = this.ColumnTypeToFieldName(type);
                col.Caption = this.ColumnTypeToString(type);
                col.Name = type.ToString();
                this.gridView1.Columns.Add(col);
                this.gridView1.Columns.AddVisible(col.FieldName, col.Caption);
            });
        }

        public void fetchData(List<DTO.BenhNhanEnity> danhSachBenhNhan)
        {
            if (this.gridControl1.InvokeRequired)
            {
                this.Invoke(new Action<List<DTO.BenhNhanEnity>>(fetchData), new object[] { danhSachBenhNhan });
            } else
            {
                var list = new BindingList<DTO.BenhNhanEnity>(danhSachBenhNhan);
                var source = new BindingSource(list, null);
                this.gridControl1.DataSource = ConvertToDatatable<DTO.BenhNhanEnity>(danhSachBenhNhan);
            }
        }

        private string ColumnTypeToString(ColumnTypes type)
        {
            switch (type)
            {
                case ColumnTypes.HoTen: return "Họ Tên";
                case ColumnTypes.CMND: return "CMND";
                case ColumnTypes.NgaySinh: return "Ngày Sinh";
                case ColumnTypes.GioiTinh: return "Giới Tính";
                case ColumnTypes.SoDienThoai: return "Sdt";
                case ColumnTypes.DiaChi: return "Địa chỉ";
                case ColumnTypes.GhiChu: return "Ghi chú";
                default: return "";
            }
        }

        private string ColumnTypeToFieldName(ColumnTypes type)
        {
             
            switch (type)
            {
                case ColumnTypes.MaBenhNhan: return "MaBenhNhan";
                case ColumnTypes.HoTen: return "HoTen";
                case ColumnTypes.CMND: return "CMND";
                case ColumnTypes.NgaySinh: return "NgaySinh";
                case ColumnTypes.GioiTinh: return "GioiTinh";
                case ColumnTypes.SoDienThoai: return "SoDienThoai";
                case ColumnTypes.DiaChi: return "DiaChi";
                case ColumnTypes.GhiChu: return "GhiChu";
                default: return "";
            }
        }

        public ColumnTypes[] Columns
        {
            get { return this.columns; }
            set
            {
                List<ColumnTypes> tempList = new List<ColumnTypes>();
                value.ToList().ForEach(type =>
                {
                    if (!tempList.Contains(type))
                        tempList.Add(type);
                });
                this.columns = tempList.ToArray();
            }
        }

        private ColumnTypes[] columns = new ColumnTypes[]
        {
            ColumnTypes.HoTen,
            ColumnTypes.CMND,
            ColumnTypes.NgaySinh,
            ColumnTypes.GioiTinh,
            ColumnTypes.SoDienThoai,
            ColumnTypes.DiaChi,
            ColumnTypes.GhiChu
        };


        private DataTable ConvertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;

            
        }

        public DTO.BenhNhanEnity PatientSelected
        {
            get
            {
                int selectedIntexRow = this.gridView1.GetSelectedRows().First();
                DataRow row = this.gridView1.GetDataRow(selectedIntexRow);
                var patient = new DTO.BenhNhanEnity();
                patient.HoTen = row[ColumnTypes.HoTen.ToString()].ToString();
                patient.MaBenhNhan = row[ColumnTypes.MaBenhNhan.ToString()].ToString();
                patient.NgaySinh = row[ColumnTypes.NgaySinh.ToString()].ToString();
                patient.SoDienThoai = row[ColumnTypes.SoDienThoai.ToString()].ToString();
                patient.GioiTinh = (bool)row[ColumnTypes.GioiTinh.ToString()];
                patient.CMND = row[ColumnTypes.CMND.ToString()].ToString();
                patient.DiaChi = row[ColumnTypes.DiaChi.ToString()].ToString();

                return patient;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.RowClick?.Invoke(sender, e);
        }

        public event EventHandler RowClick;
    }
}
