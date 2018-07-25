using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using JavaAccessBridgeConnector.AccessBridgeInterop;

namespace JavaAccessBridgeConnector
{
    public partial class App : Application
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private AccessBridge ab;

        public App()
        {
            ab = new AccessBridge();
            ab.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IsJavaWindow();
            Application.Current.Shutdown();
        }

        private void IsJavaWindow()
        {
            var hWnd = FindWindow("SunAwtFrame", "Calculator");
            var res = ab.Functions.IsJavaWindow(hWnd);
            if (!res) return;
            var res2 = ab.Functions.GetAccessibleContextFromHWND(hWnd, out var vmid, out var ac);
            MessageBox.Show(res2
                ? $"Java Virtual Machine Id: {vmid} \n Java Object Handle: {ac.Handle.Value}"
                : "Java Window not found!");
        }
    }
}
