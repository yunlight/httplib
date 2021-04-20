using System;
using System.Collections.Generic;

namespace BDSew
{
    class SystemSettings
    {
        private static SystemSettings actInstance = null;
        public static SystemSettings Instance
        {
            get
            {
                if (actInstance == null)
                {
                    actInstance = new SystemSettings();
                }

                return actInstance;
            }
        }
        private SystemSettings()
        {
            this.ReadSystemSettings();
            this.Init();
        }

        private void Init()
        {
            listDashLineTypeName.Add("ACAD_ISO03W100");
        }

        /// <summary>
        /// 最小针步
        /// </summary>
        public float MinimumStitch { get; private set; }

        public bool IsUseRangeSetting { get; set; }

        public float XLeft { get; set; }
        public float XRight { get; set; }
        public float YUp { get; set; }
        public float YDown { get; set; }
        private string PasswordStr { get; set; }

        private bool VerifyPassowrd(string passwordStr)
        {
            return true;
        }

        private void ReadSystemSettings()
        {
            IsUseRangeSetting = true;

            XLeft = 100;
            XRight = 100;
            YUp = 200;
            YDown = 200;
            PasswordStr = "123456";
            MinimumStitch = 0.1f;
        }

        public void SaveSystemSettings(string passwordStr)
        {
            if (VerifyPassowrd(passwordStr))
            {
                SaveSystemSettings();
            }
        }

        private void SaveSystemSettings()
        {
            throw new NotImplementedException();
        }


        List<string> listDashLineTypeName = new List<string>();
        public bool IsDashLine(string lineTypeName)
        {
            return listDashLineTypeName.Contains(lineTypeName);
        }

    }
}
