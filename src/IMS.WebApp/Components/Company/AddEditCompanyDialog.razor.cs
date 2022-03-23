using FluentValidation;
using IMS.Application.Companies.Commands.AddEditCompany;
using IMS.Domain.Common;
using IMS.WebApp.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Components.Company
{
    public partial class AddEditCompanyDialog
    {
        [Inject]
        public CompanyStateFacade CompanyStateFacade { get; set; }

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }       

        MudForm form;

        MudExpansionPanels expansionPanels;

        [Parameter]
        public bool IsEdit { get; set; } = false;

        MudItem contactWarning;
        string contactWarningVisibility = "invisible";

        [Parameter]
        public AddEditCompanyCommand Model { get; set; } = new AddEditCompanyCommand();

        private AddEditCompanyCommandValidator modelValidator = new();

        private void AddOtherContact()
        {
            if (Model.OtherContacts.Count < 2)
            {
                Model.OtherContacts.Add(new ContactPerson());               
            }
            else
            {
                contactWarningVisibility = "visible";
               
            }
        }

        private void RemoveAdditionalContact(ContactPerson contactPerson)
        {
            if(contactWarningVisibility == "visible")
            {
                contactWarningVisibility = "invisible";
                StateHasChanged();
            }
            Model.OtherContacts.Remove(contactPerson);
        }          

        public async Task Submit()
        {

            await form.Validate();

            if (form.IsValid)
            {
                MudDialog.Close(DialogResult.Ok(true));
                CompanyStateFacade.CreateCompnay(Model);
            }
            else
            {
                expansionPanels.ExpandAll();
            }
        }

        public static IEnumerable<Currency> GetCurrency()
        {
            yield return new Currency
            {
                Symbol = "₹",
                Code = "INR"
            };

            yield return new Currency
            {
                Symbol = "$",
                Code = "USD"
            };
            yield return new Currency
            {
                Symbol = "€",
                Code = "GBP"
            };

            yield return new Currency
            {
                Symbol = "$",
                Code = "EUR"
            };

            yield return new Currency
            {
                Symbol = "Rs",
                Code = "NPR"
            };
        }

        void Cancel() => MudDialog.Cancel();
    }
}
