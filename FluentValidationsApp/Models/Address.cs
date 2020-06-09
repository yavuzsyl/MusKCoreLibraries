using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
