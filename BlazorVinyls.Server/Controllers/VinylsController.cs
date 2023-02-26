using BlazorVinyls.Server.Data;
using BlazorVinyls.Server.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorVinyls.Server.Controllers
{
    [Route("api/vinyls")]
    [ApiController]
    public class VinylsController : ControllerBase
    {
        private readonly IVinylRepository vinylRepository;

        public VinylsController(IVinylRepository vinylRepository)
        {
            this.vinylRepository = vinylRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetVinyls()
        {
            try
            {
                var vinyls = await vinylRepository.GetVinyls();
                return Ok(vinyls);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Vinyl>> CreateViyl(Vinyl vinyl)
        {
            try
            {
                if (vinyl == null)
                    return BadRequest();

                var createdVinyl = await vinylRepository.CreateVinyl(vinyl);

                return CreatedAtAction(nameof(GetVinyls),
                    new { id = createdVinyl.UniqueId }, createdVinyl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new vinyl record");
            }
        }
    }
}
