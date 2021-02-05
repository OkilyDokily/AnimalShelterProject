using AnimalShelterClient.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AnimalShelterClient.Controllers
{
    public class AnimalsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Animal> animals = await Animal.Index();
            return View(animals);
        }

        public async Task<ActionResult> Details(int id)
        {
            Animal animal = await Animal.Details(id);
            return View(animal);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Animal animal)
        {
            await Animal.Create(animal,HttpContext);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Remove(int id)
        {
            await Animal.Remove(id, HttpContext);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            Animal animal = await Animal.Details(id);
            return View(animal);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Animal animal)
        {
            await Animal.Edit(animal, HttpContext);
            return RedirectToAction("Index");
        }

    }
}