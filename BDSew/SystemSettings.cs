using System;

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

            XLeft = 60;
            XRight = 60;
            YUp = 110;
            YDown = 110;
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
    }
}
