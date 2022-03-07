using AutoMapper;
using CA.Core.Application.DTOs;
using CA.Core.Application.Services.IServices;
using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories.Base;

namespace CA.Core.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Add(ItemDTO entityDTO)
        {
            var entity = _mapper.Map<Item>(entityDTO);
            await _unitOfWork.Items.Add(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<int> Count()
        {
            return await _unitOfWork.Items.Count();
        }

        public async Task<bool> Delete<Guid>(Guid ID)
        {
            await _unitOfWork.Items.Delete(ID);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> Delete(ItemDTO entityDTO)
        {
            var entity = _mapper.Map<Item>(entityDTO);
            await _unitOfWork.Items.Delete(entity);
            return true;
        }

        public async Task<IEnumerable<ItemDTO>> GetAll()
        {
            var items = await _unitOfWork.Items.GetAll();
            return _mapper.Map<List<ItemDTO>>(items);
        }

        public async Task<ItemDTO> GetById(Guid ID)
        {
            var item = await _unitOfWork.Items.GetById(ID);
            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<bool> Update(ItemDTO entityDTO)
        {
            var entity = _mapper.Map<Item>(entityDTO);
            await _unitOfWork.Items.Update(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> Any()
        {
            return await _unitOfWork.Items.Any();
        }
    }
}