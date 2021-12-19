using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace KittenGeneratorService.Application.Utils
{
    public class ImageTransformUtil
    {
        public static byte[] FlipImageVertically(byte[] imageInBytes)
        {
            using var image = Image.Load(imageInBytes, out var imageFormat);

            image.Mutate(x => x.Flip(FlipMode.Vertical));

            return ImageToByteArray(image, imageFormat);
        }

        private static byte[] ImageToByteArray(Image image, IImageFormat imageFormat)
        {
            using var ms = new MemoryStream();

            image.Save(ms, imageFormat);
            
            return ms.ToArray();
        }
    }
}
