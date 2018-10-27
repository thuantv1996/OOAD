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
    public partial class FilterUserControl : UserControl
    {
        public struct SearchResult
        {
            public string maBenhNhan;
            public string tenBenhNhan;
            public string cmnd;

            public SearchResult(string maBenhNhan, string tenBenhNhan, string cmnd) : this()
            {
                this.maBenhNhan = maBenhNhan;
                this.tenBenhNhan = tenBenhNhan;
                this.cmnd = cmnd;
            }
        }
        public FilterUserControl()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.btnSearch.Click += new EventHandler((sender, e) =>
            {
                if (searchCompleted != null)
                    this.searchCompleted(new SearchResult(this.txtMaBenh.Text, this.txtHoTen.Text, this.txtCMND.Text));
            });

            var enterEvent = new KeyEventHandler((sender, e) =>
            {
                if (e.KeyCode != Keys.Enter)
                    return;
                if (searchCompleted != null)
                    this.searchCompleted(new SearchResult(this.txtMaBenh.Text, this.txtHoTen.Text, this.txtCMND.Text));
            });

            this.txtMaBenh.TextBox.KeyDown += enterEvent;
            this.txtHoTen.TextBox.KeyDown += enterEvent;
            this.txtCMND.TextBox.KeyDown += enterEvent;
        }


        public Action<SearchResult> searchCompleted;
    }
}
