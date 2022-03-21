using IMS.Application.Companies.Commands.CreateCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Actions.AddCompany
{
    public class AddCompanyAction
    {
        public CreateCompanyCommand CreateCompanyCommand { get; }

        public AddCompanyAction(CreateCompanyCommand createCompanyCommand)
        {
            CreateCompanyCommand = createCompanyCommand;
        }
    }
}
