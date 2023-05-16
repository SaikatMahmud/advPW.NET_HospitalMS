using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_API.Filter
{
    public class PaginationFilter
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        // public bool HasPrevious { get; set; }
        //public bool HasNext { get; set; }
        public PaginationFilter(int resourceCount, int pageSize, int pageNumber)
        {
            this.TotalCount = resourceCount;
            this.PageSize = pageSize > TotalCount ? TotalCount : pageSize;
            this.CurrentPage = pageNumber;
            this.TotalPages = (int)Math.Ceiling(resourceCount / (double)pageSize);
            this.PreviousPage = CurrentPage > 1 ? (CurrentPage - 1) : 1;
            this.NextPage = CurrentPage < TotalPages ? (CurrentPage + 1) : CurrentPage;
        }

    }
}