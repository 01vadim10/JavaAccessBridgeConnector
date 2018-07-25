using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LeapTest.JavaController.Common.AccessBridgeInterop.Win32 {
  public static class NativeMethods {
    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(Point p);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
  }
}
