using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IBaseMongoRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(string id);
        Task<ICollection<T>> GetListAsync();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);
    }
}
