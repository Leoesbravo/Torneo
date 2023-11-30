using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Rondum
{
    public int IdRonda { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Partidum> Partida { get; set; } = new List<Partidum>();
}
