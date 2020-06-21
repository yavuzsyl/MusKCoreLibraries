﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.DTOS
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}
