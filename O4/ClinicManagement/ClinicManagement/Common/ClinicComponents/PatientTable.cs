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

    public partial class PatientTable : UserControl
    {
        private struct BenhNhanView
        {
            public string MaBenhNhan { get; set; }
            public string HoTen { get; set; }
            public string CMND { get; set; }
            public string NgaySinh { get; set; }
            public string GioiTinh { get; set; }
            public string SoDienThoai { get; set; }
            public string DiaChi { get; set; }
            public string GhiChu { get; set; }

            public BenhNhanView(DTO.BenhNhanDTO entity)
            {
                this.MaBenhNhan = entity.MaBenhNhan;
                this.HoTen = entity.HoTen;
                this.CMND = entity.CMND;
                this.NgaySinh = convertDate(entity.NgaySinh);
                this.GioiTinh = entity.GioiTinh ? "Nam" : "Nữ";
                this.SoDienThoai = entity.SoDienThoai;
                this.DiaChi = entity.DiaChi;
                this.GhiChu = entity.GhiChu;
            }

            static private string convertDate(string date)
            {
                var year = date.Substring(0, 4);
                var month = date.Substring(4, 2);
                var day = date.Substring(6, 2);
                return String.Format("{0}/{1}/{2}", day, month, year);
            }

            public DTO.BenhNhanDTO ToBenhNhanEntity()
            {
                var list = this.NgaySinh.Split('/');
                var day = list.First();
                var year = list.Last();
                var month = list[1];

                return new DTO.BenhNhanDTO
                {
                    MaBenhNhan = this.MaBenhNhan,
                    HoTen = this.HoTen,
                    CMND = this.CMND,
                    NgaySinh = String.Format("{0}{1}{2}", year, month, day),
                    GioiTinh = this.GioiTinh.Equals("Nam") ? true : false,
                    SoDienThoai = this.SoDienThoai,
                    DiaChi = this.DiaChi,
                    GhiChu = this.GhiChu
                };
            }
        }

        public PatientTable()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.gridView1.Columns.Clear();
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

        public void fetchData(List<DTO.BenhNhanDTO> danhSachBenhNhan)
        {
            if (this.gridControl1.InvokeRequired)
            {
                this.Invoke(new Action<List<DTO.BenhNhanDTO>>(fetchData), new object[] { danhSachBenhNhan });
            } else
            {
                var listViews = new List<BenhNhanView>();
                danhSachBenhNhan.ForEach((entity) =>
                {
                    listViews.Add(new BenhNhanView(entity));
                });
                this.gridControl1.DataSource = ConvertToDatatable<BenhNhanView>(listViews);
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
                this.setupView();
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

        public DTO.BenhNhanDTO PatientSelected
        {
            get
            {
                int selectedIntexRow = this.gridView1.GetSelectedRows().First();
                DataRow row = this.gridView1.GetDataRow(selectedIntexRow);
                var patient = new BenhNhanView();
                patient.HoTen = row[ColumnTypes.HoTen.ToString()].ToString();
                patient.MaBenhNhan = row[ColumnTypes.MaBenhNhan.ToString()].ToString();
                patient.NgaySinh = row[ColumnTypes.NgaySinh.ToString()].ToString();
                patient.SoDienThoai = row[ColumnTypes.SoDienThoai.ToString()].ToString();
                patient.GioiTinh = row[ColumnTypes.GioiTinh.ToString()].ToString();
                patient.CMND = row[ColumnTypes.CMND.ToString()].ToString();
                patient.DiaChi = row[ColumnTypes.DiaChi.ToString()].ToString();
                patient.GhiChu = row[ColumnTypes.GhiChu.ToString()].ToString();
                return patient.ToBenhNhanEntity();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.RowClick?.Invoke(sender, e);
        }

        public event EventHandler RowClick;
        public event EventHandler<DTO.BenhNhanDTO> DoubleClick;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.DoubleClick?.Invoke(sender, PatientSelected);
        }
    }
}
