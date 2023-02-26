using Entities.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;

namespace BlazorVinyls.Client.HttpRepository
{
    public class VinylHttpRepository : IVinylHttpRepository
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions options;

        public VinylHttpRepository(HttpClient _httpClient)
        {
            httpClient = _httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task CreateVinyl(Vinyl vinyl)
        {
            var content = JsonSerializer.Serialize(vinyl);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await httpClient.PostAsync("vinyls", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task<List<Vinyl>> GetVinyls()
        {
            var response = await httpClient.GetAsync("vinyls");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var vinyls = JsonSerializer.Deserialize<List<Vinyl>>(content, options);

            return vinyls;
        }

        public async Task<string> UploadVinylImage(MultipartFormDataContent content)
        {
            var postResult = await httpClient.PostAsync("upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("https://localhost:5011/", postContent);
                return imgUrl;
            }
        }
    }
}
