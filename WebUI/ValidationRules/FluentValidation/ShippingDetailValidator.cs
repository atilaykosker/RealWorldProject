using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator : AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.FirstName).MinimumLength(2);

            RuleFor(s => s.LastName).NotEmpty();

            RuleFor(s => s.Address).NotEmpty();

        }
    }
}
