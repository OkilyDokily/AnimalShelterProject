using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace AnimalShelterClient.Models
{
  public class Animal
  {
    public int animalId { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    [DisplayName("Animal Type")]
    public string animalType { get; set; }
    
    public static async Task<List<Animal>> Index()
    {
      string result = await ApiHelper.Index();
      List<Animal> animals = JsonSerializer.Deserialize<List<Animal>>(result);
      return animals;
    }
    public static async Task<Animal> Details(int id)
    {
      string result = await ApiHelper.Details(id);
      Animal animal = JsonSerializer.Deserialize<Animal>(result);
      return animal;
    }
    public static async Task Create(Animal animal,HttpContext context)
    {
      await ApiHelper.Create(animal, context);
    }
    public static async Task Remove(int id, HttpContext context)
    {
      await ApiHelper.Remove(id, context);
    }
    public static async Task Edit(Animal animal, HttpContext context)
    {
      await ApiHelper.Edit(animal, context);
    }
  }
}