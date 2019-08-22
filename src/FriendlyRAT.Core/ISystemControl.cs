using System;
using System.Drawing;

namespace FriendlyRAT.Core
{
    public interface ISystemControl
    {
        event EventHandler<RenderRegion> RenderRegionReceived;

        void SetRegion(Rectangle region);

        void Init();
    }
}
