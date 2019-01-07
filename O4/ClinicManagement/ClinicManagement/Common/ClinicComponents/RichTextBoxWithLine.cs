using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.Common.ClinicComponents
{
    public partial class RichTextBoxWithLine : RichTextBox
    {
        public RichTextBoxWithLine()
        {
            InitializeComponent();
        }

        public RichTextBoxWithLine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Text = "-  ";
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                this.Text += "-  ";
                this.Select(this.Text.Length, 0);
            }
        }

        public string getText
        {
            get
            {
                var temp = Text.Replace(" ", "");
                if (temp.Equals("-"))
                    return String.Empty;
                return this.Text;
            }
        }
    }
}
