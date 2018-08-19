using System.Collections.Generic;
using System.Threading.Tasks;
using SupCommerce.Core.Domain;

namespace SupCommerce.Services.Catalog
{
    public interface ICategoryService
    {
        Task InsertAsync(Category category);

        void Delete(Category category);
        
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetParentCategoriesAsync();
        
        Task<Category> GetCategoryAsync(int id);
    }
}