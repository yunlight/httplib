using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDSew
{
    public partial class MenuCtrl : UserControl
    {
        public MenuCtrl()
        {
            InitializeComponent();
        }

        private void btnFileMangement_Click(object sender, EventArgs e)
        { 
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.FileManagement);
        }

        private void btnFileEdit_Click(object sender, EventArgs e)
        { 
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.Edit);
        }

        private void btnSystemParam_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.SystemPramm);
        }

        private void btnMachineParam_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.MachinePramm);
        }

        private void btnAssistSetting_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.AssistSetting);
        }

        private void btnMachineStatus_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.MachineStatus);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.Main);
        }
    }
}
