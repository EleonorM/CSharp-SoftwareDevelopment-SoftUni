namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using System.Linq;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoriesDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
            this.CreateMap<ExportProductInRangeDto, Product>();
            this.CreateMap<Category, ExportCategoriesByProductsCountDto>()
                .ForMember(x => x.Count, y => y.MapFrom(x => x.CategoryProducts.Count))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(x => x.CategoryProducts.Sum(cp => cp.Product.Price)));
        }
    }
}
