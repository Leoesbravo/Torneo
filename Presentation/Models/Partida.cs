namespace Presentation.Models
{
    public class Partida
    {
        public int Idpartida { get; set; }
        public Participante ParticipanteUno { get; set; }
        public Participante ParticipanteDos{ get; set; }
        public string Duracion { get; set; }
        public Ronda Ronda { get; set; }

    }
}
