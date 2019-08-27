using System;
using System.Drawing;

namespace FriendlyRAT.Core
{
    public interface ISystemControl : IDisposable
    {
        event EventHandler<RenderRegion> RenderRegionReceived;

        event EventHandler<Point> CursorLocationReceived; 

        void SetRegion(Rectangle region);

        void SetCursorLocation(Point point);

        void Init();
    }
}
