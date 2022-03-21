using IMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public ContactPerson PriamaryContact { get; set; }
        public bool IsPrimary { get; set; }
        public Address Address { get; set; } 
    }
}
