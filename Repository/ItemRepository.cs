using Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemDbContext _context;

        public ItemRepository(ItemDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Item>> GetAll()
        {
            var items = _context.Items.ToListAsync();
            return items.Result;
        }

        public async Task Create(Item item)
        {
           _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }  
        public async Task Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
