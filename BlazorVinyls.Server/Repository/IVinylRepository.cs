using BlazorVinyls.Server.Data;
using Entities.Models;

namespace BlazorVinyls.Server.Repository
{
    public interface IVinylRepository
    {
        Task<IEnumerable<Vinyl>> GetVinyls();
        Task<Vinyl> CreateVinyl(Vinyl vinyl);
    }
}
