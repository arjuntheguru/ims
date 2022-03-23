using IMS.Application.Companies.Commands.AddEditCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Actions.AddCompany
{
    public class AddEditCompanyAction
    {
        public AddEditCompanyCommand CreateCompanyCommand { get; }

        public AddEditCompanyAction(AddEditCompanyCommand createCompanyCommand)
        {
            CreateCompanyCommand = createCompanyCommand;
        }
    }
}
