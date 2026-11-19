using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1MyWebApp.DataFolder;
using WebApplication1MyWebApp.DTO;
using WebApplication1MyWebApp.Models;

namespace WebApplication1MyWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(userDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", userDto);
            }

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email
            };

            var passwordHasher = new PasswordHasher<User>();

            user.PasswordHash = passwordHasher.HashPassword(user, userDto.Password);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }
    }
}