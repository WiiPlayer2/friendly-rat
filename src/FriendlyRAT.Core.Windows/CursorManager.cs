using System;
using System.Collections.Generic;
using System.Text;

namespace FriendlyRAT.Core.Windows
{
    using System.ComponentModel;
    using System.Drawing;

    public static class CursorManager
    {
        public static Point GetCursor()
        {
            if (Native.GetCursorPos(out var pos))
                return new Point(pos.X, pos.Y);

            throw new Win32Exception();
        }

        public static void SetCursor(Point point)
        {
            if (!Native.SetCursorPos(point.X, point.Y))
                throw new Win32Exception();
        }
    }
}
