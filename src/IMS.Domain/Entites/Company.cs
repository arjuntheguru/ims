using IMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class Company : AuditableEntity
    {
        public string Name { get; set; }
        public ContactPerson PrimaryContact { get; set; }
        public IEnumerable<ContactPerson> OtherContacts { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SecopndaryContactNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }        
        public bool IsActive { get; set; }
        public Currency Currency { get; set; }
        public CompanySetting Setting { get; set; }
        public IEnumerable<string> WarehouseIds { get; set; }
        public IEnumerable<string> UserIds { get; set; }
    }

    public class CompanySetting
    {
        public int? MaxWarehouseCount { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }       
    }
}
