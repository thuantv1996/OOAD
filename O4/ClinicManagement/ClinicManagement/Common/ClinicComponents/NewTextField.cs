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
    public partial class NewTextField : UserControl
    {
        public NewTextField()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this.setRegion();
            this.setText(true);
            this.textBox.GotFocus += new EventHandler((sender, e) =>
            {
                this.setText();
            });

            this.textBox.LostFocus += new EventHandler((sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    this.setText(true);
                }
            });

            this.textBox.KeyUp += new KeyEventHandler((sender, e) =>
            {
                this.text = (sender as TextBox).Text;
            });

            this.SizeChanged += new EventHandler((sender, e) =>
            {
                this.setRegion();
            });
        }

        private void setText(bool isPlaceHolder = false)
        {
            this.textBox.Text = isPlaceHolder ? this.placeHolder : this.text;
            this.textBox.ForeColor = isPlaceHolder ? this.placeHolderColor : this.textColor;
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
            get { return this.textBox.Font; }
            set { this.textBox.Font = value; }
        }

        public string PlaceHolder
        {
            get { return this.placeHolder; }
            set
            {
                this.placeHolder = value;
                this.setText(true);
            }
        }

        public Color PlaceHolderColor
        {
            get { return this.placeHolderColor; }
            set
            {
                this.placeHolderColor = value;
                this.setText(true);
            }
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
            get { return this.textBox.Margin; }
            set { this.textBox.Margin = value; }
        }

        public TextBox TextBox
        {
            get { return this.textBox; }
        }

        public bool IsShowPassword
        {
            get
            {
                return this.textBox.UseSystemPasswordChar;
            }

            set
            {
                this.textBox.UseSystemPasswordChar = value;
            }
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public bool enableEdit
        {
            get { return this.textBox.Enabled; }
            set { this.textBox.Enabled = value; }
        }
        #endregion

        private string placeHolder = "Place Holder";
        private string text = "";
        private Color placeHolderColor = Color.LightGray;
        private Color textColor = Color.Black;
        private GraphicsPath path = new GraphicsPath();
        private int radius = 5;
    }
}
