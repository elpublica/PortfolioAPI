using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConocimientosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ConocimientosController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conocimientos>>> GetConocimientos()
        {
            return await _context.Conocimientos.ToListAsync();
        }
    }
}
