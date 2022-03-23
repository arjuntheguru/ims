using FluentValidation;
using IMS.Application.Common.Models;
using IMS.Application.Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Companies.Commands.AddEditCompany
{
    public class AddEditCompanyCommandValidator : AbstractValidator<AddEditCompanyCommand>
    {
        public AddEditCompanyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Address).SetValidator(new AddressValidator());
            RuleFor(p => p.PrimaryContact).SetValidator(new ContactPersonValidator());
            RuleForEach(p => p.OtherContacts).SetValidator(new ContactPersonValidator());
            RuleFor(p => p.Admin).SetValidator(new CreateAdminRequestValidator());
            RuleFor(p => p.PrimaryContactNumber).NotEmpty();
            RuleFor(p => p.PrimaryContactNumber).NotEmpty();
            RuleFor(p => p.Setting.Currency).NotEmpty();
            RuleFor(p => p.Setting.SubscriptionStartDate).NotEmpty();
            RuleFor(p => p.Setting.SubscriptionStartDate).LessThan(p => p.Setting.SubscriptionEndDate).When(p => p.Setting.SubscriptionEndDate != null);
            RuleFor(p => p.Setting.SubscriptionEndDate).NotEmpty().GreaterThan(p => p.Setting.SubscriptionStartDate);
            RuleFor(p => p.Setting.WarehouseCount).NotEmpty().GreaterThan(0);
        }
    }
}
