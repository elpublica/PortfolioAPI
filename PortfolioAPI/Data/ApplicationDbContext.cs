using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models; //Reference to carpet models

namespace PortfolioAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //This property represent the table in the data base
        public DbSet<Proyecto> Proyectos { get; set; }
    }
}