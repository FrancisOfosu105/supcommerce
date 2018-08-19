using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupCommerce.Core.Repositories;

namespace SupCommerce.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected Repository(DbContext dbContext)
        {
            Table = dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await Table.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public DbSet<T> Table { get; }
    }
}