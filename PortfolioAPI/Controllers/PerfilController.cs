using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Filters;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PerfilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Perfil
        [HttpGet]
        public async Task<ActionResult<PerfilPersonal>> GetPerfil()
        {
            // We take the firts register of the table
            var perfil = await _context.PerfilPersonals.FirstOrDefaultAsync();

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // PUT: api/Perfil/1 For when we update since the dashboard admin in vue
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, PerfilPersonal perfil)
        {
            if (id != perfil.Id) return BadRequest();

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PerfilPersonals.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }
    }
}