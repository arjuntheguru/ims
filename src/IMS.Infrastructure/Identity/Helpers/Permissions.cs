using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Identity.Helpers
{
    public static class Permissions
    {
        public static List<string> GenerateAllPermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"{module}.Create",
                $"{module}.View",
                $"{module}.Edit",
                $"{module}.Delete"
            };
        }

        public static List<string> GenerateReadPermissionForModule(string module)
        {
            return new List<string>()
            {
                $"{module}.View"
            };
        }
    }

}
