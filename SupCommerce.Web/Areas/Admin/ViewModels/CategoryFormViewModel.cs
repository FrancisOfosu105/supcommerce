using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupCommerce.Core.Domain;

namespace SupCommerce.Web.Areas.Admin.ViewModels
{
    public class CategoryFormViewModel
    {
        [Required] public string Name { get; set; }

        [Display(Name = "Parent Category")] public int? ParentCategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public List<SelectListItem> GetDropdownModel
        {
            get
            {
                if (Categories == null || !Categories.Any())
                    return new List<SelectListItem>();

                return Categories.Select(parentCategory => new SelectListItem
                    {
                        Text = parentCategory.Name,
                        Value = parentCategory.Id.ToString()
                    })
                    .ToList();
            }
        }
    }
}