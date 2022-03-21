using IMS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Common.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public PagedResponse(T data, PaginationFilter filter, int totalRecords)
        {
            PageNumber = filter.PageNumber;
            PageSize = filter.PageSize;
            Data = data;
            TotalRecords = totalRecords;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }

}
