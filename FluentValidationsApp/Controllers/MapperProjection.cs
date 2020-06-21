using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidationsApp.DTOS;
using FluentValidationsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationsApp.Controllers
{
    public class MapperProjection : Controller
    {
        private readonly IMapper mapper;
        public MapperProjection(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            
            return View();
        }  
        [HttpPost]
        public IActionResult Index(EventDateDto eventDateDto)
        {

            EventDate eventDate = mapper.Map<EventDate>(eventDateDto);
            EventDateDto eventDateDto1 = mapper.Map<EventDateDto>(eventDate);


            ViewBag.date = eventDate.Date.Date;
            return View();
        }
    }
}
