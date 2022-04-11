using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store.Company.Actions.LoadCompanies
{
    public class LoadCompaniesAction
    {
        public LoadCompaniesAction(int pageNumber, int pageSize, string nameSearch = "") => 
            (PageNumber, PageSize, NameSearch) = (pageNumber, pageSize, nameSearch);
      
        public int PageNumber { get; }
        public int PageSize { get;  }
        public string NameSearch { get; set; }
    }
}
