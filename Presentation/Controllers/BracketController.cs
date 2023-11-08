using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class BracketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
