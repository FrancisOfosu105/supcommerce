using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupCommerce.Core;
using SupCommerce.Core.Domain;
using SupCommerce.Core.Extentsions;
using SupCommerce.Services.Catalog;
using SupCommerce.Services.Picture;
using SupCommerce.Web.Areas.Admin.ViewModels;

namespace SupCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPictureService _pictureService;

        public CategoriesController(ICategoryService categoryService, IUnitOfWork
            unitOfWork, IMapper mapper, IPictureService pictureService)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pictureService = pictureService;
        }

        public async Task<IActionResult> List([FromQuery] QueryParams queryParams)
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = await _categoryService.GetPagedCategoriesAsync(queryParams),
                q = queryParams.q
            };

            return View(viewModel);
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


            var viewModel = _mapper.Map<Category, CategoryFormViewModel>(category);

            viewModel.ParentCategories = await _categoryService.GetParentCategoriesAsync();


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
                
                var categoryExists = await _categoryService.CategoryExistsAsync(model.Name, model.Id);
                if (categoryExists)
                {
                    ModelState.AddModelError(String.Empty, "A category with similar name exists.");
                    model.ParentCategories =
                        await _categoryService.GetParentCategoriesAsync();
                    return View("Form", model);
                }

                _mapper.Map(model, category);

                category.Slug = model.Name.Slugify();
               
                if (model.File != null)
                {
                    //Remove the old picture if there is any

                    _pictureService.Remove(category.FileName);
                    
                    //Upload the picture
                    var fileName = await _pictureService.UploadAsync(model.File);

                    category.FileName = fileName;

                }
               
            }
            else
            {
                
                //validate the category name
                var categoryExists = await _categoryService.CategoryExistsAsync(model.Name);
                if (categoryExists)
                {
                    ModelState.AddModelError(String.Empty, "A category with similar name exists.");
                    model.ParentCategories =
                        await _categoryService.GetParentCategoriesAsync();
                    return View("Form", model);
                }
                
                category = _mapper.Map<CategoryFormViewModel, Category>(model);
                category.Slug = model.Name.Slugify();

                if (model.File != null)
                {
                    //Upload the picture
                    var fileName = await _pictureService.UploadAsync(model.File);

                    category.FileName = fileName;

                }
               
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