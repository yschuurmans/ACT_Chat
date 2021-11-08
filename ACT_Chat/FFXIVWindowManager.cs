using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT_Chat
{
    public class FFXIVWindowManager
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static void FocusProcess()
        {
            IntPtr hWnd; //change this to IntPtr
            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.ProcessName.StartsWith("ffxiv"))
                {
                    hWnd = pr.MainWindowHandle; //use it as IntPtr not int
                    ShowWindow(hWnd, 3);
                    SetForegroundWindow(hWnd); //set to topmost
                }
            }
        }

        public static void FocusProcess(string name)
        {
            IntPtr windowPointer = IntPtr.Zero;
            int processCount = 100;
            for (int i = 0; (i < processCount) && (windowPointer == IntPtr.Zero); i++)
            {
                windowPointer = FindWindow(null, name);
            }
            if (windowPointer != IntPtr.Zero)
            {
                SetForegroundWindow(windowPointer);
            }
        }
    }
}
