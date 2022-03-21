using Fluxor;
using Fluxor.Blazor.Web.Components;
using IMS.Application.Common.Wrappers;
using IMS.Application.Companies.DTOs;
using IMS.WebApp.Services;
using IMS.WebApp.Store.Company;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Components.Company
{
    public partial class CompanyList
    {
        private string SearchString;

        [Inject]
        public IState<CompanyState> CompanyState { get; set; }

        [Inject]
        public CompanyStateFacade CompanyStateFacade { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CompanyStateFacade.LoadCompanies(1, 5);            
        }

        private void SelectCompanyHandler(CompanyDto company)
        {
            CompanyStateFacade.SelectCompany(company);
        }

        private void PageNumberChangeHandler(int pageNumber)
        {
            CompanyStateFacade.LoadCompanies(pageNumber, 5);
        }

    }
}
