using Entities.Models;

namespace BlazorVinyls.Client.HttpRepository
{
    public interface IVinylHttpRepository
    {
        Task<List<Vinyl>> GetVinyls();
        Task CreateVinyl(Vinyl vinyl);
        Task<string> UploadVinylImage(MultipartFormDataContent content);
    }
}
