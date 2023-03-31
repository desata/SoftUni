using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //Supplier

        this.CreateMap<ImportSupplierDto, Supplier>();

        //Part

        this.CreateMap<ImportPartDto, Part>();
        //.ForMember(d=>d.SupplierId,opt => opt.MapFrom(s=>s.SupplierId.Value));
        this.CreateMap<Part, ExportPartDto>();

        //Car
        this.CreateMap<ImportCarDto, Car>()
                    .ForSourceMember(s => s.PartIds, opt => opt.DoNotValidate());
        this.CreateMap<Car, ExportCarDto>();
        this.CreateMap<Car, ExportCarWithPartsDto>()
            .ForMember(d=>d.Parts,opt=>opt.MapFrom(s=>s.PartsCars.Select(pc=>pc.Part).OrderByDescending(p=>p.Price).ToArray()));

        //Customer
        this.CreateMap<ImportCustomerDto, Customer>();

        //Sale
        this.CreateMap<ImportSaleDto, Sale>();
  
        //ExportCarMakeByBMW

        this.CreateMap<Car, ExportCarMakeByBWDtos>();

        //ExportSupplierNotImport

        this.CreateMap<Supplier, ExportSupplierNotImportDto>();

        //TotalSalesByCustomer - 18

        this.CreateMap<Customer, ExportSaleDto>()
            .ForMember(d => d.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
            .ForMember(d => d.CarPrices, opt => opt.MapFrom(src => src.IsYoungDriver == true ? 
                src.Sales.Select(s => (decimal)0.95 * s.Car.PartsCars.Sum(pc => pc.Part.Price)) 
            : src.Sales.Select(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))));

        this.CreateMap<ExportSaleDto,ExportCustomerDto>()
            .ForMember(d=>d.SpentMoney,opt=>opt.MapFrom(src=>Math.Round(src.CarPrices.Sum(),2,MidpointRounding.ToZero)));

        //19
        this.CreateMap<Sale, ExportSalesWithDiscount>()
                .ForMember(d=>d.Car,opt=>opt.MapFrom(src=>src.Car))
            .ForMember(d => d.Discount, opt => opt.MapFrom(src => src.Discount))
            .ForMember(d => d.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(d => d.Price, opt => opt.MapFrom(src => src.Car.PartsCars.Sum(p => p.Part.Price)))
            .ForMember(d => d.PriceWithDiscount, opt => opt.MapFrom(src =>(src.Car.PartsCars.Select(pc => pc.Part).Sum(p => p.Price) * (1 - src.Discount / 100))
            .ToString("G29")));

        this.CreateMap<Car, ExportCarAttributeDto>();

    }

}
