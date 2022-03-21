using IMS.Domain.Common;
using IMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entites
{
    public class Item : BaseEntity
    {
        public ProductType ProductType { get; set; }
        public string ItemCategoryId { get; set; }
        public string Image { get; set; }
        public string SKU { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double PurchasePrice { get; set; }
        public double SalesPrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsReturnable { get; set; }
    }
}
