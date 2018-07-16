using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupCommerce.Core.Domain;
using SupCommerce.Data.Data;
using SupCommerce.Web.Areas.Admin.ViewModels;

namespace SupCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly SupCommerceDbContext _dbContext;

        public CategoriesController(SupCommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> List()
        {
            var categories = await _dbContext.Set<Category>().ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CategoryFormViewModel
            {
                Categories = await _dbContext.Set<Category>().Where(c => c.ParentCategory == null).ToListAsync()
            };

            return View("Form",viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _dbContext.Set<Category>().FindAsync(id);

            if (category == null)
                return NotFound();
            
            
            var viewModel = new CategoryFormViewModel
            {
                Categories = await _dbContext.Set<Category>().Where(c => c.ParentCategory == null).ToListAsync(),
                ParentCategoryId = category.ParentCategoryId,
                Name = category.Name
            };

            return View("Form",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _dbContext.Set<Category>().Where(c => c.ParentCategory == null).ToListAsync();
                return View("Form", model);
            }

            var category = new Category
            {
                Name = model.Name,
                ParentCategoryId = model.ParentCategoryId
            };

            await _dbContext.Set<Category>().AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }
    }
}