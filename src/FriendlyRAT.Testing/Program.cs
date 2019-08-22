using System;

namespace FriendlyRAT.Testing
{
    using System.Drawing.Imaging;
    using System.Linq;
    using FriendlyRAT.Core.Windows;

    class Program
    {
        static void Main(string[] args)
        {
            var control = new WindowsSystemControl();
            control.RenderRegionReceived += Control_RenderRegionReceived;
            control.Init();
            Console.WriteLine("Hello World!");
        }

        private static void Control_RenderRegionReceived(object sender, Core.RenderRegion e)
        {
            e.Render.Save(@"C:\tmp\screenshot.png", ImageFormat.Png);

            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            var qualityEncoder = Encoder.Quality;
            var encoderParameters = new EncoderParameters(1);
            var qualityParameter = new EncoderParameter(qualityEncoder, 25L);
            encoderParameters.Param[0] = qualityParameter;
            e.Render.Save(@"C:\tmp\screenshot.jpg", jpgEncoder, encoderParameters);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format) => ImageCodecInfo.GetImageEncoders().SingleOrDefault(o => o.FormatID == format.Guid);
    }
}
