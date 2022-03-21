using IMS.Domain.Common;
using IMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class Customer : BaseEntity
    {
        public CustomerType CustomerType { get; set; }
        public string Name { get; set; }
        public ContactPerson PrimaryContact { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        public Currency Currency { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public double CreditLimit { get; set; }
        public string Remarks { get; set; }
    }
}
