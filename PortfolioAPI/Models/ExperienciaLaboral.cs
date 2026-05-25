using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class ExperienciaLaboral
{
    public int Id { get; set; }

    public string Empresa { get; set; } = null!;

    public string Puesto { get; set; } = null!;

    public string? FechaInicio { get; set; }

    public string? FechaFin { get; set; }

    public string? DescripcionLogros { get; set; }

    public string? Idioma { get; set; }

    public virtual ICollection<Proyectos> Proyectos { get; set; } = new List<Proyectos>();
}
