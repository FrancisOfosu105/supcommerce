using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupCommerce.Core;
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

        public async Task<PagedList<Category>> GetPagedCategoriesAsync(QueryParams queryParams)
        {
            var query = _categoryRepository.Table
                .Include(c => c.ParentCategory)
                .AsQueryable();

            //Perform Filtering
            if (!string.IsNullOrWhiteSpace(queryParams.q))
            {
                query = query.Where(c => c.Name.Contains(queryParams.q)).AsQueryable();
            }

            var totalCount = await query.CountAsync();

            query = query.Skip((queryParams.Page - 1) * queryParams.PageSize).Take(queryParams.PageSize);

            return new PagedList<Category>(await query.ToListAsync(), totalCount, queryParams.Page,
                queryParams.PageSize);
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

        public async Task<bool> CategoryExistsAsync(string name, int? id = null)
        {
            if (id.HasValue)
            {
                return await _categoryRepository.Table.AnyAsync(
                    c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && c.Id != id);
            }

            return await _categoryRepository.Table.AnyAsync(
                c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}