using Fluxor;
using IMS.Application.Companies.Queries.GetCompany;
using IMS.WebApp.Store.Company.Actions.LoadCompanies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Effects
{
    public class LoadCompaniesEffect : Effect<LoadCompaniesAction>
    {
        private readonly ISender _sender;

        public LoadCompaniesEffect(ISender sender)
        {
            _sender = sender;
        }

        public async override Task HandleAsync(LoadCompaniesAction action, IDispatcher dispatcher)
        {
            var response = await _sender.Send(new GetCompanyQuery() { PageNumber = action.PageNumber, PageSize = action.PageSize });
            if (response.Succeeded)
                dispatcher.Dispatch(new LoadCompaniesSuccessAction(response.Data, response.TotalRecords));
            else
                dispatcher.Dispatch(new LoadCompaniesFailureAction(response.Message));
        }
    }
}
