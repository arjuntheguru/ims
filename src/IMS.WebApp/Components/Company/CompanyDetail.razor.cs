using Fluxor;
using IMS.Application.Companies.DTOs;
using IMS.WebApp.Store.Company;
using Microsoft.AspNetCore.Components;
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

    }
}
