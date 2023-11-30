namespace Presentation.Models
{
    public class ViewModel
    {
        public List<Modelo.VistaResumenJugadore> Vistas {get; set;}
        public List<Presentation.Controllers.DetallePartidaModel> Partidas { get; set;}
        public Modelo.DetallePartidum Jugador1 { get; set; }
        public Modelo.DetallePartidum Jugador2 { get; set; }
        public int? Ronda { get; internal set; }
    }
}
