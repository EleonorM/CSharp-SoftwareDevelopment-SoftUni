namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Dtos.Import;
    using CarDealer.Dtos.Export;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSuppliersDto, Supplier>();
            this.CreateMap<ImportPartsDto, Part>();
            this.CreateMap<ImportCarsDto, Car>();
            this.CreateMap<ImportCustomersDto, Customer>();
            this.CreateMap<ImportSalesDto, Sale>();
            this.CreateMap<ExportCarsBMWDto, Car>();
        }
    }
}
