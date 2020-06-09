using AutoMapper;
using FluentValidationsApp.DTOS;
using FluentValidationsApp.Models;

namespace FluentValidationsApp.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerDto>();
            CreateMap<CustomerDto,Customer>();
        }
    }
}