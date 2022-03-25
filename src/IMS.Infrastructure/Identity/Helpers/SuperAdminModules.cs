using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Identity.Helpers
{
    public static class SuperAdminModules
    {
        public static List<string> GetSuperAdminModules()
        {
            var moduleList = new List<string>
            {
               "Company"
            };

            return moduleList;
        }
    }

}
