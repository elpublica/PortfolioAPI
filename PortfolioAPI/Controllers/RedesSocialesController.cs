using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Data;
using PortfolioAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class RedesSocialesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RedesSocialesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RedesSociales>>> GetRedesSociales()
    {
        // Esto traerá todas tus redes (GitHub, LinkedIn, etc.)
        return await _context.RedesSociales.ToListAsync();
    }
}