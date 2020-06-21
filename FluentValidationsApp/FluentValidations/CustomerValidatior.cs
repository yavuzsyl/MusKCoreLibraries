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
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş geçilemez";
        //validaston kuralları ctor içinde abstractvalidator sınıfına ait rulefor metodu ile her property için yazılır
        public CustomerValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı geçerli formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 65).WithMessage("Yaş bilgisi 18 ile 65 değerleri arasında olmalıdır");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaş sınırı 18'dir.");

            RuleFor(x => x.Gender).NotEmpty().WithMessage(NotEmptyMessage).IsInEnum().WithMessage("{PropertyName} 1 for male 2 for female");
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
            
        }
    }
}
