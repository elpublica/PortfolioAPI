using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Filters;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ExperienciaController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienciaLaboral>>> GetExperiencias()
        {
            return await _context.ExperienciaLaborals
                .OrderByDescending(e => e.FechaInicio)
                .ToListAsync();
        }

        [ApiKey]
        [HttpPost]
        public async Task<ActionResult<ExperienciaLaboral>> PostExperiencia(ExperienciaLaboral exp)
        {
            _context.ExperienciaLaborals.Add(exp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExperiencias), new { id = exp.Id }, exp);
        }
    }
}
