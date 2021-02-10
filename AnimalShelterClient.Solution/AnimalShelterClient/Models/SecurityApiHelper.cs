using RestSharp;
using AnimalShelterClient.ViewModels;
using System.Threading.Tasks;
using System;

namespace AnimalShelterClient.Models
{
  public class SecurityApiHelper
  {
    public static async Task<string> Login(LoginViewModel loginView)
    {
      var client = new RestClient("http://localhost:5000/api/");
      var request = new RestRequest("/security/login", DataFormat.Json);
      request.AddJsonBody(new { Username = loginView.Username, Password = loginView.Password });
      string result = await client.PostAsync<string>(request);
      return result;
    }
  }
}