using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Models;
using PortfolioAPI.Filters;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")] // The route will be: api/proyectos
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor: We ask .NET to pass us the connection to the DB
        public ProyectosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Proyectos (Get all proyects)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyectos>>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyectos>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // POST: api/Proyectos (Save a new proyect)
        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<Proyectos>> PostProyecto(Proyectos proyecto)
        {
            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
        }

        // PUT: api/Proyectos/1 (Update one proyect)
        [ApiKey]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyectos proyecto)
        {
            if (id != proyecto.Id) return BadRequest();

            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Proyectos.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Proyectos/1 (Delete one proyect)
        [ApiKey]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null) return NotFound();

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}