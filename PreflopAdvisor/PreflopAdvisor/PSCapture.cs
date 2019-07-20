using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PreflopAdvisor
{
    class PSCapture
    {
        protected IntPtr handle;

        public PSCapture(string processName)
        {
            this.handle = Process.GetProcessesByName(processName).Select(p => p.MainWindowHandle).First(p => p != IntPtr.Zero);
        }

        public void Restore()
        {
            if (NativeCall.IsIconic(this.handle))
                NativeCall.ShowWindow(this.handle, NativeCall.WindowShowStyle.Restore);
        }
    }
}
