using Microsoft.EntityFrameworkCore;
using SupCommerce.Core.Domain;
using SupCommerce.Core.Repositories;
using SupCommerce.Data.Data;

namespace SupCommerce.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(SupCommerceDbContext dbContext) 
            : base(dbContext)
        {
            
        }
    }
}