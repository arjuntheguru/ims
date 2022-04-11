using AutoMapper;

using IMS.Application.Common.Interfaces;
using IMS.Application.Common.Models;
using IMS.Application.Common.Wrappers;
using IMS.Application.Companies.DTOs;
using IMS.Domain.Entites;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQuery : IRequest<PagedResponse<IEnumerable<CompanyDto>>>
    {
        public string NameSearch { get; set; } = "";
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, PagedResponse<IEnumerable<CompanyDto>>>
    {
        private readonly IMongoDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(
            IMongoDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<CompanyDto>>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new PaginationFilter(request.PageNumber, request.PageSize);
            var companies = await _context.Companies
                .Find(p => p.Name.ToLower().Contains(request.NameSearch.ToLower()))
                .SortByDescending(p => p.CreatedDate)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Limit(validFilter.PageSize)
                .ToListAsync(cancellationToken);
            

            var totalRecords = await _context.Companies.CountDocumentsAsync(new BsonDocument(), cancellationToken: cancellationToken);

            var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return new PagedResponse<IEnumerable<CompanyDto>>(companyDto, validFilter, (int)totalRecords);

        }
    }
}
