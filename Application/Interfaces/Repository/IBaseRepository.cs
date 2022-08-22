using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbContext CurrentContext { get; }

        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(string id);
        Task<ICollection<T>> GetListAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);
    }
}
