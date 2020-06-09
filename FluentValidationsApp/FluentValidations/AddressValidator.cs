using FluentValidation;
using FluentValidationsApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationsApp.FluentValidations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş geçilemez";

        public AddressValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Description).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMessage)
                .MaximumLength(5)
                .WithMessage("{PropertyName} alanı {MaxLength} karakter olmalıdır");
        }
    }
}
