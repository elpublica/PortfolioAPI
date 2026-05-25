using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class HabilidadesBlandas
{
    public int Id { get; set; }

    public string Habilidad { get; set; } = null!;

    public string? Idioma { get; set; }
}
