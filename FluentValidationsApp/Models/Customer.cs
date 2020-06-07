using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        /*[Required(ErrorMessage ="Name alanı boş olamaz")] *//*if we dont use fluentvalidations we have to use data annotation to validate our proerties*/
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }


    }
}
