using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class RedesSociales
{
    public int Id { get; set; }

    public string? Plataforma { get; set; }

    public string Url { get; set; } = null!;

    public string? IconoClass { get; set; }
}
