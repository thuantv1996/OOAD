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
            this.filterUserControl.SearchCompleted += new EventHandler<FilterUserControl.SearchResult>((sender, e) =>
            {
                this.SearchCompleted?.Invoke(sender, e);
            });
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

        public event EventHandler<FilterUserControl.SearchResult> SearchCompleted;
    }
}
