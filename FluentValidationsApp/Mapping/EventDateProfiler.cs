using AutoMapper;
using FluentValidationsApp.DTOS;
using FluentValidationsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.Mapping
{
    public class EventDateProfiler : Profile
    {
        public EventDateProfiler()
        {
            //custom map olduğu için reverse map olmuyor tekrar yaz
            CreateMap<EventDateDto, EventDate>().ForMember(ed => ed.Date, opt => opt.MapFrom(re => new DateTime(re.Year, re.Month, re.Day)));

            CreateMap<EventDate, EventDateDto>().ForMember(dto => dto.Year, opt => opt.MapFrom(re => re.Date.Year))
                                                .ForMember(dest => dest.Month, opt => opt.MapFrom(re => re.Date.Month))
                                                .ForMember(dest => dest.Day, opt => opt.MapFrom(re => re.Date.Day));
        }
    }
}
