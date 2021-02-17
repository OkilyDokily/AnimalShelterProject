using System.Threading.Tasks;
using RestSharp;
using Microsoft.AspNetCore.Http;
using System;

namespace AnimalShelterClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> Index()
    {
      var client = new RestClient("http://localhost:5000/api/");
      var request = new RestRequest("/animals", DataFormat.Json);
      string results = await client.GetAsync<string>(request);
      Console.WriteLine("adfsdfads");
      Console.WriteLine(results);
      return results;
    }

    public static async Task<string> Details(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest("/animals/" + id, DataFormat.Json);
      string results = await client.GetAsync<string>(request);
      return results;
    }

    public static async Task Create(Animal animal, HttpContext context)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest("/animals/", DataFormat.Json);
      request.AddHeader("Authorization", "Bearer " + context.Request.Cookies["JWT"]);
      request.AddJsonBody(animal);
      await client.PostAsync<Animal>(request);
    }

    public static async Task Remove(int id, HttpContext context)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest("/animals/" + id, DataFormat.Json);
      request.AddHeader("Authorization", "Bearer " + context.Request.Cookies["JWT"]);
      await client.DeleteAsync<Animal>(request);
    }
    
    public static async Task Edit(Animal animal, HttpContext context)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest("/animals/" + animal.AnimalId, DataFormat.Json);
      request.AddHeader("Authorization", "Bearer " + context.Request.Cookies["JWT"]);
      
      request.AddJsonBody(animal);
      await client.PutAsync<Animal>(request);
    }
  }
}