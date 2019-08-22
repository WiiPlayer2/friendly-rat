namespace FriendlyRAT.Core
{
    using System.Drawing;

    public readonly struct RenderRegion
    {
        public Rectangle Region { get; }

        public Bitmap Render { get; }

        public RenderRegion(Rectangle region, Bitmap render)
        {
            this.Region = region;
            this.Render = render;
        }
    }
}