using System;
using System.Collections.Generic;
using System.Text;

namespace Toaster.Connection
{
    public class HileBulunduEventArgs : EventArgs
    {
        public HileBulunduEventArgs(Hile message)
        {
            Hile = message;
        }

        public Hile Hile { get; set; }
    }
}
