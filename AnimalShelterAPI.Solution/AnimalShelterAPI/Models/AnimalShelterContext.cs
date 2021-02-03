using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AnimalShelterAPI.Models
{
  public class AnimalShelterContext : IdentityDbContext
  {
    public DbSet<Animal> Animals { get; set; }
    public DbSet<User> AnimalUsers { get; set; }
    public AnimalShelterContext(DbContextOptions options) : base(options) { }
  }
}