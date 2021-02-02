using AnimalShelterAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
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
    private string GenerateJSONWebToken(string username)
    {
      var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        _config["Jwt:Issuer"],
        audience: username,
        null,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost]
    [Route("/api/security/register")]
    [AllowAnonymous]
    public async Task Register([FromBody] RegisterViewModel registerView)
    {
      Console.WriteLine(registerView.Username);
      await _userManager.CreateAsync(new User { UserName = registerView.Username }, registerView.Password);

    }

    // [HttpPost]
    // public async Task<string> Login([FromBody] LoginViewModel loginView)
    // {

    //   return GenerateJSONWebToken(loginView.Username);
    // }
  }


}