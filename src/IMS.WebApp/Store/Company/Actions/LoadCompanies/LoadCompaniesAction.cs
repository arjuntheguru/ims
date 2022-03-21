using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Actions.LoadCompanies
{
    public class LoadCompaniesAction
    {
        public LoadCompaniesAction(int pageNumber, int pageSize) => 
            (PageNumber, PageSize) = (pageNumber, pageSize);
      
        public int PageNumber { get; }
        public int PageSize { get;  }
    }
}
