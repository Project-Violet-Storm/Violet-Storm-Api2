using Microsoft.AspNetCore.Mvc;
using violet.storm.Domain.Catalog;

namespace violet.storm.Api.Controller {
    [ApiController]
    [Route("controller")]
    public class CatalogController : ControllerBase {
        [HttpGet]
        public IActionResult GetItems(){
            var items = new List<Item>(){
                new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m),
                new Item("Shorts", "Ohio State Shorts", "Nike", 44.99m)
            };
            return Ok(items);
        }

    }
}
