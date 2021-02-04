using AnimalShelterClient.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimalShelterClient.Controllers
{
    public class AnimalsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Animal> animals = await Animal.Index();
            return View(animals);
        }
    }
}