namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoriesDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
            this.CreateMap<ExportProductInRangeDto, Product>();
        }
    }
}
