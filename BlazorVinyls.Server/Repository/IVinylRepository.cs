using BlazorVinyls.Server.Data;

namespace BlazorVinyls.Server.Repository
{
    public interface IVinylRepository
    {
        Task<IEnumerable<Vinyl>> GetVinyls();
        Task<Vinyl> CreateVinyl(Vinyl vinyl);
    }
}
