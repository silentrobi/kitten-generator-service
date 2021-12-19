using KittenGeneratorService.Application.Features.Image.Services;
using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Features.Image.Queries.Handlers
{
    public class GenerateVerticalFlippedImageHandler : IQueryHandler<GenerateVerticalFlippedImage, byte[]>
    {
        public async Task<byte[]> Handle(GenerateVerticalFlippedImage query, CancellationToken cancellationToken)
        {
            ImageService imageService = new();

            byte[] imageByte =  await imageService.GetCatImageAsync();

            return ImageTransformUtil.FlipImageVertically(imageByte);
        }
    }
}
