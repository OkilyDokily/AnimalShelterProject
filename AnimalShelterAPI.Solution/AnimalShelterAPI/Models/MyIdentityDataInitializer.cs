using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AnimalShelterAPI.Models
{
  //class from http://www.binaryintellect.net/articles/5e180dfa-4438-45d8-ac78-c7cc11735791.aspx
  public static class MyIdentityDataInitializer
  {
    public static void SeedData(UserManager<User> userManager)
    {
    }

    public static void SeedUsers(UserManager<User> userManager, IConfiguration configuration)
    {
      if (userManager.FindByNameAsync("user1").Result == null)
      {
        User user = new User();
        user.UserName = "user1";

        userManager.CreateAsync(user, configuration["Password"]).Wait();
      }
    }
  }
}