using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using System;

namespace AnimalShelterClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [DisplayName("Animal Type")]
    public string AnimalType { get; set; }
    
    public static async Task<List<Animal>> GetAll()
    {
      string result = await ApiHelper.GetAll();
      List<Animal> animals = JsonSerializer.Deserialize<List<Animal>>(result);
      
      return animals;
    }

    public static async Task<Animal> Get(int id)
    {
      string result = await ApiHelper.Get(id);
      Animal animal = JsonSerializer.Deserialize<Animal>(result);
      return animal;
    }
   
    public static async Task Post(Animal animal,HttpContext context)
    {
      await ApiHelper.Post(animal, context);
    }
   
    public static async Task Delete(int id, HttpContext context)
    {
      await ApiHelper.Delete(id, context);
    }
    
    public static async Task Put(Animal animal, HttpContext context)
    {
      await ApiHelper.Put(animal, context);
    }
  }
}