using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class StatsController : Controller
    {
        private Modelo.TorneoContext _context;

        public StatsController(Modelo.TorneoContext context)
        {
            _context = context;
        }
        public IActionResult GetStats()
        {
            var enfrentamientosPrevios = _context.VistaResumenJugadores
           .OrderByDescending(jugador => jugador.PartidasGanadas)
           .ToList();
            return View(enfrentamientosPrevios);
        }
    }
}
