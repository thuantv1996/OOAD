﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DTO;

namespace ClinicManagement.Features.Login.SubForms
{
    public partial class LoginControl : UserControl
    {
        public struct LoginInfo {
            public string userName;
            public string password;

            public LoginInfo(string userName, string password)
            {
                this.userName = userName;
                this.password = password;
            }
        }

        public LoginControl()
        {
            InitializeComponent();
            this.setupView();
         }

        private void setupView()
        {
            this.BackColor = Color.White;
            this.BackColor = Color.FromArgb(25, Color.Black);
            this.setRegion();
            this.SizeChanged += new EventHandler((sender, e) =>
            {
                this.setRegion();
            });

            this.ClientSizeChanged += new EventHandler((sender, e) =>
            {
                this.setRegion();
            });
            this.btnLogin.Click += new EventHandler((sender, e) =>
            {
                if (String.IsNullOrEmpty(this.userNameTextField.Text) || String.IsNullOrEmpty(this.passwordTextField.Text))
                {
                    //show dialog
                    Console.WriteLine("UserName or Password is null");
                }
                else
                {
                    var account = new TaiKhoanEnity();
                    account.TenDangNhap = this.userNameTextField.Text;
                    account.MatKhau = this.passwordTextField.Text;
                    this.loginCompleted?.Invoke(sender, account);
                }
            });
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
                this._radius = value;
                this.setRegion();
            }
        }

        private GraphicsPath path = new GraphicsPath();
        private int _radius = 10;

        public event EventHandler<TaiKhoanEnity> loginCompleted;
    }
}
