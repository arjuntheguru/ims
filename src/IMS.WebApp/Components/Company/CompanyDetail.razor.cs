using AutoMapper;
using Fluxor;
using IMS.Application.Companies.Commands.AddEditCompany;
using IMS.Application.Companies.DTOs;
using IMS.WebApp.Store.Company;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Components.Company
{
    public partial class CompanyDetail
    {
        [Inject]
        public IState<CompanyState> CompanyState { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        IDialogService DialogService { get; set; }

        private void OpenDialog(CompanyDto company)
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, CloseButton = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(AddEditCompanyDialog.Model), Mapper.Map<AddEditCompanyCommand>(company));
            parameters.Add(nameof(AddEditCompanyDialog.IsEdit), true);
            DialogService.Show<AddEditCompanyDialog>("Add Company", parameters,options);
        }

    }
}
