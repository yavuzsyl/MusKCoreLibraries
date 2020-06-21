using AutoMapper;
using FluentValidationsApp.DTOS;
using FluentValidationsApp.Models;
using System.Linq;

namespace FluentValidationsApp.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // CreateMap<Customer,CustomerDto>();
            // CreateMap<CustomerDto,Customer>();

            //mapplenecek ana sınıfa ait type propertyler mapplenecek hedef sınıf içinde aynı isimlerle mapplenebilmesi için inner type ile hedef sınıf arasında map create edilir ve normal class hedef class mappleme konfigürasyonunda IncludeMmebers metodu ile inner type include edilir
            CreateMap<CreditCard, CustomerDto>();

            //çift taraflı mapping ayrı ayrı yazmak yerine
            CreateMap<Customer, CustomerDto>().IncludeMembers(c => c.CreditCard)
                .ForMember(s => s.addressDtos, mems =>
                mems.MapFrom(c => c.Addresses.Select(a =>
                new AddressDto
                {
                    City = a.City,
                    Description = a.Description,
                    Id = a.Id,
                    PostCode = a.PostCode
                })));//custom işlemlerde reverse map çalışmaz tersi için tekrar create map yazılması gerekir




            CreateMap<Customer, CustomerDtoDN>()
                .ForMember(dest => dest.KnownFor, mops => mops.MapFrom(m => m.Name))
                .ForMember(dest => dest.Contact, memberopts => memberopts.MapFrom(m => m.Email))
                .ForMember(dest => dest.YearsOld, memberopts => memberopts.MapFrom(m => m.Age))
                .ForMember(dest => dest.FullInfo, memberopts => memberopts.MapFrom(m => m.GetFullInfoV2()))
                .ForMember(dest => dest.CCName, membeOpts => membeOpts.MapFrom(c => c.CreditCard.Number))
                .ForMember(dest => dest.CCName, memberOpts => memberOpts.MapFrom(c => c.CreditCard.ValidDate));
        }
    }
}