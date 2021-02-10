using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelterAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    [Route("/api/animals")]
    public List<Animal> Get()
    {
      return _db.Animals.ToList();
    }

    [HttpGet("{id}")]
    public Animal Get(int id)
    {
      Animal animal = _db.Animals.FirstOrDefault(x => x.AnimalId == id);
      return animal;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public void Put(int id, [FromBody] Animal animal)
    {
      animal.AnimalId = id;
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public void Delete(int id)
    {
      Animal animal = _db.Animals.FirstOrDefault(x => x.AnimalId == id);
      _db.Animals.Remove(animal);
      _db.SaveChanges();
    }
  }
}
