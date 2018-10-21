using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ClinicManagement.Common.Components
{
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
            this.setupProperties();
            this.setupView();
            this.ClientSizeChanged += new EventHandler((sender, e) =>
            {
                this.setupView();
            });
        }

        private void setupProperties()
        {
            this.slidePanel = new Panel();
            this.slidePanel.Top = 0;
            this.slidePanel.Width = 5;
            this.slidePanel.Height = this.itemHeight;
            this.slidePanel.BackColor = Color.FromArgb(172, 31, 37);
            this.layout.BackColor = Common.SourceLibrary.ClinicColor;
        }

        private void setupView()
        {
            if (this.Items == null)
                return;

            this.refresheData();
            this.layout.Controls.Add(new Panel(), 0, 0);
            this.layout.RowStyles.Add(new RowStyle(SizeType.Absolute, this.topPadding));
            var index = 1;

            this.Items.ToList().ForEach(item =>
            {
                if (item != null)
                {
                    this.layout.Controls.Add(this.createButton(item, index), 0, index++);
                    this.layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                    this.layout.RowCount++;
                }

            });

            this.chooseItemObserver.onNext(this.layout.Controls[1] as Button);
        }

        private void refresheData()
        {
            this.chooseItemObserver.clear();
            this.layout.Controls.Clear();
            this.layout.RowStyles.Clear();
        }

        private Button createButton(string title, int index)
        {
            var btn = new Button();
            btn.Text = title;
            btn.Dock = DockStyle.Fill;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Margin = new Padding(0, this.itemsSpace, 0, 0);
            btn.Font = Common.SourceLibrary.ClinicFont;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.ForeColor = Color.White;

            if (this.iconList != null && this.iconList.Images.Count > index - 1)
            {
                btn.Image = this.iconList.Images[index - 1];
                btn.ImageAlign = this.iconAlignment;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }

            this.chooseItemObserver.subscribe(button =>
            {
                if (btn == button)
                {
                    btn.BackColor = ControlPaint.Light(Common.SourceLibrary.ClinicColor);
                    btn.Controls.Clear();
                    btn.Controls.Add(this.slidePanel);
                    this.slidePanel.BringToFront();
                }
                else
                    btn.BackColor = Common.SourceLibrary.ClinicColor;
            });

            btn.Click += new EventHandler((sender, e) => 
            {
                this.chooseItemObserver.onNext(btn);
                if (this.listAction.Count > index - 1)
                    this.listAction.ElementAt(index - 1)(sender, e);
            });
            return btn;
        }

        public string[] Items { get; set; }

        public int ItemHeight
        {
            get { return this.itemHeight; }
            set
            {
                this.itemHeight = value;
                this.setupView();
            }
        }

        public int ItemsSpace
        {
            get { return this.itemsSpace; }
            set
            {
                this.itemsSpace = value;
                this.setupView();
            }
        }

        public int TopPadding
        {
            get { return this.topPadding; }
            set
            {
                this.topPadding = value;
                this.setupView();
            }
        }

        public bool ShowSelectedItem
        {
            get { return this.isShowSelected; }
            set
            {
                this.isShowSelected = value;
                this.setupView();
            }
        }

        public ImageList IconList
        {
            get { return this.iconList; }
            set
            {
                if (value == null)
                    return;

                this.iconList = value;
                this.setupView();
            }
        }

        public ContentAlignment IconAlignment
        {
            get { return this.iconAlignment; }
            set { this.iconAlignment = value; }
        }

        public List<System.EventHandler> listAction = new List<EventHandler>();
        private ContentAlignment iconAlignment = ContentAlignment.MiddleLeft;
        private ImageList iconList;
        private int itemHeight = 53;
        private int itemsSpace = 10;
        private int topPadding = 150;
        private bool isShowSelected = false;
        private Panel slidePanel = new Panel();
        private Observable<Button> chooseItemObserver = new Observable<Button>();
    }
}
