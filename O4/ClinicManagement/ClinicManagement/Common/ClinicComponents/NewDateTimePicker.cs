using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ClinicManagement.Common.ClinicComponents
{
    public partial class NewDateTimePicker : UserControl
    {
        public NewDateTimePicker()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.setRegion();
            this.SizeChanged += new EventHandler((sender, e) =>
            {
                this.setRegion();
            });
        }

        private void setRegion()
        {
            this.panelIcon.Width = this.Height + this.radius / 2;
            this.icon.Padding = new Padding(this.radius / 2, icon.Padding.Top, icon.Padding.Right, icon.Padding.Bottom);
            this.path.Reset();
            if (this.Region != null)
            {
                this.Region.Dispose();
                this.Region = null;
            }
            this.path.AddPath(createPath(), false);
            this.Region = new System.Drawing.Region(path);
        }

        private GraphicsPath createPath()
        {
            var _path = new GraphicsPath();
            var width = this.Width;
            var height = this.Height;
            int X = 0, Y = 0;
            int cornerWidth = this.radius * 2;
            _path.AddLine(X + radius, Y, X + width - cornerWidth, Y);
            _path.AddArc(X + width - cornerWidth, Y, cornerWidth, cornerWidth, 270, 90);
            _path.AddLine(X + width, Y + radius, X + width, Y + height - cornerWidth);
            _path.AddArc(X + width - cornerWidth, Y + height - cornerWidth, cornerWidth, cornerWidth, 0, 90);
            _path.AddLine(X + width - cornerWidth, Y + height, X + radius, Y + height);
            _path.AddArc(X, Y + height - cornerWidth, cornerWidth, cornerWidth, 90, 90);
            _path.AddLine(X, Y + height - cornerWidth, X, Y + radius);
            _path.AddArc(X, Y, cornerWidth, cornerWidth, 180, 90);
            return _path;
        }


        #region Public Properties
        public Font TextFont
        {
            get { return this.dateTimePicker.Font; }
            set { this.dateTimePicker.Font = value; }
        }

        public Image Icon
        {
            get { return this.icon.Image; }
            set { this.icon.Image = value; }
        }

        public int Radius
        {
            get { return this.radius; }
            set
            {
                if (value > this.Height / 2)
                    value = this.Height / 2;
                this.radius = value;
                this.setRegion();
            }
        }

        public Padding Margin
        {
            get { return this.dateTimePicker.Margin; }
            set { this.dateTimePicker.Margin = value; }
        }

        public DateTimePicker DateTimePicker
        {
            get { return this.dateTimePicker; }
            set { this.dateTimePicker = value; }
        }
        #endregion

        private GraphicsPath path = new GraphicsPath();
        private int radius = 5;
    }
}
