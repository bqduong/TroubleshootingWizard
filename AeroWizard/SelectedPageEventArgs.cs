using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroWizard
{
    public class SelectedPageEventArgs : EventArgs
    {
        public bool IsPrevious { get; set; }
    }
}
