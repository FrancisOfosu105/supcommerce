using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupCommerce.Core;
using SupCommerce.Data.Data;

namespace SupCommerce.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SupCommerceDbContext _dbContext;
        
        public UnitOfWork(SupCommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CompleteAsync()
        {
             await _dbContext.SaveChangesAsync();
        }
    }
}