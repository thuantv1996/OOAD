using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagement.TiepNhan.CreatePatientRecords
{
    public partial class CreatePatientRecordsForm : Form
    {
        private enum FormType
        {
            FormToCreate,
            FormToConfirm
        }

        private FormToCreate formView;
        private Confirm confirmView;
        public Action reloadCallBack;
        public CreatePatientRecordsForm()
        {
            InitializeComponent();
            this.setupView();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void setupView()
        {
            this.Size = new Size(410, 500);
            this.MinimumSize = new Size(410, 500);
            this.MaximumSize = new Size(410, 500);
            this.setupFormToCreate();
            this.setupFormToConfirm();

        }

        private void setupFormToCreate()
        {
            this.formView = new FormToCreate(this.btnCreate_Click);
            this.formView.Left = 0;
            this.formView.Top = 0;
            this.formView.Dock = DockStyle.Fill;
            this.Controls.Add(this.formView);
            //this.ClientSize = this.formView.Size;
        }

        private void setupFormToConfirm()
        {
            this.confirmView = new Confirm(this.btnEdit_Click, btnDone_Click);
            this.confirmView.Left = 0;
            this.confirmView.Top = 0;
            this.confirmView.Dock = DockStyle.Fill;
            this.Controls.Add(this.confirmView);
            //this.ClientSize = this.confirmView.Size;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //fill data to confirm view
            this.switchView(FormType.FormToConfirm);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //fill data to create view
            this.switchView(FormType.FormToCreate);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //process done click event
            if (reloadCallBack != null) {
                reloadCallBack();
            }
            this.Close();
        }

        private void switchView(FormType type)
        {
            switch (type)
            {
                case FormType.FormToCreate:
                    {
                        this.Controls.Clear();
                        this.Controls.Add(this.formView);
                        break;
                    }
                case FormType.FormToConfirm:
                    {
                        this.Controls.Clear();
                        this.Controls.Add(this.confirmView);
                        break;
                    }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CreatePatientRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "CreatePatientRecordsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "CreatePatientRecordsForm";
            this.ResumeLayout(false);

        }
    }
}
