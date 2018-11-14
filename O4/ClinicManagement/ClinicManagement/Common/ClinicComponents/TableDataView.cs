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
        Name,
        BirthDay,
        IdentifyCardNumber,
        Sex,
        Address,
        Note,
        IdNumber
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
            this.gridView.Columns.Clear();
            this.columns.ToList().ForEach(type =>
            {
                this.gridView.Columns.Add(type.ToString("g"), this.ColumnTypeToString(type));
            });
            
        }

        public void fetchData(List<DTO.BenhNhanEnity> danhSachBenhNhan)
        {
            var list = new BindingList<DTO.BenhNhanEnity>(danhSachBenhNhan);
            var source = new BindingSource(list, null);


           
            this.gridView.DataSource = ConvertToDatatable<DTO.BenhNhanEnity>(danhSachBenhNhan);
        }

        private string ColumnTypeToString(ColumnTypes type)
        {
            switch (type)
            {
                case ColumnTypes.Name: return "HoTen";
                case ColumnTypes.Address: return "Địa Chỉ";
                case ColumnTypes.BirthDay: return "Ngày Sinh";
                case ColumnTypes.IdentifyCardNumber: return "CMND/Passport";
                case ColumnTypes.Note: return "Ghi Chú";
                case ColumnTypes.Sex: return "Giới Tính";
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
            ColumnTypes.Name,
            ColumnTypes.BirthDay,
            ColumnTypes.Sex,
            ColumnTypes.IdentifyCardNumber,
            ColumnTypes.Address,
            ColumnTypes.Note
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
    }
}
