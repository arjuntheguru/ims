using IMS.WebApp.Store.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Actions.AddCompany
{
    public class AddCompanyFailureAction : FailureAction
    {
        public AddCompanyFailureAction(string errorMessage) : base(errorMessage)
        {
        }
    }
}
