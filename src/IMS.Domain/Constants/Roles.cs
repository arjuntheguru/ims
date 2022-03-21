using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Constants
{
    public record Roles
    {
        public const string SUPERADMIN = "SUPERADMIN";
        public const string COMPANY_ADMIN = "COMPANY_ADMIN";
        public const string COMPANY_SALESPERSON = "COMPANY_SALESPERSON";
        public const string WAREHOUSE_ADMIN = "WAREHOUSE_ADMIN";
        public const string WAREHOUSE_SALESPERSON = "WAREHOUSE_SALESPERSON";
    }
}
