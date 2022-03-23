using IMS.Application.Common.Interfaces;
using IMS.Application.Common.Models;
using IMS.Application.Common.Wrappers;
using IMS.Domain.Common;
using IMS.Domain.Constants;
using IMS.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Companies.Commands.AddEditCompany
{
    public class AddEditCompanyCommand : IRequest<Response<Unit>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; } = new Address();
        public ContactPerson PrimaryContact { get; set; } = new ContactPerson();
        public IList<ContactPerson> OtherContacts { get; set; } = new List<ContactPerson>();
        public string PrimaryContactNumber { get; set; }
        public string SecopndaryContactNumber { get; set; }
        public string Email { get; set; }
        public CompanySetting Setting { get; set; } = new CompanySetting();
        public CreateAdminRequest Admin { get; set; } = new CreateAdminRequest();
    }

    public class CreateCompanyCommandHandler : IRequestHandler<AddEditCompanyCommand, Response<Unit>>
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
        public async Task<Response<Unit>> Handle(AddEditCompanyCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
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
                    Setting = request.Setting,
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

                return new Response<Unit>(Unit.Value, "Company added successfully");
            }
            else
            {
                var updateOptions = Builders<Company>.Update
                    .Set(p => p.Name, request.Name)
                    .Set(p => p.Address, request.Address)
                    .Set(p => p.PrimaryContact, request.PrimaryContact)
                    .Set(p => p.OtherContacts, request.OtherContacts)
                    .Set(p => p.Email, request.Email)
                    .Set(p => p.Setting, request.Setting)
                    .Set(p => p.PrimaryContactNumber, request.PrimaryContactNumber)
                    .Set(p => p.SecopndaryContactNumber, request.SecopndaryContactNumber);

                await _context.Companies.FindOneAndUpdateAsync(p => p.Id == request.Id, updateOptions);

                return new Response<Unit>(Unit.Value, "Company updated successfully");
            }

        }
    }
}
