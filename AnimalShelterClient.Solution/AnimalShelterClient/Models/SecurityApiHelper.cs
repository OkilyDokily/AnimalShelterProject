using RestSharp;

namespace AnimalShelterClient.Models
{
    public class SecurityApiHelper
    {

        public async Task Login()
        {
            var client = new RestClient("https://localhost:5000/api/");
            var request = new RestRequest("/security/login", DataFormat.Json);
            var response = client.Get(request);
            await client.GetAsync<HomeTimeline>(request, cancellationToken);
        }    
    }
}