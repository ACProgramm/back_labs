using Microsoft.AspNetCore.Mvc;

namespace lab11.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static List<Item> _items = new List<Item>();

        [HttpGet]
        public IActionResult GetItem()
        {
            return Ok(_items);
        }

        [HttpPost]
        public IActionResult AddItem(int id, string name, decimal price)
        {
            Item item = new Item {Id = id, Name = name, Price = price};
            _items.Add(item);
            return Ok(item);
        }

        [HttpPut]
        public IActionResult UpdateItem(int id, string name, decimal price)
        {
            var itemToUpdate = _items.Find(item => item.Id == id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = name;
                itemToUpdate.Price = price;
                return Ok(itemToUpdate);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            var itemToDelete = _items.Find(item => item.Id == id);
            if (itemToDelete != null)
            {
                _items.Remove(itemToDelete);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
