using System.Linq.Expressions;
using CA.Core.Application.Services.IServices;
using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories.Base;

namespace CA.Core.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Item entity)
        {
            await _unitOfWork.Items.Add(entity);
            return true;
        }

        public async Task<int> Count()
        {
            return await _unitOfWork.Items.Count();
        }

        public async Task<int> Count(Expression<Func<Item, bool>> where)
        {
            return await _unitOfWork.Items.Count(where);
        }

        public async Task<bool> Delete<Guid>(Guid ID)
        {
            await _unitOfWork.Items.Delete(ID);
            return true;
        }

        public async Task<bool> Delete(Item entity)
        {
            await _unitOfWork.Items.Delete(entity);
            return true;
        }

        public async Task<bool> Delete(Expression<Func<Item, bool>> where)
        {
            await _unitOfWork.Items.Delete(where);
            return true;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _unitOfWork.Items.GetAll();
        }

        public async Task<Item> GetById(Guid ID)
        {
            return await _unitOfWork.Items.GetById(ID);
        }

        public async Task<IEnumerable<Item>> GetMany(Expression<Func<Item, bool>> where)
        {
            return await _unitOfWork.Items.GetMany(where);
        }

        public async Task<bool> Update(Item entity)
        {
            await _unitOfWork.Items.Update(entity);
            return true;
        }

        public async Task<bool> Any()
        {
            return await _unitOfWork.Items.Any();
        }
    }
}