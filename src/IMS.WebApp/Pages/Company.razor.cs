using IMS.Application.Common.Models;
using IMS.Application.Common.Wrappers;
using IMS.Application.Companies.DTOs;
using IMS.Application.Companies.Queries.GetCompany;
using IMS.WebApp.Components.Company;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Pages
{
    public partial class Company
    {      

        [Inject]
        IDialogService DialogService { get; set; }       

        private void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, CloseButton = true };

            DialogService.Show<AddEditCompanyDialog>("Add Company", options);
        }

    }
}
