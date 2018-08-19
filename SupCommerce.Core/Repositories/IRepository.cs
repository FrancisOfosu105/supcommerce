using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SupCommerce.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);

        Task AddAsync(T entity);

        void Remove(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void RemoveRange(IEnumerable<T> entities);

        DbSet<T> Table { get; }
    }
}