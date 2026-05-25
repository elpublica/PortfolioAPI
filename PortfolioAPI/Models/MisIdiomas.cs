using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class MisIdiomas
{
    public int Id { get; set; }

    public string NombreIdioma { get; set; } = null!;

    public string? Nivel { get; set; }

    public int? PorcentajeDominio { get; set; }

    public string? Certificacion { get; set; }
}
