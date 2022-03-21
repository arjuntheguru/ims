using FluentValidation;
using IMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Common.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.AddressLine1).NotEmpty();           
            RuleFor(p => p.Country).NotEmpty();            
        }
    }
}
