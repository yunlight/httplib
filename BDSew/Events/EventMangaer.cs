using BD.Common;

namespace BDSew
{
    public delegate void ControlViewChangeEventHandler(ControlViewName e);

    internal class EventMangaer
    {

        public event ControlViewChangeEventHandler controlViewChanged;//异步读完成


        private static EventMangaer actInstance = null;

        /// <summary>
        /// Singleton accessor
        /// </summary>
        public static EventMangaer Instance
        {
            get
            {
                if (actInstance == null)
                {
                    actInstance = new EventMangaer();
                }
                return actInstance;
            }
        }

        private EventMangaer()
        {

        }

        public void ControlViewChange(ControlViewName e)
        {
            if (controlViewChanged != null)
            {
                controlViewChanged(e);
            }
        }
    }
}
