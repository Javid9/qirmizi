using ImageMagick;
using ImageMagick.Formats;
using Microsoft.AspNetCore.Http;

namespace Application.Helpers
{
    public static class ImageOptimizeExtensions
    {
        public static async Task<bool> ImageOptimize(this IFormFile? file, string path)
        {
            if (!File.Exists(path)) return false;

            using MagickImage image = new(path);
            image.Settings.SetDefines(new JpegWriteDefines()
            {
                SamplingFactor = JpegSamplingFactor.Ratio420
            });
            image.Strip();
            image.Quality = 85;
            image.Interlace = Interlace.Jpeg;
            image.ColorSpace = ColorSpace.sRGB;
            await image.WriteAsync(path);

            return true;

        }
    }
}
