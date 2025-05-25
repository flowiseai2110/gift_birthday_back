using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Utils
{
    public class PaginacionResponse<T>
    {
        public IEnumerable<T> data { get; set; }
        public int total { get; set; }
    }
}
