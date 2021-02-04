using System.Threading.Tasks;
using RestSharp;
using System;



namespace AnimalShelterClient.Models
{
    public class ApiHelper
    {
        public static async Task<string> GetAnimals()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("/animals", DataFormat.Json);
            string results = await client.GetAsync<string>(request);
            return results;
        }
    }
}