using System;

namespace FriendlyRAT.Testing
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using FriendlyRAT.Core.Windows;

    class Program
    {
        private static int i = 0;

        static void Main(string[] args)
        {
            var control = new WindowsSystemControl();
            control.RenderRegionReceived += Control_RenderRegionReceived;
            control.SetRegion(new Rectangle(0, 0, 1920, 1200));
            control.Init();
            Console.ReadKey(true);
            control.Dispose();
        }

        private static void Control_RenderRegionReceived(object sender, Core.RenderRegion e)
        {
            e.Render.Save($@"C:\tmp\screenshot-{Program.i++:0000}.png", ImageFormat.Png);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format) => ImageCodecInfo.GetImageEncoders().SingleOrDefault(o => o.FormatID == format.Guid);
    }
}
