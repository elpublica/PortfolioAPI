using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class Proyectos
{
    public int Id { get; set; }

    public int? ExperienciaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Area { get; set; }

    public string? Tecnologias { get; set; }

    public string? LinkGitHub { get; set; }

    public string? LinkDemo { get; set; }

    public string Idioma { get; set; } = null!;

    public string ResumenCorto { get; set; } = null!;

    public string? ContextoProblema { get; set; }

    public string? SolucionImplementada { get; set; }

    public string? ResultadosLogros { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ExperienciaLaboral? Experiencia { get; set; }

    public virtual ICollection<ProyectoImagenes> ProyectoImagenes { get; set; } = new List<ProyectoImagenes>();
}
