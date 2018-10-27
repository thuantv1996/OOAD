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
    public partial class TableDataWithSearch : UserControl
    {
        public TableDataWithSearch()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
        }

        public void fetchData(DataTable table)
        {
            this.tableControl.fetchData(table);
        }

        public ColumnTypes[] Columns
        {
            get { return this.tableControl.Columns; }
            set { this.tableControl.Columns = value; }
        }

        public Action<FilterUserControl.SearchResult> searchCompleted
        {
            set { this.filterUserControl.searchCompleted = value; }
        }
    }
}
