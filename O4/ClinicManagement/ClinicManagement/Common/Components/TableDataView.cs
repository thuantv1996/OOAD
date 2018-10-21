using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Common.Components
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

        public void fetchData(DataTable table)
        {
            this.gridView.DataSource = table;
        }

        private string ColumnTypeToString(ColumnTypes type)
        {
            switch (type)
            {
                case ColumnTypes.Name: return "Họ Tên";
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
    }
}
