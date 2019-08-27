using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRAT.Core.Windows
{
    using System.Runtime.InteropServices;

    internal static class Native
    {
        private const string DLL_USER32 = "user32.dll";

        private const string DLL_GDI32 = "gdi32.dll";

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X;

            public int Y;
        }

        [DllImport(DLL_GDI32)]
        public static extern bool BitBlt(IntPtr hdcDest, int nxDest, int nyDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport(DLL_GDI32)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int nHeight);

        [DllImport(DLL_GDI32)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport(DLL_GDI32)]
        public static extern IntPtr DeleteDC(IntPtr hdc);

        [DllImport(DLL_GDI32)]
        public static extern IntPtr DeleteObject(IntPtr hObject);

        [DllImport(DLL_USER32)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport(DLL_USER32)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport(DLL_USER32)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport(DLL_GDI32)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport(DLL_USER32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport(DLL_USER32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);

        public const int SRCCOPY = 0x00CC0020;

        public const int CAPTUREBLT = 0x40000000;
    }
}
