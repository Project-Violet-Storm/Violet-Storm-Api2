using Microsoft.AspNetCore.Mvc;
using violet.storm.Domain.Catalog;

namespace violet.storm.Api.Controller {
    [ApiController]
    [Route("controller")]
    public class CatalogController : ControllerBase {
        [HttpGet]
        public IActionResult GetItems(){
            return Ok("Hello");
        }
    }
}
