using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Partidum
{
    public int IdPartida { get; set; }

    public int? IdParticipanteUno { get; set; }

    public int? IdParticipanteDos { get; set; }

    public string? Duracion { get; set; }

    public virtual ICollection<DetallePartidum> DetallePartida { get; set; } = new List<DetallePartidum>();

    public virtual Participante? IdParticipanteDosNavigation { get; set; }

    public virtual Participante? IdParticipanteUnoNavigation { get; set; }
}
