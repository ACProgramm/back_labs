using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace StateManagementExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // �������� ��� �� ������
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpPost]
        public IActionResult SetUserName(string userName)
        {
            // ��������� ��� � ������
            HttpContext.Session.SetString("UserName", userName);
            return RedirectToAction("Index");
        }
    }
}
