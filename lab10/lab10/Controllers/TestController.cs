using Microsoft.AspNetCore.Mvc;
using System;

namespace lab10.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetJson(string str)
        {
            return Ok(new Result { Test = "Test", Test1 = "Test1", Test2 = str });
        }

        [HttpGet]
        public IActionResult GetHtml(string str)
        {
            var htmlContent = $"<html><body><h1>{str}</h1></body></html>";
            return Ok(htmlContent);
        }
    }

    public class Result
    {
        public string Test { get; set; }
        public string Test1 { get; set; }
        public string Test2 { get; set; }
    }
}
