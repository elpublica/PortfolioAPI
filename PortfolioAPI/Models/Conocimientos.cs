using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class Conocimientos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Categoria { get; set; }

    public string? IconoClass { get; set; }

    public string? Nivel { get; set; }
}
