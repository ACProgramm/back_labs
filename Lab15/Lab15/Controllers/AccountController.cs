using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lab15; // Это для использования класса Users
using System.Security.Claims; // Это для использов

public class AccountController : Controller
{
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(Users user)
    {
        var users = new Users();
        var result = users.GetUsers().FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        if (result != null)
        {
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, result.Username),
                new Claim(ClaimTypes.Role, result.Role)
            };

            var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

            return RedirectToAction("Index", "Home");
        }

        return View(user);
    }

    [HttpPost]
    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}
