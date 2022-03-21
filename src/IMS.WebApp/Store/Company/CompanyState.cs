using Fluxor;
using IMS.Application.Companies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company
{    
    public record CompanyState : RootState
    {
        public int CurrentPage { get; init; }
        public IEnumerable<CompanyDto> CurrentCompanies { get; init; }
        public CompanyDto CurrentCompany { get; init; }
        public int TotalRecords { get; init; }
    }
}
