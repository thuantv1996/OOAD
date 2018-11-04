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
            public string MaBenhNhan;
            public string TenBenhNhan;
            public string CMND;

            public SearchResult(string maBenhNhan, string tenBenhNhan, string cmnd) : this()
            {
                this.MaBenhNhan = maBenhNhan;
                this.TenBenhNhan = tenBenhNhan;
                this.CMND = cmnd;
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
                this.SearchCompleted?.Invoke(sender, new SearchResult(this.txtMaBenh.Text, this.txtHoTen.Text, this.txtCMND.Text));
            });

            var enterEvent = new KeyEventHandler((sender, e) =>
            {
                if (e.KeyCode != Keys.Enter)
                    return;
                this.SearchCompleted?.Invoke(sender, new SearchResult(this.txtMaBenh.Text, this.txtHoTen.Text, this.txtCMND.Text));
            });

            this.txtMaBenh.TextBox.KeyDown += enterEvent;
            this.txtHoTen.TextBox.KeyDown += enterEvent;
            this.txtCMND.TextBox.KeyDown += enterEvent;
        }

        public event EventHandler<SearchResult> SearchCompleted;
    }
}
