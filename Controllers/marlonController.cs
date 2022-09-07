using Microsoft.AspNetCore.Mvc;

namespace empleados.Controllers
{
    public class marlonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
