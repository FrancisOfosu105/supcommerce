using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupCommerce.Core.Domain;

namespace SupCommerce.Web.Areas.Admin.ViewModels
{
    public class CategoryFormViewModel
    {
        public int? Id { get; set; }

        [Required] public string Name { get; set; }

        [Display(Name = "Parent Category")] public int? ParentCategoryId { get; set; }

        public IEnumerable<Category> AllParentCategories { get; set; }

        public List<SelectListItem> PrepareParentCategoriesForDrowndown(int? currentCategoryId)
        {
            if (AllParentCategories == null || !AllParentCategories.Any())
                return new List<SelectListItem>();

            var list = new List<SelectListItem>();

            foreach (var parentCategory in AllParentCategories)
            {
                if (currentCategoryId.HasValue)
                {
                    if (parentCategory.Id == currentCategoryId)
                        continue;
                }

                list.Add(new SelectListItem
                {
                    Text = parentCategory.Name,
                    Value = parentCategory.Id.ToString()
                });
            }

            return list;
        }
    }
}