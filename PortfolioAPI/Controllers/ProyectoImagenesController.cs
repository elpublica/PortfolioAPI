using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Data;
using PortfolioAPI.Filters;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoImagenesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProyectoImagenesController(ApplicationDbContext context) => _context = context;

        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<ProyectoImagenes>> PostImagen(ProyectoImagenes img)
        {
            // img.Url debe ser algo como "https://mi-servidor.com/fotos/proyecto1.jpg"
            _context.ProyectoImagenes.Add(img);
            await _context.SaveChangesAsync();
            return Ok(img);
        }

        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagen(int id)
        {
            var img = await _context.ProyectoImagenes.FindAsync(id);
            if (img == null) return NotFound();
            _context.ProyectoImagenes.Remove(img);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
