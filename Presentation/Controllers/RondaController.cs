using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Modelo;

namespace Presentation.Controllers
{
    public class RondaController : Controller
    {
        private Modelo.TorneoContext _context;

        public RondaController(Modelo.TorneoContext context)
        {
            _context = context;
        }
        public ActionResult CrearRondas()
        {
            var participantes = _context.Participantes.ToList();
            return View(participantes);
        }
        [HttpPost]
        public ActionResult CrearRondas([FromBody] Models.Ronda ronda)
        {
            var partida1 = new Partidum
            {
                IdParticipanteUno = ronda.oponente1,
                IdParticipanteDos = ronda.oponente2,
                IdRonda = ronda.idronda,
                Duracion = "00:00" // Asegúrate de proporcionar el valor adecuado aquí
            };
            var partida2 = new Partidum
            {
                IdParticipanteUno = ronda.oponente3,
                IdParticipanteDos = ronda.oponente4,
                IdRonda = ronda.idronda,
                Duracion = "00:00" // Asegúrate de proporcionar el valor adecuado aquí
            };
            var partida3 = new Partidum
            {
                IdParticipanteUno = ronda.oponente5,
                IdParticipanteDos = ronda.oponente6,
                IdRonda = ronda.idronda,
                Duracion = "00:00" // Asegúrate de proporcionar el valor adecuado aquí
            };
            var partida4 = new Partidum
            {
                IdParticipanteUno = ronda.oponente7,
                IdParticipanteDos = ronda.oponente8,
                IdRonda = ronda.idronda,
                Duracion = "00:00"
            };

            _context.Partida.Add(partida1);
            _context.SaveChanges();
            _context.Partida.Add(partida2);
            _context.SaveChanges();
            _context.Partida.Add(partida3);
            _context.SaveChanges();
            _context.Partida.Add(partida4);
            _context.SaveChanges();
            return Ok(1);
        }
        public ActionResult ConsultarRondas()
        {
            var rondas = _context.VistaPartida.ToList();
            var rondasAgrupadas = rondas.GroupBy(r => r.IdRonda)
                                .Select(g => new Models.RondaAgrupada
                                {
                                    IdRonda = g.Key,
                                    Partidas = g.Select(p => new Models.PartidaDetalle
                                    {
                                        IdPartida = p.IdPartida,
                                        IdParticipanteUno = (int)p.IdParticipanteUno,
                                        UsernameUno = p.UsernameUno,
                                        IdParticipanteDos = (int)p.IdParticipanteDos,
                                        UsernameDos = p.UsernameDos,
                                        Duracion = p.Duracion
                                    }).ToList()
                                }).ToList();
            return View(rondasAgrupadas);
        }

    }
}
