using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class Estudios
{
    public int Id { get; set; }

    public string Institucion { get; set; } = null!;

    public string Grado { get; set; } = null!;

    public string? FechaPeriodo { get; set; }

    public bool? EsCertificacion { get; set; }

    public string? Idioma { get; set; }
}
