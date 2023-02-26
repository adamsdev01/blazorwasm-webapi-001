using BlazorVinyls.Server.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorVinyls.Server.Repository
{
    public class VinylRepository : IVinylRepository
    {
        private readonly VinylContext dbContext;

        public VinylRepository(VinylContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Vinyl> CreateVinyl(Vinyl vinyl)
        {
            var result = await dbContext.Vinyls.AddAsync(vinyl);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Vinyl>> GetVinyls()
        {
            return await dbContext.Vinyls.ToListAsync();
        }
    }
}
