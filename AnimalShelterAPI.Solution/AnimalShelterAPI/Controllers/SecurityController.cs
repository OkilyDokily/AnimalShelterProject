using AnimalShelterAPI.Models;
using System.Text;
using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterAPI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelterAPI.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  [AllowAnonymous]
  public class SecurityController
  {
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    
    public SecurityController(IConfiguration config, UserManager<User> userManager)
    {
      _userManager = userManager;
      _config = config;
    }

    private string GenerateJSONWebToken()
    {
      var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        _config["Jwt:Issuer"],
        _config["Jwt:Audience"],
        null,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost]
    [Route("/api/security/login")]
    public async Task<string> Login([FromBody] LoginViewModel loginView)
    {
      try
      {
        User user = await _userManager.FindByNameAsync(loginView.Username);
        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginView.Password);
        if (result == PasswordVerificationResult.Success)
        {
          return GenerateJSONWebToken();
        }
        else
        {
          return "Your login failed";
        }
      }
      catch
      {
        return "Your login failed";
      }
    }
  }
}