using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
