using AutoMapper;
using FluentValidationsApp.DTOS;
using FluentValidationsApp.Models;

namespace FluentValidationsApp.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // CreateMap<Customer,CustomerDto>();
            // CreateMap<CustomerDto,Customer>();

            //çift taraflı mapping ayrı ayrı yazmak yerine
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDtoDN>()
                .ForMember(dest => dest.KnownFor, mops => mops.MapFrom(m => m.Name))
                .ForMember(dest => dest.Contact, memberopts => memberopts.MapFrom(m => m.Email))
                .ForMember(dest => dest.YearsOld, memberopts => memberopts.MapFrom(m => m.Age))
                .ForMember(dest => dest.FullInfo, memberopts => memberopts.MapFrom(m => m.GetFullInfoV2()));
        }
    }
}