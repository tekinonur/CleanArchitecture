using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories;
using CA.Infrastructure.Persistence.Repositories.Base;

namespace CA.Infrastructure.Persistence.Repositories
{
        public class ItemRepository  : Repository<Item>, IItemRepository
    {
        public ItemRepository(
            ApplicationDbContext context
        ) : base(context)
        {

        }
    }
}