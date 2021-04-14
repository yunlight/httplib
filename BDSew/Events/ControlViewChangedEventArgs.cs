using BD.Common;
using System;

namespace BDSew
{
    public class ControlViewChangedEventArgs : EventArgs
    {
        private ControlViewName view;

        public ControlViewName View
        {
            get { return view; }
        }

        public ControlViewChangedEventArgs(ControlViewName actions)
        {
            this.view = actions;
        }

    }
}
