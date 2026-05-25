namespace PortfolioAPI.Models
{
    public class Proyecto
    {
        public int Id { get; set; } // Entity Framework lo hará PK automáticamente
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Tecnologias { get; set; } = string.Empty;
        public string? LinkGitHub { get; set; }
        public string? LinkDemo { get; set; }
        public string? ImagenURL { get; set; }
    }
}
