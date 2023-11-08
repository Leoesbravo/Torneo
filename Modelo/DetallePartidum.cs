using System;
using System.Collections.Generic;

namespace Modelo;

public partial class DetallePartidum
{
    public int IdDetalle { get; set; }

    public int? IdPartida { get; set; }

    public int? IdParticipante { get; set; }

    public int? Minions { get; set; }

    public string? Campeon { get; set; }

    public string? Side { get; set; }

    public bool? Ganador { get; set; }

    public virtual Participante? IdParticipanteNavigation { get; set; }

    public virtual Partidum? IdPartidaNavigation { get; set; }
}
