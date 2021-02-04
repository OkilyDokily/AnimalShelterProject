using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System;

namespace AnimalShelterClient.Models
{
  public class Animal
  {
    public int animalId { get; set; }
    public string name { get; set; }
    public string animalType { get; set; }


    public static async Task<List<Animal>> Index()
    {
      string result = await ApiHelper.GetAnimals();
      Console.WriteLine(result);
      List<Animal> animals = JsonSerializer.Deserialize<List<Animal>>(result);
      foreach (Animal a in animals)
      {
        Console.WriteLine(a.name);
      }
      return animals;
    }
  }
}