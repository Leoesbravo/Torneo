using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Presentation.Controllers
{
    public class DetallePartidaModel
    {
        public int IdJugadorUno { get; set; }
        public int Ronda { get; set; }
        public string Username { get; set; }
        public string Username2 { get; set; }
        public int Minions{ get; set; }
        public string DuracionPartida { get; set; }
        public string Campeon { get; set; }
        public string Side { get; set; }
        public bool Ganador { get; set; }
    }
    public class StatsController : Controller
    {
        private Modelo.TorneoContext _context;

        public StatsController(Modelo.TorneoContext context)
        {
            _context = context;
        }
        public IActionResult GetStats(int? idRonda)
        {
            if (idRonda > 0)
            {
                Models.ViewModel partidas = new Models.ViewModel();
                partidas.Partidas = new List<DetallePartidaModel>();
                partidas.Ronda = idRonda;
                var consulta = from partida in _context.Partida
                               where partida.IdRonda == idRonda
                               join detalle in _context.DetallePartida
                               on partida.IdPartida equals detalle.IdPartida
                               join participanteUno in _context.Participantes
                               on partida.IdParticipanteUno equals participanteUno.IdParticipante
                               join participanteDos in _context.Participantes
                               on partida.IdParticipanteDos equals participanteDos.IdParticipante
                               select new DetallePartidaModel
                               {
                                   IdJugadorUno = participanteUno.IdParticipante,
                                   Username = participanteUno.UserName,
                                   Username2 = participanteDos.UserName,
                                   Minions = detalle.Minions.Value,
                                   Side = detalle.Side,
                                   DuracionPartida = partida.Duracion,
                                   Ronda = idRonda.Value,
                                   Ganador = detalle.Ganador.Value,
                                   Campeon = detalle.Campeon
                               };

                var listaDetallePartida = consulta.ToList();
                partidas.Partidas.AddRange(listaDetallePartida);
                return View(partidas);
            }
            else
            {
                Models.ViewModel partidas = new Models.ViewModel();
                partidas.Vistas = new List<VistaResumenJugadore>();
                var enfrentamientosPrevios = _context.VistaResumenJugadores
                .OrderByDescending(jugador => jugador.PartidasGanadas)
                .ToList();
                partidas.Vistas.AddRange(enfrentamientosPrevios);
                return View(partidas);
            }

        }
        public ActionResult SetStats(int? idRonda)
        {
            if (idRonda > 0)
            {
                var result = _context.VistaPartida
                            .Where(vp => vp.IdRonda == idRonda)
                            .Select(vp => new Modelo.VistaPartidum
                            {
                                IdPartida = vp.IdPartida,
                                IdParticipanteUno = vp.IdParticipanteUno,
                                IdParticipanteDos = vp.IdParticipanteDos,
                                UsernameUno = vp.UsernameUno,
                                UsernameDos = vp.UsernameDos,
                                Duracion = vp.Duracion,
                                IdRonda = vp.IdRonda
                            })
                            .ToList();
                return View(result);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SetStats(Models.Stats stats)
        {
            var partidaExistente = _context.Partida.FirstOrDefault(p => p.IdPartida == stats.IdPartida);

            if (partidaExistente != null)
            {
                partidaExistente.Duracion = stats.Duracion.ToString();
                _context.SaveChanges();
            }

            bool blue = false;
            bool red = false;
            if (stats.IdGanador != "Red")
            {
                blue = true;
            }
            else
            {
                red = true;
            }
            var detallePartida = new DetallePartidum
            {
                IdPartida = stats.IdPartida,
                IdParticipante = stats.IdUsuarioUno,
                Minions = stats.CsUno,
                Campeon = stats.CampeonUno,
                Side = "Blue",
                Ganador = blue
            };

            _context.DetallePartida.Add(detallePartida);
            _context.SaveChanges();
            detallePartida = new DetallePartidum
            {
                IdPartida = stats.IdPartida,
                IdParticipante = stats.IdUsuarioDos,
                Minions = stats.CsDos,
                Campeon = stats.CampeonDos,
                Side = "Red",
                Ganador = red
            };

            _context.DetallePartida.Add(detallePartida);
            _context.SaveChanges();
            return View();
        }
    }
}
