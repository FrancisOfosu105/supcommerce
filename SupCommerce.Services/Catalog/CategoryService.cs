using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupCommerce.Core.Domain;
using SupCommerce.Core.Repositories;

namespace SupCommerce.Services.Catalog
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task InsertAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.Table
                .Include(c => c.ParentCategory)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetParentCategoriesAsync()
        {
            return await _categoryRepository.Table
                .Where(c => c.ParentCategoryId == null)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }
    }
}