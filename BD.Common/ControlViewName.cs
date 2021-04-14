using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Common
{ 
    public class ControlViewName
    {
        private static Dictionary<string, ControlViewName> stateCash = new Dictionary<string, ControlViewName>();

        private string sId = "";
        private string sDesc = "";

        public ControlViewName()
        {
        }

        public ControlViewName(string strId, string strDesc)
        {
            this.sId = strId;
            this.sDesc = strDesc;

            stateCash.Add(strId, this);
        }

        public string ID
        {
            get
            {
                return this.sId;
            }
        }

        public string Desc
        {
            get
            {
                return this.sDesc;
            }
        }

        public static ControlViewName LookUp(string sId)
        {
            ControlViewName state = ControlViewName.Unknown;

            if (sId != null)
            {
                if (stateCash.ContainsKey(sId))
                {
                    state = stateCash[sId];
                }
            }
            return state;
        }

        public static bool Equls(ControlViewName stateA, ControlViewName stateB)
        {
            return stateA.ID == stateB.ID && stateA.sDesc.Equals(stateB.sDesc);
        }

        public static ControlViewName Unknown = new ControlViewName("???", "未知");
        public static ControlViewName AssistSetting = new ControlViewName("AssistSetting", "辅助设置");
        public static ControlViewName Edit = new ControlViewName("Edit", "文件编辑");
        public static ControlViewName FileManagement = new ControlViewName("FileManagement", "文件管理");
        public static ControlViewName FileViewer = new ControlViewName("FileViewer", "文件");
        public static ControlViewName MachinePramm = new ControlViewName("MachinePramm", "机械状态");
        public static ControlViewName MachineStatus = new ControlViewName("MachineStatus", "机械参数");
        public static ControlViewName Main = new ControlViewName("Main", "主界面");
        public static ControlViewName Menu = new ControlViewName("Menu", "菜单");
        public static ControlViewName SystemPramm = new ControlViewName("SystemPramm", "系统参数"); 
    }
}
