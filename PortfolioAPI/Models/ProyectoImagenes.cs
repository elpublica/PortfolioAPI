using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class ProyectoImagenes
{
    public int Id { get; set; }

    public int ProyectoId { get; set; }

    public string Url { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? Orden { get; set; }

    public virtual Proyectos Proyecto { get; set; } = null!;
}
