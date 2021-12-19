using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KittenGeneratorService.Application.Features.Image.Services
{
    public class ImageService
    {
        private const string  BASE_URL = "https://cataas.com/";
        private readonly HttpClient Client = new();
        public async Task<byte[]> GetCatImageAsync()
        {
            byte[] image = null;

            Client.BaseAddress = new Uri(BASE_URL);
            Client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await Client.GetAsync("cat");
            if (response.IsSuccessStatusCode)
            {
                image = await response.Content.ReadAsByteArrayAsync();
            }

            return image;
        }
    }
}
