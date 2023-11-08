using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Participante
{
    public int IdParticipante { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<DetallePartidum> DetallePartida { get; set; } = new List<DetallePartidum>();

    public virtual ICollection<Partidum> PartidumIdParticipanteDosNavigations { get; set; } = new List<Partidum>();

    public virtual ICollection<Partidum> PartidumIdParticipanteUnoNavigations { get; set; } = new List<Partidum>();
}
