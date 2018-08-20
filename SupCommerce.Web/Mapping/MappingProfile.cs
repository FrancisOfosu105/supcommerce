using AutoMapper;
using SupCommerce.Core.Domain;
using SupCommerce.Web.Areas.Admin.ViewModels;

namespace SupCommerce.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryFormViewModel, Category>()
                .ForMember(c => c.FileName, opts => opts.Ignore());

            CreateMap<Category, CategoryFormViewModel>();
        }
    }
}