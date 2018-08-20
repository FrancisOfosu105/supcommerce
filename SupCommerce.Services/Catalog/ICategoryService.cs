using System.Collections.Generic;
using System.Threading.Tasks;
using SupCommerce.Core;
using SupCommerce.Core.Domain;

namespace SupCommerce.Services.Catalog
{
    public interface ICategoryService
    {
        Task InsertAsync(Category category);

        void Delete(Category category);
        
        Task<PagedList<Category>> GetPagedCategoriesAsync(QueryParams queryParams);
        
        Task<IEnumerable<Category>> GetParentCategoriesAsync();
        
        Task<Category> GetCategoryAsync(int id);
        
        Task<bool> CategoryExistsAsync(string name, int? id = null);
    }
}