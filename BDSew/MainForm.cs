using BD.Common;
using System;
using System.Windows.Forms;

namespace BDSew
{
    public partial class MainForm : Form
    {
        UserControl assistSettingCtrl;
        UserControl editCtrl;
        UserControl fileManagementCtrl;
        UserControl fileViewerCtrl;
        UserControl machinePrammCtrl;
        UserControl machineStatusCtrl;
        UserControl mainCtrl;
        UserControl menuCtrl;
        UserControl systemPrammCtrl;

        public MainForm()
        {
            InitializeComponent();

            assistSettingCtrl = new AssistSettingCtrl();
            editCtrl = new EditCtrl();
            fileManagementCtrl = new FileManagementCtrl();
            fileViewerCtrl = new FileViewerCtrl();
            machinePrammCtrl = new MachinePrammCtrl();
            machineStatusCtrl = new MachineStatusCtrl();
            mainCtrl = new MainCtrl();
            menuCtrl = new MenuCtrl();
            systemPrammCtrl = new SystemPrammCtrl();

            this.pnlView.Controls.Add(editCtrl);
            mainCtrl.Show(); 
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            EventMangaer.Instance.controlViewChanged += Instance_controlViewChanged;
        }

        private void Instance_controlViewChanged(BD.Common.ControlViewName e)
        {
            ControlViewChange(e);
        }

        private void ControlViewChange(ControlViewName e)
        {
            this.EndInvoke(this.BeginInvoke(new Action(() =>
            {
                this.pnlView.Controls.Clear();
                this.labTitle.Text = e.Desc;

                if (e.ID == BD.Common.ControlViewName.AssistSetting.ID)
                {
                    this.pnlView.Controls.Add(assistSettingCtrl);
                    assistSettingCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.Edit.ID)
                {
                    this.pnlView.Controls.Add(editCtrl);
                    editCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.FileManagement.ID)
                {
                    this.pnlView.Controls.Add(fileManagementCtrl);
                    fileManagementCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.FileViewer.ID)
                {
                    this.pnlView.Controls.Add(fileViewerCtrl);
                    fileViewerCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.MachinePramm.ID)
                {
                    this.pnlView.Controls.Add(machinePrammCtrl);
                    machinePrammCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.MachineStatus.ID)
                {
                    this.pnlView.Controls.Add(machineStatusCtrl);
                    machineStatusCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.Main.ID)
                {
                    this.pnlView.Controls.Add(mainCtrl);
                    mainCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.Menu.ID)
                {
                    this.pnlView.Controls.Add(menuCtrl);
                    menuCtrl.Show();
                }
                else if (e.ID == BD.Common.ControlViewName.SystemPramm.ID)
                {
                    this.pnlView.Controls.Add(systemPrammCtrl);
                    systemPrammCtrl.Show();
                }
                else
                {
                    this.pnlView.Controls.Add(mainCtrl);
                    mainCtrl.Show();
                }
            })));
        }
    }
}
