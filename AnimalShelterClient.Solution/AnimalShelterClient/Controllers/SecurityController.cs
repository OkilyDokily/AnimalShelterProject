using Microsoft.AspNetCore.Mvc;
using AnimalShelterClient.ViewModels;
using AnimalShelterClient.Models;
using System.Threading.Tasks;
using System;

namespace AnimalShelterClient.Controllers
{
  public class SecurityController : Controller
  {
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel login)
    {
      Response.Cookies.Delete("JWT");
      string cookie = await Security.Login(login);
      
      if (cookie == "Your login failed") { return RedirectToAction("Login", "Security"); }
      Response.Cookies.Append("JWT", cookie, new Microsoft.AspNetCore.Http.CookieOptions
      {
        HttpOnly = true,
        IsEssential = true
      });
      return RedirectToAction("Index", "Home");
    }
  }
}