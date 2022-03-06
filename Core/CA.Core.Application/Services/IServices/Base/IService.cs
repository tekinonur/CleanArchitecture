using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CA.Core.Application.Services.IServices.Base
{
    public interface IService<T>
    {
        Task<bool> Add(T entity);
        Task<bool> Delete<TId>(TId ID);
        Task<bool> Delete(T entity);
        Task<bool> Delete(Expression<Func<T, bool>> where);
        Task<bool> Update(T entity);
        Task<T> GetById(Guid ID);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where);
        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> where);
    }
}