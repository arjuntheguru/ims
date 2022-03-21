using AutoMapper;
using IMS.Application.Common.Interfaces;
using IMS.Application.Common.Wrappers;
using IMS.Domain.Common;
using IMS.Domain.Entites;
using IMS.Domain.Enums;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response<string>>
    {
        public CustomerType CustomerType { get; set; }
        public string Name { get; set; }
        public ContactPerson PrimaryContact { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public Currency Currency { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public double CreditLimit { get; set; }
        public string Remarks { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<string>>
    {
        private readonly IMongoDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(
            IMongoDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            await _context.Customers.InsertOneAsync(customer, cancellationToken: cancellationToken);
            return new Response<string>("Customer created successfully");
        }
    }
}
