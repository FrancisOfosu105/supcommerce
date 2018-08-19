using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupCommerce.Core;
using SupCommerce.Core.Domain;
using SupCommerce.Core.Repositories;
using SupCommerce.Data.Data;
using SupCommerce.Services.Catalog;
using SupCommerce.Web.Areas.Admin.ViewModels;

namespace SupCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(ICategoryService categoryService, IUnitOfWork
            unitOfWork)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> List()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CategoryFormViewModel
            {
                ParentCategories =
                    await _categoryService.GetParentCategoriesAsync()
            };

            return View("Form", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            if (category == null)
                return NotFound();


            var viewModel = new CategoryFormViewModel
            {
                ParentCategories =
                    await _categoryService.GetParentCategoriesAsync(),
                ParentCategoryId = category.ParentCategoryId,
                Name = category.Name,
                Id = category.Id
            };

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ParentCategories =
                    await _categoryService.GetParentCategoriesAsync();
                return View("Form", model);
            }

            Category category;

            if (model.Id.HasValue)
            {
                category = await _categoryService.GetCategoryAsync(model.Id.Value);

                if (category == null)
                    return NotFound();

                category.Name = model.Name;
                category.ParentCategoryId = model.ParentCategoryId;
            }
            else
            {
                category = new Category
                {
                    Name = model.Name,
                    ParentCategoryId = model.ParentCategoryId
                };

                await _categoryService.InsertAsync(category);
            }

            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);

            if (category == null)
                return NotFound();

            _categoryService.Delete(category);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(List));
        }
    }
}