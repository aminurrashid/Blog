using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ApiResponse
{
    public class PaginationApiResponse<T>
    {
        public T Data { get; set; }
        public Meta Meta { get; set; }
    }
}
