using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupCommerce.Core.Domain
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }

        public int? ParentCategoryId { get; set; }

        public string FileName { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        [NotMapped] public string PictureUrl => string.IsNullOrEmpty(FileName) ? null : $"uploads/{FileName}";

        public Category()
        {
            SubCategories = new Collection<Category>();
        }
    }
}