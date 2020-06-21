using System;
using System.Collections.Generic;

namespace FluentValidationsApp.DTOS
{
    public class CustomerDto
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string FullInfo { get; set; }
        public List<AddressDto> addressDtos { get; set; }
        public string Number { get; set; }
        public DateTime ValidDate { get; set; }



        //CreditCard props without Include
        //public string CreditCardNumber { get; set; }
        //public DateTime CreditCardValidDate { get; set; }

    }
}