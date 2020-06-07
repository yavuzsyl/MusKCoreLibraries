using FluentValidation;
using FluentValidation.Validators;
using FluentValidationsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.FluentValidations
{
    public class CustomerValidatior : AbstractValidator<Customer>
    {
        //validaston kuralları ctor içinde abstractvalidator sınıfına ait rulefor metodu ile her property için yazılır
        public CustomerValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez").EmailAddress().WithMessage("Email alanı geçerli formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age alanı boş geçilemez").InclusiveBetween(18, 65).WithMessage("Yaş bilgisi 18 ile 65 değerleri arasında olmalıdır");
        }
    }
}
