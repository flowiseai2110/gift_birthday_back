using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Utils
{
    public class PaginacionRequest
    {
        public int pagina { get; set; }
        public int tamanio { get; set; }
    }
}
