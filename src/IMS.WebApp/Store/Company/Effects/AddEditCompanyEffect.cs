using Fluxor;
using IMS.WebApp.Services;
using IMS.WebApp.Store.Company.Actions.AddCompany;
using IMS.WebApp.Store.Company.Actions.LoadCompanies;
using MediatR;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Effects
{
    public class AddEditCompanyEffect : Effect<AddEditCompanyAction>
    {
        private readonly ISender _sender;
        private readonly SnackbarHandler _snackbarHandler;

        public AddEditCompanyEffect(
            ISender sender, 
            SnackbarHandler snackbarHandler)
        {
            _sender = sender;
            _snackbarHandler = snackbarHandler;
        }

        public async override Task HandleAsync(AddEditCompanyAction action, IDispatcher dispatcher)
        {
            var response = await _sender.Send(action.CreateCompanyCommand);

            if (response.Succeeded)
            {
                dispatcher.Dispatch(new AddEditCompanySuccessAction());
                dispatcher.Dispatch(new LoadCompaniesAction(1, 5));
            }           
            else
                dispatcher.Dispatch(new AddEditCompanyFailureAction(response.Message));
            
            _snackbarHandler.ShowSnackbar(response.Succeeded, response.Message);
        }
    }
}
