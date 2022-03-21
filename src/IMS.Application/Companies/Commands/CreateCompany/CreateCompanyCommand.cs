using IMS.Application.Common.Interfaces;
using IMS.Application.Common.Models;
using IMS.Application.Common.Wrappers;
using IMS.Domain.Common;
using IMS.Domain.Constants;
using IMS.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Response<Unit>>
    {
        public string Name { get; set; }
        public Address Address { get; set; } = new Address();
        public ContactPerson PrimaryContact { get; set; } = new ContactPerson();
        public IList<ContactPerson> OtherContacts { get; set; } = new List<ContactPerson>();
        public string PrimaryContactNumber { get; set; }
        public string SecopndaryContactNumber { get; set; }
        public string Email { get; set; }
        public Currency Currency { get; set; } 
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public int? WarehouseCount { get; set; }
        public CreateAdminRequest Admin { get; set; } = new CreateAdminRequest();
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Response<Unit>>
    {
        private readonly IMongoDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateCompanyCommandHandler(
            IMongoDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Response<Unit>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {   
            var company = new Company
            {
                Name = request.Name,
                Address = request.Address,
                PrimaryContact = request.PrimaryContact,
                OtherContacts = request.OtherContacts,
                PrimaryContactNumber = request.PrimaryContactNumber,
                SecopndaryContactNumber = request.SecopndaryContactNumber,
                Email = request.Email,
                Currency = request.Currency,
                Setting = new CompanySetting
                {
                    SubscriptionStartDate = request.SubscriptionStartDate,
                    SubscriptionEndDate = request.SubscriptionEndDate,
                    MaxWarehouseCount = request.WarehouseCount
                },
                CreatedDate = DateTime.Now,
                CreatedBy = "SUPERADMIN"
            };            

            await _context.Companies.InsertOneAsync(company, cancellationToken: cancellationToken);

            var applicationUser = new ApplicationUser
            {
                UserName = request.Admin.Username,
                Email = request.Admin.Email,
                CompanyId = company.Id
            };

            await _userManager.CreateAsync(applicationUser, request.Admin.Password);

            return new Response<Unit>(Unit.Value,"Company added successfully");
        }
    }
}
