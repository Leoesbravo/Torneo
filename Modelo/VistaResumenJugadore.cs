using System;
using System.Collections.Generic;

namespace Modelo;

public partial class VistaResumenJugadore
{
    public string? NombreJugador { get; set; }

    public int? MinionsTotales { get; set; }

    public int? PartidasGanadas { get; set; }

    public int? PartidasPerdidas { get; set; }

    public string? PromedioDuracionMinutosSegundos { get; set; }
}
