using lab14_1_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace lab14_1_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly MyDataContext _context;

        public DataController(MyDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var data = _context.mydatamodel1.ToList();
            return Ok(data);
        }
    }
}
