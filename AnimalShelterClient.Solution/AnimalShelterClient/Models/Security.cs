using RestSharp;
using AnimalShelterClient.ViewModels;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace AnimalShelterClient.Models
{
    public class Security
    {
        public static async Task<string> Login(LoginViewModel login)
        {
            string result = await SecurityApiHelper.Login(login);
            return result;
        }
    }
}