using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Lignite.Controls.Events
{
    public delegate void LigniteControlEventHandler(object sender, LigniteControlEventArgs e);

    /// <summary>
    /// The base event argument used in the Lignite event controller.
    /// </summary>
    [Serializable]
    [ComVisible(true)]
    public abstract class LigniteControlEventArgs : EventArgs
    {
        /// <summary>
        /// The unique id of the sending control.
        /// </summary>
        /// <value>The UID.</value>
        public string SenderUID{ get; set; }
    }
}
