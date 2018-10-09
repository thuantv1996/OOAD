using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Features.Common
{
    public partial class ListOfRecord : UserControl
    {
        public enum Columns
        {
            patientIdentity,
            name,
            birthDay,
            identityCardNumber,
            sex,
            address,
            note
        }

        public ListOfRecord()
        {
            InitializeComponent();
        }

        public void setupView(Columns[] columnsInvisible)
        {
            foreach (Columns col in columnsInvisible) {
                this.setInvisibleColumns(col);
            }
        }

        private void setInvisibleColumns(Columns col)
        {
            switch (col)
            {
                case Columns.name:
                    this.colName.Visible = false;
                    break;
                case Columns.birthDay:
                    this.colBirthDay.Visible = false;
                    break;
                case Columns.identityCardNumber:
                    this.colIdentityCardNumber.Visible = false;
                    break;
                case Columns.sex:
                    this.colSex.Visible = false;
                    break;
                case Columns.address:
                    this.colAddress.Visible = false;
                    break;
                case Columns.note:
                    this.colNote.Visible = false;
                    break;
                default: break;
            }
        }

        public void fetchData(DataTable table)
        {
            this.grd_ListControl.DataSource = table;
        }
    }
}
