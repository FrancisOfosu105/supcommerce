using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SupCommerce.Core.Domain
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category()
        {
            SubCategories = new Collection<Category>();
        }
    }
}