using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupCommerce.Core.Domain;
using SupCommerce.Data.Data;
using SupCommerce.Web.Areas.Admin.ViewModels;

namespace SupCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly SupCommerceDbContext _dbContext;

        public ProductsController(SupCommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET
        public async Task<IActionResult> List()
        {
            return View(await _dbContext.Set<Product>().Include(p=>p.Category).ToListAsync());
        }


        // GET
        public async Task<IActionResult> Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Categories = await _dbContext.Set<Category>().ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _dbContext.Set<Category>().ToListAsync();
                return View("Create",model);
            }
            var product = new Product
            {
                CategoryId = model.CategoryId,
                Price = model.Price,
                FullDescription = model.FullDescription,
                Name = model.Name,
                ShortDescription = model.ShortDescription
                
            };

            await _dbContext.Set<Product>().AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));

        }
    }
}