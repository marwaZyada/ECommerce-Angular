using AutoMapper;
using EComerce.API.Dtos;
using EComerce.Core.Entities.Product;
using EComerce.Core.Services;

namespace EComerce.API.Mapping
{
    public class MappingProfile:Profile
    {
       

        public MappingProfile()
        {
   
            CreateMap<CategoryDto,Category>().ReverseMap();
            CreateMap<UpdatedCategoryDto, Category>();
            CreateMap<ProductDto, Product>().ReverseMap()
               .ForMember(p=>p.CategoryName,m=>m.MapFrom(p=>p.Category.Name)) ;
            CreateMap<PhotoDto, Photo>().ReverseMap();
            CreateMap<AddProductDto, Product>()
              .ForMember(p => p.photos, m => m.Ignore()).ReverseMap();
            CreateMap<UpdatedProductDto, Product>()
           .ForMember(p => p.photos, m => m.Ignore()).ReverseMap();

        }
    }
}
