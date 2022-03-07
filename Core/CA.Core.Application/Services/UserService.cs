using System.Linq.Expressions;
using CA.Core.Application.Services.IServices;
using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories.Base;

namespace CA.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(User entity)
        {
            await _unitOfWork.Users.Add(entity);
            return true;
        }

        public async Task<int> Count()
        {
          return await _unitOfWork.Users.Count();
        }

        public async Task<int> Count(Expression<Func<User, bool>> where)
        {
            return await _unitOfWork.Users.Count(where);
        }

        public async Task<bool> Delete<Guid>(Guid ID)
        {
            await _unitOfWork.Users.Delete(ID);
            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            await _unitOfWork.Users.Delete(entity);
            return true;
        }

        public async Task<bool> Delete(Expression<Func<User, bool>> where)
        {
            await _unitOfWork.Users.Delete(where);
            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
          return await _unitOfWork.Users.GetAll();
        }

        public async Task<User> GetById(Guid ID)
        {
            return await _unitOfWork.Users.GetById(ID);
        }

        public async Task<string> GetFirstNameAndLastName(Guid ID)
        {
            return await _unitOfWork.Users.GetFirstNameAndLastName(ID);
        }

        public async Task<IEnumerable<User>> GetMany(Expression<Func<User, bool>> where)
        {
            return await _unitOfWork.Users.GetMany(where);
        }

        public async Task<bool> Update(User entity)
        {
            await _unitOfWork.Users.Update(entity);
            return true;
        }
    }
}