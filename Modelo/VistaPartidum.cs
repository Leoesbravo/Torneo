using System;
using System.Collections.Generic;

namespace Modelo;

public partial class VistaPartidum
{
    public int IdPartida { get; set; }

    public int? IdParticipanteUno { get; set; }

    public string? UsernameUno { get; set; }

    public int? IdParticipanteDos { get; set; }

    public string? UsernameDos { get; set; }

    public string? Duracion { get; set; }

    public int? IdRonda { get; set; }

}
