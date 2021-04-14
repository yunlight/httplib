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
    public partial class MainCtrl : UserControl
    {
        public MainCtrl()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.Menu);
        }

        private void btnViewFiles_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.FileViewer);
        }
    }
}
