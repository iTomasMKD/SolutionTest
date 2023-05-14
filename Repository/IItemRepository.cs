using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAll();
        Task Create(Item item);
        Task Delete(int id);
        Task Update(Item item);
        
    }
}
