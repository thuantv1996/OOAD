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
        public FilterUserControl()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            var enterEvent = new KeyEventHandler((sender, e) =>
            {
                if (e.KeyCode != Keys.Enter)
                    return;
                var entity = new BUS.Entities.BenhNhanSearchEntity();
                entity.MaBenhNhan = this.txtMaBenh.Text;
                entity.TenBenhNhan = this.txtHoTen.Text;
                entity.CMND = this.txtCMND.Text;
                this.SearchCompleted?.Invoke(this, entity);
            });

            this.txtMaBenh.TextBox.KeyDown += enterEvent;
            this.txtHoTen.TextBox.KeyDown += enterEvent;
            this.txtCMND.TextBox.KeyDown += enterEvent;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var entity = new BUS.Entities.BenhNhanSearchEntity();
            entity.MaBenhNhan = this.txtMaBenh.Text;
            entity.TenBenhNhan = this.txtHoTen.Text;
            entity.CMND = this.txtCMND.Text;

            this.SearchCompleted?.Invoke(this, entity);
        }

        public event EventHandler<BUS.Entities.BenhNhanSearchEntity> SearchCompleted;

    }
}
