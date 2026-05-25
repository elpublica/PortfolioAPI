using System;
using System.Collections.Generic;

namespace PortfolioAPI.Models;

public partial class PerfilPersonal
{
    public int Id { get; set; }

    public string? NombreCompleto { get; set; }

    public string? TituloProfesional { get; set; }

    public string? ResumenProfesional { get; set; }

    public string? Ubicacion { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? FotoPerfilUrl { get; set; }

    public string? UrlCv { get; set; }

    public string? Idioma { get; set; }
}
