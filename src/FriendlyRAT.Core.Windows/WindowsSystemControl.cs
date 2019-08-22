using System;
using System.Drawing;

namespace FriendlyRAT.Core.Windows
{
    public class WindowsSystemControl : ISystemControl
    {
        public event EventHandler<RenderRegion> RenderRegionReceived = (sender, region) => { };

        public void Init()
        {
            var region = new Rectangle(0, 0, 4096, 4096);
            RenderRegionReceived(this, new RenderRegion(region, RegionCapture.Capture(region)));
        }

        public void SetRegion(Rectangle region)
        {
            throw new NotImplementedException();
        }
    }
}
