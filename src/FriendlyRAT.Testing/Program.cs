using System;

namespace FriendlyRAT.Testing
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Threading;
    using FriendlyRAT.Core.Windows;

    class Program
    {
        private static int i = 0;

        static void Main(string[] args)
        {
            var control = new WindowsSystemControl();
            control.RenderRegionReceived += Control_RenderRegionReceived;
            control.CursorLocationReceived += Control_CursorLocationReceived;
            control.SetRegion(new Rectangle(0, 0, 1920, 1200));
            control.Init();

            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                var pos = new Point(rand.Next(100), rand.Next(100));
                control.SetCursorLocation(pos);
            }

            Console.ReadKey(true);
            control.Dispose();
        }

        private static void Control_CursorLocationReceived(object sender, Point e)
        {
            Console.WriteLine($"POS: {e.X,4},{e.Y,4}");
        }

        private static void Control_RenderRegionReceived(object sender, Core.RenderRegion e)
        {
            //e.Render.Save($@"C:\tmp\screenshot-{Program.i++:0000}.png", ImageFormat.Png);
        }
    }
}
