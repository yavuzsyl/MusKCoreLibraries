using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.DTOS
{
    public class CreditCardDto
    {
        public string Number { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
