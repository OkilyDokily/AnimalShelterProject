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
      List<Animal> animals = await Animal.GetAll();
      return View(animals);
    }

    public async Task<ActionResult> Details(int id)
    {
      Animal animal = await Animal.Get(id);
      return View(animal);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Animal animal)
    {
      await Animal.Post(animal, HttpContext);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> Remove(int id)
    {
      await Animal.Delete(id, HttpContext);
      return RedirectToAction("Index");
    }

    public async Task<ActionResult> Edit(int id)
    {
      Animal animal = await Animal.Get(id);
      return View(animal);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Animal animal)
    {
      await Animal.Put(animal, HttpContext);
      return RedirectToAction("Index");
    }
  }
}