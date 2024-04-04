using Microsoft.AspNetCore.Mvc;
using MyProject.Utils;

namespace MyProject
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return new HtmlResult("<center><h1>MainPage</h1>" +
            "<a href=\"/auth-me/test-username\">Get token</a>" +
            "<h1></h1>" +
            "<a href=\"/users\">To Users</a> " + "<center><h2>Тестировать в postman</h2> ");

        }
    }
}