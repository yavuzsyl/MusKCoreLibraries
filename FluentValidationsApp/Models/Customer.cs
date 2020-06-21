using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.Models
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new List<Address>();
        }
        public int Id { get; set; }
        /*[Required(ErrorMessage ="Name alanı boş olamaz")] *//*if we dont use fluentvalidations we have to use data annotation to validate our proerties*/
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();

        public CreditCard CreditCard { get; set; }
        
        public string GetFullInfo()
        {
            return $"{Name}-{Email}-{Age}-{BirthDate}";
        }

        public string GetFullInfoV2()
        {
            return $"{Name}-{Email}-{Age}-{BirthDate}";
        }

    }
}
