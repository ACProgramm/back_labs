using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class UsersController : Controller
    {
        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("users")]
        public ActionResult Index()
        {   
            return Json(new { name = "Andrey Cheporov", email = "andrei@yandex.ru"});
        }
    }
}