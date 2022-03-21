using FluentValidation;
using IMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Common.Validators
{
    public class ContactPersonValidator : AbstractValidator<ContactPerson>
    {
        public ContactPersonValidator()
        {
            RuleFor(p => p.Salutation).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
        }
    }
}
