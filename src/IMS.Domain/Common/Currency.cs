using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Common
{
    public record Currency
    {
        public string Symbol { get; set; }
        public string Code { get; set; }
    }
}
