using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupCommerce.Core.Domain;

namespace SupCommerce.Web.Areas.Admin.ViewModels
{
    public class ProductFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public List<SelectListItem> GetDropdownModel
        {
            get
            {
                if (Categories == null || !Categories.Any())
                    return new List<SelectListItem>();

                return Categories.Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    })
                    .ToList();
            }
        }
    }
}