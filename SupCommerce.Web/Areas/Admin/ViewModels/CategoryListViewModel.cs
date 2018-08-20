using SupCommerce.Core;
using SupCommerce.Core.Domain;

namespace SupCommerce.Web.Areas.Admin.ViewModels
{
    public class CategoryListViewModel
    {
        public IPagedList<Category> Categories { get; set; }

        public string q { get; set; }
    }
}