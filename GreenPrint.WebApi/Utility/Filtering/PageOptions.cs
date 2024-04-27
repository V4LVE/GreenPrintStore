using GreenPrint.Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.WebApi.Utility.Filtering
{
    public class PageOptions
    {

        // PAGING
        public const int DefaultPageSize = 8;   //default page size is 10
        public const int defaultPageNumber = 1;  //default page number is 1

        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = DefaultPageSize;

        public int TotalPages { get; set; }

    }
}
