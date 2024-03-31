using GreenPrint.Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Paging
{
    public class SortFilterPageOptions
    {
        // Ordering if any
        public OrderByOptions OrderByOptions { get; set; }

        // PAGING
        public const int DefaultPageSize = 10;   //default page size is 10

        public int PageNum { get; set; }

        public int PageSize { get; set; } = DefaultPageSize;

        public int NumPages { get; private set; }

        public void SetupRestOfDto<T>(IQueryable<T> query)
        {
            NumPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            PageNum = Math.Min(Math.Max(1, PageNum), NumPages);
        }
    }
}
