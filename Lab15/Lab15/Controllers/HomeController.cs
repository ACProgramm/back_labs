using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab15.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
