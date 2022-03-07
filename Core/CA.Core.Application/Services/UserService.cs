using CA.Core.Application.Services.IServices;
using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories.Base;
using AutoMapper;
using CA.Core.Application.DTOs;

namespace CA.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Add(UserDTO entityDTO)
        {
            var entity = _mapper.Map<User>(entityDTO);
            await _unitOfWork.Users.Add(entity);
            return true;
        }

        public async Task<int> Count()
        {
            return await _unitOfWork.Users.Count();
        }

        public async Task<bool> Delete<Guid>(Guid ID)
        {
            await _unitOfWork.Users.Delete(ID);
            return true;
        }

        public async Task<bool> Delete(UserDTO entityDTO)
        {
            var entity = _mapper.Map<User>(entityDTO);
            await _unitOfWork.Users.Delete(entity);
            return true;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _unitOfWork.Users.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetById(Guid ID)
        {
            var user = await _unitOfWork.Users.GetById(ID);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<string> GetFirstNameAndLastName(Guid ID)
        {
            return await _unitOfWork.Users.GetFirstNameAndLastName(ID);
        }

        public async Task<bool> Update(UserDTO entityDTO)
        {
            var entity = _mapper.Map<User>(entityDTO);
            await _unitOfWork.Users.Update(entity);
            return true;
        }

        public async Task<bool> Any()
        {
            return await _unitOfWork.Users.Any();
        }
    }
}