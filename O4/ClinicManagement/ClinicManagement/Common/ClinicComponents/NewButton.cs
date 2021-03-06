﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace ClinicManagement.Common.ClinicComponents
{
    public partial class NewButton : System.Windows.Forms.Button
    {
        public NewButton()
        {
            InitializeComponent();
            this.setupView();
        }

        private void setupView()
        {
            this._radius = this.Height / 2;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.setRegion();
            this.SizeChanged += new EventHandler((sender, e) =>
            {
                this.setRegion();
            });
            this.ClientSizeChanged += new EventHandler((sender, e) =>
            {
                this.setRegion();
            });
        }

        public NewButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.setupView();
        }

        private void setRegion()
        {
            this.path.Reset();
            if (this.Region != null)
            {
                this.Region.Dispose();
                this.Region = null;
            }
            this.addPath();
            this.Region = new System.Drawing.Region(path);
        }

        private void addPath()
        {
            var width = this.Width;
            var height = this.Height;
            int X = 0, Y = 0;
            int cornerWidth = this._radius * 2;
            path.AddLine(X + _radius, Y, X + width - cornerWidth, Y);
            path.AddArc(X + width - cornerWidth, Y, cornerWidth, cornerWidth, 270, 90);
            path.AddLine(X + width, Y + _radius, X + width, Y + height - cornerWidth);
            path.AddArc(X + width - cornerWidth, Y + height - cornerWidth, cornerWidth, cornerWidth, 0, 90);
            path.AddLine(X + width - cornerWidth, Y + height, X + _radius, Y + height);
            path.AddArc(X, Y + height - cornerWidth, cornerWidth, cornerWidth, 90, 90);
            path.AddLine(X, Y + height - cornerWidth, X, Y + _radius);
            path.AddArc(X, Y, cornerWidth, cornerWidth, 180, 90);
        }

        public int Radius
        {
            get { return this._radius; }
            set
            {
                if (value > this.Height / 2)
                    return;
                this._radius = value;
                this.setRegion();
            }
        }

        private GraphicsPath path = new GraphicsPath();
        private int _radius;
    }
}
