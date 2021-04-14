namespace BDSew
{
    class MachineParamm
    {
        private static MachineParamm actInstance = null;
        public static MachineParamm Instance
        {
            get
            {
                if (actInstance == null)
                {
                    actInstance = new MachineParamm();
                }

                return actInstance;
            }
        }
        private MachineParamm()
        {
            Init();
        }

        private void Init()
        {
            TransmissionRatioX = 62;
            TransmissionRatioY = 62;
            Coefficient = 62;
        }

        /// <summary>
        /// X传动比
        /// </summary>   
        public float TransmissionRatioX { get; set; }
        /// <summary>
        /// Y传动比
        /// </summary>
        public float TransmissionRatioY { get; set; }
        /// <summary>
        /// 控制系数
        /// </summary>
        public float Coefficient { get; set; }



    }
}
