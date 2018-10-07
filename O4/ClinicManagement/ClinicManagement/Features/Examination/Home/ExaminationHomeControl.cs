using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace ClinicManagement.Features.Examination.Home
{
    public partial class ExaminationHomeControl : UserControl
    {
        public ExaminationHomeControl()
        {
            InitializeComponent();
        }

        private void setupView()
        {
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Tick += new EventHandler((sender, e) =>
            {
                if (this.fetchDataTask.IsCompleted)
                {
                    //fetch data go end.
                }
            });
        }

        private void tabListRecords_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
            this.fetchDataTask = Task.Factory
                .StartNew(x =>
          {
              if (this.tabListRecords.SelectedPage == this.tabWaiting)
                  this.refreshWaitingList();
              else
                  this.refreshDoneList();
          }, cancelTask);
        }

        private void refreshWaitingList(bool isShowWaitingDialog = false)
        {

        }

        private void refreshDoneList(bool isShowWaitingDialog = false)
        {

        }

        private Task fetchDataTask;
        private System.Threading.Tasks.TaskCanceledException cancelTask;
        private System.Windows.Forms.Timer timer;
    }
}
