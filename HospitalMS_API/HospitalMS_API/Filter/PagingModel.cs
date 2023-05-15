using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMS_API.Filter
{
    public class PagingModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PagingModel()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PagingModel(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize >= 15 ? 15 : pageSize; //allow maximum 15 records per page
        }
    }
}
