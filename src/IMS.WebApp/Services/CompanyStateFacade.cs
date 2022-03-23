using Fluxor;
using IMS.Application.Companies.Commands.AddEditCompany;
using IMS.Application.Companies.DTOs;
using IMS.WebApp.Store.Company.Actions.AddCompany;
using IMS.WebApp.Store.Company.Actions.LoadCompanies;
using IMS.WebApp.Store.Company.Actions.SelectCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Services
{
    public class CompanyStateFacade
    {
        private readonly IDispatcher _dispatcher;

        public CompanyStateFacade(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void LoadCompanies(int pageNumber, int pageSize)
        {
            _dispatcher.Dispatch(new LoadCompaniesAction(pageNumber, pageSize));
        }

        public void SelectCompany(CompanyDto company)
        {
            _dispatcher.Dispatch(new SelectCompanyAction());
            try
            {
                _dispatcher.Dispatch(new SelectCompanySuccessAction(company));
            }
            catch (Exception ex)
            {
                {
                    _dispatcher.Dispatch(new SelectCompanyFailureAction(ex.Message));
                }
            }
        }

        public void CreateCompnay(AddEditCompanyCommand command)
        {
            _dispatcher.Dispatch(new AddEditCompanyAction(command));
        }
    }
}
