using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Gestionar
{
    public class CPromocionDto
    {
        public int promocion_id { get; set; }
        public int local_comercial_id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
