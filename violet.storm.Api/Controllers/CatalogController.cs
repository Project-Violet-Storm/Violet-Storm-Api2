using Microsoft.AspNetCore.Mvc;
using violet.storm.Domain.Catalog;
using violet.storm.data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace violet.storm.Api.Controller {
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase {

        private readonly StoreContext _db;

        public CatalogController(StoreContext db) {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetItems(){

            return Ok(_db.Items);
        }
/*
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id){
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;

            return Ok(item);
        }
 */

 
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id){
        
            var item = _db.Items.Find(id);
            if (item == null){
                return NotFound();
            }
            return Ok(item);
        }

/*        [HttpPost]
        public IActionResult Post(Item item){

            return Created("/Catalog/42", item);
        }

*/
        [HttpPost]
        public IActionResult Post(Item item){
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);

        }

 /*       [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating){
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);
        }
*/

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating){
            var item = _db.Items.Find(id);
            if (item ==null){
                return NotFound();
            }

            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }
/*
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item){
            return NoContent();
        }
*/     

        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id,[FromBody] Item item){
            if (id !=item.Id ){
                return BadRequest();
            }
            if (_db.Items.Find(id) == null){
                return NotFound();
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
            //return Ok(item);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id){
            var item = _db.Items.Find(id);
            if(item == null){
                return NotFound();
            }
            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }

    }
}
