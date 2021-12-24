using KittenGeneratorService.Application.Exceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Features.Image.Services
{
    public class ImageService
    {
        private readonly string BASE_URL = "https://cataas.com/";
        private readonly HttpClient Client = new();
        public async Task<byte[]> GetCatImageAsync()
        {
            byte[] image;

            Client.BaseAddress = new Uri(BASE_URL);
            Client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await Client.GetAsync("cat");

            if (response.IsSuccessStatusCode)
            {
                image = await response.Content.ReadAsByteArrayAsync();
            }
            else
            {
                throw new ExternalServiceException("Failed to get data");
            }

            return image;
        }
    }
}
