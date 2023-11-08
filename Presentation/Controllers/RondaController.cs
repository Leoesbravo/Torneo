using Microsoft.AspNetCore.Mvc;
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

            return View();
        }

    }
}
