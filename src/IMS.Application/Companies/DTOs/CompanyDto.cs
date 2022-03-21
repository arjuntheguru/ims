using IMS.Domain.Common;
using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Companies.DTOs
{
    public class CompanyDto
    {
        public string Id { get; set; }
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
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
