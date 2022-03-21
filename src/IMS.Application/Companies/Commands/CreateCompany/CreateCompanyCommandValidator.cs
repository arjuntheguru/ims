using FluentValidation;
using IMS.Application.Common.Models;
using IMS.Application.Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Address).SetValidator(new AddressValidator());
            RuleFor(p => p.PrimaryContact).SetValidator(new ContactPersonValidator());
            RuleForEach(p => p.OtherContacts).SetValidator(new ContactPersonValidator());
            RuleFor(p => p.Admin).SetValidator(new CreateAdminRequestValidator());
            RuleFor(p => p.PrimaryContactNumber).NotEmpty();
            RuleFor(p => p.PrimaryContactNumber).NotEmpty();
            RuleFor(p => p.Currency).NotEmpty();
            RuleFor(p => p.SubscriptionStartDate).NotEmpty().LessThan(p => p.SubscriptionEndDate).When(p => p.SubscriptionEndDate != null);
            RuleFor(p => p.SubscriptionEndDate).NotEmpty().GreaterThan(p => p.SubscriptionStartDate);
            RuleFor(p => p.WarehouseCount).NotEmpty().GreaterThan(0);
        }
    }
}
