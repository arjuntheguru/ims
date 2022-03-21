using IMS.WebApp.Store.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Actions.LoadCompanies
{
    public class LoadCompaniesFailureAction : FailureAction
    {
        public LoadCompaniesFailureAction(string errorMessage) : base(errorMessage)
        {
        }
    }
}
