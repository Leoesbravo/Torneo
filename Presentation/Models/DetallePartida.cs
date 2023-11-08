namespace Presentation.Models
{
    public class DetallePartida
    {
        public int IdDetalle { get; set; }
        public Partida IdPartida { get; set; }
        public Participante IdParticipante { get; set; }
        public int Minions { get; set; }
        public string Campeon { get; set; }
        public string Side { get; set; }
        public bool Ganador { get; set; }
    }
}
