using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TestApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            await _repository.Create(item);
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _repository.Update(item);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            var items = await _repository.GetAll();       
        }
    }
}
