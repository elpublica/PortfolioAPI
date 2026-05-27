using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabilidadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HabilidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadesBlandas>>> GetHabilidades()
        {
            return await _context.HabilidadesBlandas.ToListAsync();
        }
    }
}
