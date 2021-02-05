using AnimalShelterClient.ViewModels;
using System.Threading.Tasks;

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