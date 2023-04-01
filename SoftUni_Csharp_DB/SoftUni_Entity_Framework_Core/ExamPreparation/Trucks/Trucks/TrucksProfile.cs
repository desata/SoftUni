namespace Trucks
{
    using AutoMapper;

    using Data.Models;
    using DataProcessor.ExportDto;
    using System.Linq;

    public class TrucksProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TrucksProfile()
        {
            this.CreateMap<Truck, ExportDespatcherTruckDto>()
               .ForMember(dto => dto.RegistrationNumber, m => m.MapFrom(t => t.RegistrationNumber))
               .ForMember(dto => dto.Make, m => m.MapFrom(t => t.MakeType.ToString()));
            this.CreateMap<Despatcher, ExportDespatcherDto>()
                .ForMember(dto => dto.Name, m => m.MapFrom(d => d.Name))
                .ForMember(dto => dto.TrucksCount, m => m.MapFrom(d => d.Trucks.Count))
                .ForMember(dto => dto.Trucks, m => m.MapFrom(d => d.Trucks.ToArray().OrderBy(t => t.RegistrationNumber).ToArray()));
        }
    }
}
