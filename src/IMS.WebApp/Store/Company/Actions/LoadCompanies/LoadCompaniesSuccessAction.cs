using IMS.Application.Companies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Actions.LoadCompanies
{
    public class LoadCompaniesSuccessAction
    {
        public LoadCompaniesSuccessAction(IEnumerable<CompanyDto> companies, int totalRecords)
        {
            Companies = companies;
            TotalRecords = totalRecords;
        }

        public IEnumerable<CompanyDto> Companies { get; }
        public int TotalRecords { get; set; }

    }
}
