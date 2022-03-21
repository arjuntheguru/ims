using Fluxor;
using IMS.Application.Companies.DTOs;
using IMS.Application.Companies.Queries.GetCompany;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company
{
    public class CompanyFeature : Feature<CompanyState>
    {

        public override string GetName() => "Company";


        protected override CompanyState GetInitialState() => new CompanyState()
        {
            IsLoading = false,
            CurrentPage = 0,
            CurrentCompanies = new List<CompanyDto>(),      
            TotalRecords = 0
        };

    }
}
